using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public class PhotoManager : MonoBehaviour
{
    int Id = -1;
    public List<Texture2D> AllPicture = new List<Texture2D>();
    public byte[] Picture;
    public TextMeshProUGUI debugdefou;
    Texture2D image;
    public string imageKey;
}
