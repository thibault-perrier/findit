using Photon.Pun;
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
    private void OnEnable()
    {
        _limite = PhotonNetwork.CurrentRoom.PlayerCount - 1;

        foreach(Transform voteButtonTransform in voteParent.transform)
        {
            Destroy(voteButtonTransform.gameObject);
            
        }
        _index = 0;
        print(_limite);
        for (int j = 0; j < PhotonNetwork.CurrentRoom.PlayerCount-1; j++)
        {
            GameObject newVoteImage = Instantiate(originalVotePrefab, voteParent.transform.position, Quaternion.identity, voteParent.transform);
            votes.Add(newVoteImage);
            newVoteImage.GetComponentInChildren<RawImage>().texture = gameManager.AllPicture[_index];
            newVoteImage.GetComponentInChildren<TextMeshProUGUI>().text = (j + 1).ToString();
            newVoteImage.name = (j + 1).ToString() ;
            _index++;
        }
    }
}