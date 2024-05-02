using System.Collections;
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

    public static SwapPhoto Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void StartChangeRightScene()
    {
        StartCoroutine(ChangeRightScene());
    }

    private IEnumerator ChangeRightScene()
    {
        yield return new WaitForSeconds(phoneCamera.maxTime + 1);

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