using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HostVote : MonoBehaviour
{
    [SerializeField] private GameObject originalVotePrefab;
    [SerializeField] private GameObject voteParent;
    public List<GameObject> votes = new List<GameObject>();
    private int _index;

    public GameManager gameManager;

    private int _limite;
    private void Start()
    {
        _limite = 5 /*gameManager.AllPicture.Count*/;
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < _limite / 2 ; j++)
            {
                GameObject newVoteImage = Instantiate(originalVotePrefab, voteParent.transform.position + new Vector3(j * 850, -i * 900, 0), Quaternion.identity);
                newVoteImage.transform.parent = voteParent.transform;
                votes.Add(newVoteImage);
                newVoteImage.GetComponentInChildren<RawImage>().texture = gameManager.AllPicture[_index];       
                _index++;
            }
        }
    }
}
