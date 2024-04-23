using UnityEngine;
using UnityEngine.UI;

public class SelectScript : MonoBehaviour
{
    public int PlayerNumber;
    [HideInInspector] public bool Selected = false;
    Image votedImage;

    private void Awake()
    {
        votedImage = GetComponentInChildren<Image>();
    }

    public void SelectSelf()
    {
        
        Picture.Instance.Vote(PlayerNumber);
        print(Selected);
        Selected = !Selected;
        if (Selected)
            votedImage.color = Color.gray;
        else
            votedImage.color = Color.white;
        
    }

    public void Deselect()
    {
        Selected = false;
        votedImage.color = Color.white;
    }
}
