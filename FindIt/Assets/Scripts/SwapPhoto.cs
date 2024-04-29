using System.Collections;
using UnityEngine;

public class SwapPhoto : MonoBehaviour
{
    [SerializeField] GameObject takePhoto;
    public Picture picture;
    public bool pickPicture;

    [SerializeField] private GameObject hostGame;
    [SerializeField] private GameObject clientGame;

    public void ChangeRightScene()
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
