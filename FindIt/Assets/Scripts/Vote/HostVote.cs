using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HostVote : MonoBehaviour
{
    [SerializeField] private GameObject originalVotePrefab;
    [SerializeField] private GameObject voteParent;
    public List<GameObject> votes = new List<GameObject>();
    private int _index;

    private int _limite;

    private void Start()
    {
        _limite = 5 /*(int)GameManager.AllPicture.Count*/;
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j <  _limite / 2 ; j++)
            {
                if(i == 1)
                {
                    _limite += _limite % 2;
                }
                GameObject newVoteImage = Instantiate(originalVotePrefab, voteParent.transform.position + new Vector3(j * 850, -i * 900, 0), Quaternion.identity);
                newVoteImage.transform.parent = voteParent.transform;
                votes.Add(newVoteImage);
                //newVoteImage.GetComponentInChildren<RawImage>().texture = GameManager.AllPicture[_index];       
                _index++;
            }
        }
        foreach (GameObject voteImage in votes)
        {
            //voteImage.GetComponent<SelectScript>().totalVote = voteImage.GetComponent<SelectScript>().voteForHost.Value;
            voteImage.GetComponentInChildren<TextMeshProUGUI>().text = voteImage.GetComponent<SelectScript>().totalVote.ToString();
            
        }
    }
}
