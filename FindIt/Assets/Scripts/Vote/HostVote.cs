using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HostVote : MonoBehaviour
{
    [SerializeField] private GameObject originalVotePrefab;
    [SerializeField] private GameObject voteParent;
    public List<GameObject> votes = new List<GameObject>();
    private int _index;

    public PhotoManager gameManager;

    [SerializeField]private int _limite;
    private void Start()
    {
            _limite = gameManager.AllPicture.Count;
            for (int j = 0; j < _limite; j++)
            {
                
                GameObject newVoteImage = Instantiate(originalVotePrefab, voteParent.transform.position, Quaternion.identity, voteParent.transform);
                votes.Add(newVoteImage);
                newVoteImage.GetComponentInChildren<RawImage>().texture = gameManager.AllPicture[_index];
                newVoteImage.GetComponentInChildren<TextMeshProUGUI>().text = (j+1).ToString();
                _index++;
            }
    }
}