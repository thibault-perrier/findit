using UnityEngine;

public class SwapPhoto : MonoBehaviour
{
    [SerializeField] GameObject takePhoto;
    [SerializeField] GameObject createRoom;
    public Picture picture;
    public bool pickPicture;

    public PhoneCamera phoneCamera;

    [SerializeField] private GameObject hostGame;
    [SerializeField] private GameObject clientGame;


    private void Update()
    {
        ChangeRightScene();
    }
    public void ChangeRightScene()
    {
        if (phoneCamera.photoNotTake)
        {
            takePhoto.SetActive(false);
            if (Application.platform == RuntimePlatform.Android)
            {
                clientGame.SetActive(true);
            }
            else if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
            {
                hostGame.SetActive(true);
            }
        }
    }
}
