using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu]
public class Player_ScriptableObject : ScriptableObject
{
    public int ID;
    public GameObject PlayerAvatar;
    public string PlayerName;
    public List<Texture2D> PlayerPicture;
    public int score;
}
