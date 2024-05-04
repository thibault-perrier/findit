using Photon.Pun;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    List<int> scoreList = new List<int>();
    [SerializeField] GameObject playersParent;
    [SerializeField] GameObject playerPointPrefab;

    public static ScoreManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public int InitializeScore()
    {
        for(int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount-1; i++)
        {
            scoreList.Add(0);
        }

        return scoreList.Count;
    }

    public List<int> GetScore()
    {
        return scoreList;
    }

    public List<int> AddScoreToPlayer(int playerIndex,  int scoreToAdd)
    {
        if(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            scoreList[playerIndex] += scoreToAdd;
            for (int i = 0; i < scoreList.Count; i++)
            {
                print("player " + i + " : " + scoreList[i] + " points.");
            }
        }
        return scoreList;
    }

    public void InstantiatePlayerPoint(int amount, int scoreToAdd, List<int> maxIndices)
    {
        foreach(Transform playerPointInSpawned in playersParent.transform)
        {
            Destroy(playerPointInSpawned.gameObject);
        }
        for(int i = 0; i < amount; i++)
        {
            GameObject playerPointSpawned = Instantiate(playerPointPrefab, playersParent.transform);

            playerPointSpawned.GetComponent<PlayerPointManager>().SetPlayerPoint(null, Sprite.Create(PhotoManager.Instance.AllPicture[maxIndices[i]], new Rect(0, 0, PhotoManager.Instance.AllPicture[i].width, PhotoManager.Instance.AllPicture[i].height), new Vector2(0.5f, 0.5f)), scoreToAdd);
        }
    }
}
