using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhotoManager : MonoBehaviour
{
    public List<Texture2D> AllPicture = new List<Texture2D>();
    public byte[] Picture;
    public TextMeshProUGUI debugdefou;
    public string imageKey;
    public List<int> listeScore = new List<int>();
    public Dictionary<int,int> Point = new Dictionary<int,int>();

    public void AddScoreToAllPicture()
    {
        foreach(int i in listeScore)
        {
            if(Point.ContainsKey(i+1))
            {
                Point[i+1]++; 
            }
            else
            {
                Point.Add(i+1,1) ;
            }
        }
        print(Point[0]);
    }
}
