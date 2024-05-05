using Photon.Pun;
using System.Collections;
using System.Linq;
using System.Security.Cryptography;
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

    [SerializeField] private PhotonView phview;

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
        if (PhotonNetwork.CurrentRoom != null && PhotoManager.Instance.listeScore.Sum()+1 >= PhotonNetwork.CurrentRoom.PlayerCount)
        {
            phview.RPC("RPC_ResetVote", RpcTarget.All);
        }
    }

    public void StartChangeRightScene()
    {
        if(ChangeRightSceneCoroutine == null)
            ChangeRightSceneCoroutine = StartCoroutine(ChangeRightScene());
    }

    private IEnumerator ChangeRightScene()
    {
        int iteration = 0;
        yield return new WaitForSeconds(phoneCamera.maxTime);
        
        if(Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            phview.RPC("RPC_TakePicture", RpcTarget.Others);
        }
        yield return new WaitForSeconds(1);
        while ((PhotonNetwork.CurrentRoom.PlayerCount != PhotoManager.Instance.AllPicture.Count - 1) && iteration < 100)
        {
            takePhoto.SetActive(false);

            if (Application.platform == RuntimePlatform.Android)
            {
                clientGame.SetActive(true);
                if (!hasPassedAndroidCreation)
                {
                    print("sendbutton active");
                    sendButton.SetActive(true);
                    VoteClient.CreateVoteButton();
                    hasPassedAndroidCreation = true;
                }

            }
            else if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
            {
                RoundManager.Instance.isVoting = true;
                hostGame.SetActive(true);
                RevealPrompt.SetActive(false);
            }
            ChangeRightSceneCoroutine = null;
            iteration++;
        }
        
        yield break;
    }

    [PunRPC]
    private void RPC_ResetVote()
    {
        hasPassedAndroidCreation = false;
    }
    [PunRPC]
    private void RPC_TakePicture()
    {
        PhoneCamera.Instance.TakePhoto();
    }
}