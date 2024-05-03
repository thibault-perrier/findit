using Photon.Pun;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class VoteClient : MonoBehaviour
{
    [SerializeField] private GameObject originalVotePrefab;
    [SerializeField] private GameObject voteParent;
    public List<GameObject> votes = new List<GameObject>();
    [SerializeField] private SelectScript select;
    [SerializeField] private Image confirButton;
    public bool isVoted = false;
    public int AllPictureCount;
    public PhotonView phViewClient;
    public int idVote= 0;
    public List<int> score = new List<int>();
    public PhotoManager photoManager;

    
    public void CreateVoteButton()
    {
        print(photoManager.AllPicture.Count);
        if (voteParent.GetComponentInChildren<Transform>().childCount < PhotonNetwork.CurrentRoom.PlayerCount )
        {
            for (int i = 0; i < photoManager.AllPicture.Count + 1; i++)
            {

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
                vote.GetComponentInChildren<Image>().color = Color.gray;

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
