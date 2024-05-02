using UnityEngine;
using UnityEngine.UI;

public class SelectScript : MonoBehaviour
{
    public Texture2D currentImage;
    public int totalVote;
    [HideInInspector] public bool Selected = false;

    public int PlayerNumber;
    Image votedImage;
    public int IDVote;
    private void Awake()
    {
        votedImage = GetComponentInChildren<Image>();
    }

    public void SelectSelf()
    {
        UnselectAll();
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
    public void UnselectAll()
    {
        foreach(GameObject btn in GameObject.FindGameObjectsWithTag("VoteButton"))
        {
            btn.GetComponent<SelectScript>().Deselect();
        }
    }
}