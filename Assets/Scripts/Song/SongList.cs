using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongList : MonoBehaviour
{
    [SerializeField]
    private SongManager songManager = default;

    private List<Song> songList;

    private void OnEnable()
    {
        songList = songManager.ListAllSongs();
    }
}