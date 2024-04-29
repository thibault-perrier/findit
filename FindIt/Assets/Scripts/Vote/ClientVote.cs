using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientVote : MonoBehaviour
{
    
    [SerializeField] private GameObject originalVotePrefab;
    [SerializeField] private GameObject voteParent;
    public List<GameObject> votes = new List<GameObject>();

    [SerializeField] private SelectScript select;

    [SerializeField] private Image confirButton;

    private int _index;
    public bool isVoted = false;

    private void Start()
    {
        CreateVoteButton();
    }
    private void CreateVoteButton()
    {
        //print(GameManager.AllPicture.Count);
        for (int i = 0; i < 5 /*GameManager.AllPicture.Count*/; i++)
        {
            GameObject newVoteImage = Instantiate(originalVotePrefab);
            newVoteImage.GetComponent<SelectScript>().PlayerNumber = i;
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
                    vote.GetComponent<SelectScript>().totalVote++;
                    vote.GetComponent<SelectScript>().voteForHost.Value = vote.GetComponent<SelectScript>().totalVote++;
                    isVoted = true;
                    break;
                }
            }
            confirButton.GetComponent<Image>().color = Color.red;
        }
    }
}
