using Photon.Pun;
using System.Collections;
using UnityEngine;

public class SwapPhoto : MonoBehaviour
{
    [SerializeField] GameObject takePhoto;
    [SerializeField] GameObject createRoom;
    public bool pickPicture;

    public PhoneCamera phoneCamera;

    [SerializeField] private GameObject hostGame;
    [SerializeField] private GameObject clientGame;
    [SerializeField] private GameObject RevealPrompt;
    [SerializeField] private GameObject sendButton;

    public static SwapPhoto Instance;
    public VoteClient VoteClient;
    bool hasPassedAndroidCreation = false;

    Coroutine ChangeRightSceneCoroutine;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (PhotonNetwork.CurrentRoom != null && PhotoManager.Instance.listeScore.Count >= 1 && PhotoManager.Instance.listeScore.Count+1 >= PhotonNetwork.CurrentRoom.PlayerCount)
        {
            hasPassedAndroidCreation = false;
        }
    }

    public void StartChangeRightScene()
    {
        if(ChangeRightSceneCoroutine == null)
            ChangeRightSceneCoroutine = StartCoroutine(ChangeRightScene());
    }

    private IEnumerator ChangeRightScene()
    {
        yield return new WaitForSeconds(phoneCamera.maxTime + 1);

        takePhoto.SetActive(false);
        if (Application.platform == RuntimePlatform.Android)
        {
            clientGame.SetActive(true);
            if (!hasPassedAndroidCreation)
            {
                print("sendbutton active");
                sendButton.SetActive(true);
                VoteClient.CreateVoteButton();
                hasPassedAndroidCreation=true;
            }

        }
        else if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            RoundManager.Instance.isVoting = true;
            hostGame.SetActive(true);
            RevealPrompt.SetActive(false);
        }
        ChangeRightSceneCoroutine = null;
        yield break;
    }
}