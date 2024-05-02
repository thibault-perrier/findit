using JetBrains.Annotations;
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
    public PhotoManager gameManager;
    public bool isVoted = false;
    public int AllPictureCount;
    public PhotonView phViewClient;
    public int idVote= 0;
    public List<int> score = new List<int>();
    public PhotoManager photoManager;

    private void Start()
    {
        CreateVoteButton();
    }
    public void CreateVoteButton()
    {
        for (int i = 0; i < gameManager.AllPicture.Count+1; i++)
        {
            GameObject newVoteImage = Instantiate(originalVotePrefab);
            newVoteImage.name = i.ToString();
            newVoteImage.transform.SetParent(voteParent.transform);
            newVoteImage.GetComponentInChildren<TextMeshProUGUI>().text = (i+1).ToString();
            votes.Add(newVoteImage);
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
                    vote.GetComponent<SelectScript>().IDVote++;
                    idVote = vote.GetComponent<SelectScript>().IDVote;
                    phViewClient.RPC("AddVoteRpc", RpcTarget.Others);
                    isVoted = true;
                    break;
                }
            }
        }
        
    }

    [PunRPC]
    public void AddVoteRpc()
    {
        foreach (GameObject vote in votes)
        {
            print(vote.name +"    :    "+ vote.GetComponent<SelectScript>().IDVote);
        }
    }
}
