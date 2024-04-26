using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoteManager : MonoBehaviour
{
    [SerializeField] private GameObject originalVotePrefab;
    public List<GameObject> votes = new List<GameObject>();

    private void Start()
    {
        //CreateVoteButton();
    }
    private void CreateVoteButton()
    {
        print(GameManager.AllPicture.Count);
        for (int i = 0; i < GameManager.AllPicture.Count; i++)
        {
            GameObject newVoteImage = Instantiate(originalVotePrefab);
            newVoteImage.GetComponent<SelectScript>().PlayerNumber = i;
            votes.Add(newVoteImage);
        }
    }
}
