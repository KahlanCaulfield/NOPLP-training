using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

        songManager.AddSong(song);

        title.text = "";
        artist.text = "";
        lyrics.text = "";

        //TODO: Replace by Dotween
        StartCoroutine(DisplaySuccessText());
    }

    private IEnumerator DisplaySuccessText()
    {
        while (successText.color.a < 1.0f)
        {
            successText.color = new Color(successText.color.r, successText.color.g, successText.color.b, successText.color.a + (Time.deltaTime / 1.0f));
            yield return null;
        }
        yield return new WaitForSeconds(2);

        while (successText.color.a > 0.0f)
        {
            successText.color = new Color(successText.color.r, successText.color.g, successText.color.b, successText.color.a - (Time.deltaTime / 1.0f));
            yield return null;
        }
    }
}