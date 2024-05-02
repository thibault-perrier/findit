using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhotoManager : MonoBehaviour
{
    int Id = -1;
    public List<Texture2D> AllPicture = new List<Texture2D>();
    public byte[] Picture;
    public TextMeshProUGUI debugdefou;
    Texture2D image;
    public string imageKey;
    public Dictionary<int, int> ScoreById = new Dictionary<int, int>();
    
}
