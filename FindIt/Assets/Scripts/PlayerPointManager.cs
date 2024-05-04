using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPointManager : MonoBehaviour
{
    [SerializeField] Image avatarImage;
    [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] Image tookPicture;

    public static PlayerPointManager Instance;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    public void SetPlayerPoint(Sprite avatarImageToSet, Sprite tookPictureToSet, int pointsToSet)
    {
        avatarImage.sprite = avatarImageToSet;
        tookPicture.sprite = tookPictureToSet;
        pointsText.text = "+ " + pointsToSet.ToString() + " points";
    }
}
