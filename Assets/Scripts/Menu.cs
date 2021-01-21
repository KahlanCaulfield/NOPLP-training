using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject[] screens = default;

    public void DisplayScreen(int index)
    {
        foreach (GameObject screen in screens)
        {
            screen.SetActive(false);
        }

        screens[index].SetActive(true);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}