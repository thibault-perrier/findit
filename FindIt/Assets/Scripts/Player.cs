using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject PlayerAvatar;
    public string PlayerName;
    public List<Texture2D> PlayerPicture;
    private void Start()
    {
        this.name = "player" + this.GetComponent<NetworkObject>().OwnerClientId;
    }
}
