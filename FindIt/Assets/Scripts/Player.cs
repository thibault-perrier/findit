using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject PlayerAvatar;
    public string PlayerName;
    public Texture2D PlayerPicture;
    public bool isInGame;
    public PhotoManager gameManager;
    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PhotoManager>();
    }
}
