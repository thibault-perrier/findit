using Photon.Pun;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class VoteClient : MonoBehaviour
{
    [SerializeField] private GameObject originalVotePrefab;
    [SerializeField] private GameObject voteParent;
    public List<GameObject> votes = new List<GameObject>();
    [SerializeField] private SelectScript select;
    public bool isVoted = false;
    public int AllPictureCount;
    public PhotonView phViewClient;
    public int idVote= 0;
    public List<int> score = new List<int>();
    public PhotoManager photoManager;

    public static VoteClient Instance;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }


    public void CreateVoteButton()
    {
        print(photoManager.AllPicture.Count);
        
        if (voteParent.GetComponentInChildren<Transform>().childCount < PhotonNetwork.CurrentRoom.PlayerCount)
        {
            for (int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount - 1; i++)
            {
                print("vote image created");
                GameObject newVoteImage = Instantiate(originalVotePrefab);
                newVoteImage.name = i.ToString();
                newVoteImage.transform.SetParent(voteParent.transform);
                newVoteImage.GetComponentInChildren<TextMeshProUGUI>().text = (i + 1).ToString();
                votes.Add(newVoteImage);
            }
        }

    }
    public void Confirm()
    {
        if (!isVoted)
        {
            foreach (GameObject vote in votes)
            {
                if (vote.GetComponent<SelectScript>().Selected)
                {
                    idVote = int.Parse(vote.name);
                    phViewClient.RPC("AddVoteRpc", RpcTarget.All,idVote);
                    isVoted = true;
                    break;
                }
            }
        }
        
    }

    [PunRPC]
    public void AddVoteRpc(int nbVote)
    {
        photoManager.listeScore.Add(nbVote);
    }
}
