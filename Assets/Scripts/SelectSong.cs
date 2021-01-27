using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SelectSong : MonoBehaviour
{
    private Image backGround;
    private bool isSelected = false;

    private void Start()
    {
        backGround = GetComponent<Image>();
    }

    public void OnSelectSong()
    {
        isSelected = true;
        backGround.DOFade(0.3f, 0.25f);
    }

    public void OnDeSelectSong()
    {
        isSelected = false;
        backGround.DOFade(0f, 0.25f);
    }

    public void OnHover()
    {
        if (!isSelected)
        {
            backGround.DOFade(0.1f, 0.25f);
        }
    }

    public void OnHoverExit()
    {
        if (!isSelected)
        {
            backGround.DOFade(0.0f, 0.25f);
        }
    }
}