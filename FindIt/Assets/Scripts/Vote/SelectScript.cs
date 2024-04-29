using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class SelectScript : MonoBehaviour
{
    public Texture2D currentImage;
    public int totalVote;
    [HideInInspector] public bool Selected = false;

    public NetworkVariable<int> voteForHost;

    public int PlayerNumber;
    Image votedImage;

    private void Awake()
    {
        votedImage = GetComponentInChildren<Image>();
    }

    public void SelectSelf()
    {
        Picture.Instance.Vote(PlayerNumber);
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

    public void Deselect()
    {
        Selected = false;
        votedImage.color = Color.white;
    }
}
