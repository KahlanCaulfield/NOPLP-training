using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject[] screens = default;

    [SerializeField]
    private GameObject editSongScreen = default;

    private int lastScreen = -1;

    public void DisplayScreen(int index)
    {
        foreach (GameObject screen in screens)
        {
            screen.SetActive(false);
        }

        screens[index].SetActive(true);
        lastScreen = index;
    }

    public void DisplayEditSongScreen()
    {
        screens[lastScreen].SetActive(false);
        editSongScreen.SetActive(true);
    }

    public void HideEditSongScreen()
    {
        screens[lastScreen].SetActive(true);
        editSongScreen.SetActive(false);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}