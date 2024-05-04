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

    private Color defaultColor;
    [SerializeField] Color selectedColor = new Color();

    private void Awake()
    {
        votedImage = GetComponentInChildren<Image>();
        defaultColor = votedImage.color;
    }

    private void OnEnable()
    {
        UnselectAll();
    }

    public void SelectSelf()
    {
        UnselectAll();
        Selected = true;
        if (Selected)
        {
            votedImage.color = selectedColor;
        }
        else
        {
            votedImage.color = defaultColor;
        }
    }

    public void Deselect()
    {
        Selected = false;
        votedImage.color = defaultColor;
    }
    public void UnselectAll()
    {
        foreach(GameObject btn in GameObject.FindGameObjectsWithTag("VoteButton"))
        {
            btn.GetComponent<SelectScript>().Deselect();
        }
    }
}