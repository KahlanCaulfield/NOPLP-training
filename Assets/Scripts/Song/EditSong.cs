using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EditSong : MonoBehaviour
{
    public void DisplayEditMenu()
    {
        print(EventSystem.current.currentSelectedGameObject.gameObject.name);
    }

    public void HideEditMenu()
    {
    }

    public void SaveSong()
    {
    }
}