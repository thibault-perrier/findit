using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class SelectScript : MonoBehaviour
{
    public Texture2D currentImage;
    public int totalVote;
    [HideInInspector] public bool Selected = false;
    [HideInInspector] public VoteManager voteManager;

    public int PlayerNumber;
    Image votedImage;


    public bool isVoted = false;
    [SerializeField] private Transform VoteParent;
    [SerializeField] private Image confirButton;
    private void Awake()
    {
        votedImage = GetComponentInChildren<Image>();
    }

    public void SelectSelf()
    {
        if (!isVoted)
        {
            Picture.Instance.Vote(PlayerNumber);
            print(Selected);
            Selected = !Selected;
            if (Selected)
            {
                votedImage.color = Color.gray;
            }
            else
            {
                votedImage.color = Color.white;
            }
        }
    }

    public void Deselect()
    {
        Selected = false;
        votedImage.color = Color.white;
    }

    public void Confirm()
    {
        if (!isVoted)
        {
            foreach (GameObject vote in voteManager.votes)
            {
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
