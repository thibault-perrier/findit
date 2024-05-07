using Photon.Pun;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClassementManager : MonoBehaviour
{
    [SerializeField] Image avatarPlayer1;
    [SerializeField] Image avatarPlayer2;
    [SerializeField] Image avatarPlayer3;

    [SerializeField] TextMeshProUGUI pseudoPlayer1;
    [SerializeField] TextMeshProUGUI pseudoPlayer2;
    [SerializeField] TextMeshProUGUI pseudoPlayer3;


    List<int> players = new List<int>();

    public static ClassementManager Instance;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    private void OnEnable()
    {
        InitializeRank();
    }

    public List<int> GetThreeFirst(List<int> list)
    {
        List<int> listCopy = new List<int>();
        listCopy = list.ToList();
        List<int> indices = new List<int>();
        List<int> sorted = new List<int>();
        sorted = list.ToList();
        sorted.Sort();
        sorted.Reverse();
        for(int i = 0; i < sorted.Count; i++)
        {
            print("sorted : " + listCopy.IndexOf(sorted[i]));
            indices.Add(list.IndexOf(sorted[i]));
            listCopy.Remove(list.IndexOf(sorted[i]));
        }
        
        return indices;
    }

    public void InitializeRank()
    {
        for(int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount - 1; i++)
        {
            players.Add(i);
        }

        pseudoPlayer1.text = "player n°" + (int)(GetThreeFirst(ScoreManager.Instance.GetScore())[0]+1);
        pseudoPlayer2.text = "player n°" + (int)(GetThreeFirst(ScoreManager.Instance.GetScore())[1]+1);
        pseudoPlayer3.text = "player n°" + (int)(GetThreeFirst(ScoreManager.Instance.GetScore())[2]+1);

    }
}
