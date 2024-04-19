using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu]
public class Player_ScriptableObject : ScriptableObject
{
    public int ID;
    public GameObject PlayerAvatar;
    public string PlayerName;
    public Texture2D PlayerPicture;
}
