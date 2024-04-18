using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;




[CreateAssetMenu]
public class Player_ScriptableObject : ScriptableObject
{
    [SerializeField] public int ID;
    [SerializeField] public GameObject PlayerAvatar;
    [SerializeField] public string PlayerName;
    [SerializeField] public Image PlayerPicture;
}
