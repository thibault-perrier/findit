using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class PhotoManager : MonoBehaviour
{
    public List<Texture2D> AllPicture = new List<Texture2D>();
    public TextMeshProUGUI debugdefou;
    public string imageKey;
    public List<int> listeScore = new List<int>();
    public Dictionary<int,int> Point = new Dictionary<int,int>();

    public static PhotoManager Instance;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    public void InitializeListScore()
    {
        listeScore.Clear();
        for(int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount-1 ; i++)
        {
            listeScore.Add(0);
        }
    }

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
        
    }
}
