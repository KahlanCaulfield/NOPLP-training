using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class AddSong : MonoBehaviour
{
    [SerializeField]
    private GameObject GameManager = default;

    [SerializeField]
    private TMP_Text successText = default;

    [SerializeField]
    private TMP_InputField title = default;

    [SerializeField]
    private TMP_InputField artist = default;

    [SerializeField]
    private TMP_InputField lyrics = default;

    private SongManager songManager;
    private Song song;

    private void Start()
    {
        songManager = GameManager.GetComponent<SongManager>();
        song = new Song();
    }

    private void Update()
    {
        if (title.text == "" || artist.text == "" || lyrics.text == "")
        {
            GetComponent<Button>().interactable = false;
        }
        else
        {
            GetComponent<Button>().interactable = true;
        }
    }

    public void OnAddSong()
    {
        song.Title = title.text;
        song.Artist = artist.text;
        song.Lyrics = lyrics.text.Split('\n');
        song.id = Guid.NewGuid().ToString();
        songManager.AddSong(song);

        title.text = "";
        artist.text = "";
        lyrics.text = "";

        StartCoroutine(DisplaySuccessText());
    }

    private IEnumerator DisplaySuccessText()
    {
        successText.DOFade(1f, 1);
        yield return new WaitForSeconds(2);

        successText.DOFade(0f, 1);
    }
}