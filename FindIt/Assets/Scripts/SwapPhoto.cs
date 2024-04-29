using System.Collections;
using UnityEngine;

public class SwapPhoto : MonoBehaviour
{
    [SerializeField]float timeSwap;
    [SerializeField] GameObject takePhoto;
    [SerializeField] GameObject vote;
    public Picture picture;
    public bool pickPicture;

    [SerializeField] private GameObject hostGame;
    [SerializeField] private GameObject clientGame;
    public void StartChange()
    { 
        StartCoroutine(ChangeScene());
    }
    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(timeSwap);
        takePhoto.SetActive(false);

        if (Application.platform == RuntimePlatform.Android)
        {
            clientGame.SetActive(true);
        }
        else if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            hostGame.SetActive(true);
        }

        picture.InstantiateButtonVote();
    }
}
