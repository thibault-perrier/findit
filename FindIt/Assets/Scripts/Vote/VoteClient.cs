using System.Collections.Generic;
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
    private void Start()
    {
        CreateVoteButton();
    }
    private void CreateVoteButton()
    {
        for (int i = 0; i < gameManager.AllPicture.Count; i++)
        {
            GameObject newVoteImage = Instantiate(originalVotePrefab);
            newVoteImage.transform.SetParent(voteParent.transform);
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
                    isVoted = true;
                    break;
                }
            }
            confirButton.GetComponent<Image>().color = Color.red;
        }
    }
}
