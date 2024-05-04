using Photon.Pun;
using System.Linq;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [HideInInspector] public int roundIndex;
    [SerializeField] float promptTime = 10;
    [SerializeField] float voteTime = 5;

    public bool isVoting = false;

    public PhotonView phview;

    public static RoundManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        PanelManager.Instance.DisplayPanelPC(PanelManager.panelsNames.Transition);
    }

    public void StartRound()
    {
        roundIndex = 1;
        print(roundIndex);
        PanelManager.Instance.DisplayPanelPC(PanelManager.panelsNames.RevealPrompt);
    }

    public void NextRound()
    {
        print("Entering next round");
        roundIndex++;
        print(roundIndex + " / " + RoomSettings.Instance.maxRound);
        if (roundIndex > RoomSettings.Instance.maxRound)
        {
            EndRound();
            return;
        }

        foreach (GameObject voteButton in VoteClient.Instance.votes.ToList())
        {
            print("destroying one image");
            Destroy(voteButton);
        }
        VoteClient.Instance.votes.Clear();
        PhotoManager.Instance.AllPicture.Clear();
        phview.RPC("RPC_Reset", RpcTarget.All);
        PanelManager.Instance.DisplayPanelPC(PanelManager.panelsNames.RevealPrompt);
    }

    public void EndRound()
    {
        PanelManager.Instance.DisplayPanelPC(PanelManager.panelsNames.Classement);
    }

    private void Update()
    {
        FinishVote();
    }

    public void FinishVote()
    {
        if (isVoting && (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer) &&  PhotoManager.Instance.listeScore.Count >= 1 && PhotoManager.Instance.listeScore.Count+1 >= PhotonNetwork.CurrentRoom.PlayerCount)
        {
            //Calcul score
            PhotoManager.Instance.listeScore.Clear();
            PanelManager.Instance.DisplayPanelPC(PanelManager.panelsNames.AttribPoints);
            isVoting = false;
        }
    }

    [PunRPC]
    private void RPC_Reset()
    {
        
        SwapPhoto.Instance.StartChangeRightScene();
        if (Application.platform == RuntimePlatform.Android)
        {
            PhoneCamera.Instance.StartCam();
            PhoneCamera.Instance.photoNotTake = false;
            PanelManager.Instance.DisplayPanelTel(PanelManager.panelsNames.TakePicture);

        }
        foreach (GameObject voteImage in VoteClient.Instance.votes.ToList())
        {
            Destroy(voteImage);
        }
        VoteClient.Instance.votes.Clear();
        VoteClient.Instance.isVoted = false;
    }
}
