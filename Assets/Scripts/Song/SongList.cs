using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class SongList : MonoBehaviour
{
    [SerializeField]
    private SongManager songManager = default;

    [SerializeField]
    private GameObject songPrefab;

    [SerializeField]
    private GameObject contentParent;

    [SerializeField]
    private TMP_Text totalSong;

    private List<Song> songList;
    private List<GameObject> songObjects;
    private bool isTitleOrdered;
    private bool isArtistOrdered;

    private void Start()
    {
    }

    private void OnEnable()
    {
        isTitleOrdered = false;
        isArtistOrdered = false;
        songObjects = new List<GameObject>();
        songList = new List<Song>();
        songList = songManager.ListAllSongs();

        UpdateSongList();
    }

    private void UpdateSongList()
    {
        //TODO : Lazy (?) loading
        ClearContent();
        if (songList.Count == 0)
            return;
        songObjects.Clear();
        foreach (Song song in songList)
        {
            GameObject addObj = Instantiate(songPrefab, contentParent.transform);
            addObj.transform.GetChild(0).GetComponent<TMP_Text>().text = song.Title;
            addObj.transform.GetChild(1).GetComponent<TMP_Text>().text = song.Artist;
            addObj.name = song.Title + "-" + song.Artist;
            songObjects.Add(addObj);
        }
        OnSortTitle();
        totalSong.text = songList.Count.ToString();
    }

    private void ClearContent()
    {
        foreach (Transform child in contentParent.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void OnSortTitle()
    {
        List<GameObject> orderedList = new List<GameObject>();

        if (!isTitleOrdered)
        {
            orderedList = songObjects.OrderBy(song => song.name).ToList();
        }
        else
        {
            orderedList = songObjects.OrderByDescending(song => song.name).ToList();
        }

        for (int i = 0; i < orderedList.Count; i++)
        {
            orderedList[i].transform.SetSiblingIndex(i);
        }
        songObjects.Clear();
        songObjects = orderedList;
        isTitleOrdered = !isTitleOrdered;
    }

    public void OnSortArtist()
    {
        List<GameObject> orderedList = new List<GameObject>();
        if (!isArtistOrdered)
        {
            orderedList = songObjects.OrderBy(song => song.transform.GetChild(1).GetComponent<TMP_Text>().text).ToList();
        }
        else
        {
            orderedList = songObjects.OrderByDescending(song => song.transform.GetChild(1).GetComponent<TMP_Text>().text).ToList();
        }

        for (int i = 0; i < orderedList.Count; i++)
        {
            orderedList[i].transform.SetSiblingIndex(i);
        }

        songObjects.Clear();
        songObjects = orderedList;
        isArtistOrdered = !isArtistOrdered;
    }
}