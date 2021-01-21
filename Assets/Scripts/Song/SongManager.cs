using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;

public class SongManager : MonoBehaviour
{
    private string pathToMyDocuments = null;

    private void Start()
    {
        pathToMyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Noplp/";
        if (!Directory.Exists(pathToMyDocuments))
        {
            Directory.CreateDirectory(pathToMyDocuments);
        }
    }

    public void AddSong(Song song)
    {
        //TODO: Create ID

        int count = 1;
        string songToString = JsonUtility.ToJson(song);
        string fileName = song.Title + "-" + song.Artist + ".json";
        while (File.Exists(pathToMyDocuments + fileName))
        {
            fileName = song.Title + "-" + song.Artist + "-" + count + ".json";
            count++;
        }

        File.WriteAllText(pathToMyDocuments + fileName, songToString);
    }

    private void UpdateSong()
    {
    }

    public List<Song> ListAllSongs()
    {
        string[] files = Directory.GetFiles(pathToMyDocuments, "*.json");
        List<Song> songs = new List<Song>();

        foreach (string file in files)
        {
            string fileContent = File.ReadAllText(file);
            songs.Add(JsonUtility.FromJson<Song>(fileContent));
        }
        return songs;
    }

    private void GetSong()
    {
    }
}