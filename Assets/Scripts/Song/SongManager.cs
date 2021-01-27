using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

public class SongManager : MonoBehaviour
{
    private string pathToMyDocuments = null;
    private List<Song> allSongs = null;
    private Dictionary<String, Song> songsPaths;
    public List<Song> AllSongs { get => allSongs; set => allSongs = value; }

    private void Start()
    {
        songsPaths = new Dictionary<String, Song>();
        pathToMyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Noplp/";
        if (!Directory.Exists(pathToMyDocuments))
        {
            Directory.CreateDirectory(pathToMyDocuments);
        }
        ListAllSongs();
    }

    public void AddSong(Song song)
    {
        int count = 1;
        string songToString = JsonUtility.ToJson(song);
        string fileName = song.Title + "-" + song.Artist + ".json";
        while (File.Exists(pathToMyDocuments + fileName))
        {
            fileName = song.Title + "-" + song.Artist + "-" + count + ".json";
            count++;
        }

        File.WriteAllText(pathToMyDocuments + fileName, songToString);
        allSongs.Add(song);
        songsPaths.Add(pathToMyDocuments + fileName, song);
    }

    public void DeleteSong(string guid)
    {
        string path = songsPaths.FirstOrDefault(song => song.Value.id == guid).Key;

        Song songToDelete = allSongs.Find(song => song.id == guid);
        allSongs.Remove(songToDelete);
        songsPaths.Remove(path);
        File.Delete(path);
    }

    public void UpdateSong(string guid, Song songData)
    {
        string path = songsPaths.FirstOrDefault(song => song.Value.id == guid).Key;

        Song songToUpdate = allSongs.Find(song => song.id == guid);
        songToUpdate = songData;
        songsPaths.TryGetValue(path, out songToUpdate);
        songToUpdate = songData;
        File.WriteAllText(path, JsonUtility.ToJson(songData));
    }

    private void ListAllSongs()
    {
        string[] files = Directory.GetFiles(pathToMyDocuments, "*.json");
        List<Song> songs = new List<Song>();

        foreach (string file in files)
        {
            string fileContent = File.ReadAllText(file);
            Song songToAdd = JsonUtility.FromJson<Song>(fileContent);
            songs.Add(songToAdd);
            songsPaths.Add(file, songToAdd);
        }
        AllSongs = songs;
    }

    public Song GetSong(string guid)
    {
        return allSongs.Find(song => song.id == guid);
    }

    // DEV FUNCTION
    public void UpdateData()
    {
        string[] files = Directory.GetFiles(pathToMyDocuments, "*.json");

        foreach (string file in files)
        {
            string fileContent = File.ReadAllText(file);
            Song song = JsonUtility.FromJson<Song>(fileContent);

            if (song.id == null)
            {
                song.id = Guid.NewGuid().ToString();
            }

            if (song.Artist == null)
            {
                song.Artist = "Inconnu";
            }

            if (song.Title == null)
            {
                song.Title = "Pas de titre";
            }

            if (song.Lyrics.Length == 0)
            {
                song.Lyrics[0] = "Pas de paroles";
            }
            string songToString = JsonUtility.ToJson(song);
            File.WriteAllText(file, songToString);
        }
    }
}