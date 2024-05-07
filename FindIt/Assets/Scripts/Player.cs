using UnityEngine;

public class Player : MonoBehaviour
{
    public int ID;
    public GameObject PlayerAvatar,AvatarChild,cameraChild;
    public GameObject hatChild;
    public string PlayerName;
    public int score;
    public int hatIndex = -1;
    public int avatarIndex = -1;
    public int cameraIndex = -1;
    public RandomAvatar.CharacterToChose CharacterToChose;

    public static Player Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void SetAvatar()
    {
        GameObject avatarplayer = Instantiate(PlayerAvatar, Vector2.zero, Quaternion.identity, GameObject.FindGameObjectWithTag("MenuParent").transform);
        //avatarplayer = avatarplayer.GetComponent<RandomAvatar>()._hatSprites[hatIndex];
    }
}
