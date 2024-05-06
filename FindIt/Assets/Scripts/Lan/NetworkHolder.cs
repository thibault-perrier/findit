using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NetworkHolder : MonoBehaviourPunCallbacks,IPunObservable
{
    #region hosting
    [Header("Client")]
    [SerializeField] private GameObject JoinRoomUi;
    [SerializeField] private GameObject WaitingRoomUI;
    [SerializeField] private GameObject failedToJoin;
    [SerializeField] private TextMeshProUGUI numberPlayer;

    [Header("Host")]
    [SerializeField] private GameObject CreateRoomUi;
    #endregion
    #region UI management
    [SerializeField] public GameObject takephoto;
    #endregion
    bool haveStart = false;
    public PhotonView phview;
    public GameObject player;
    public GameObject createRoomBtn;
    public GameObject startGameBtn;

    #region create and join room
    bool joined = false;
    void Start()
    {
        createRoomBtn.SetActive(false);
        PhotonNetwork.ConnectUsingSettings();
        //Client
        if (Application.platform == RuntimePlatform.Android)
        {
            PanelManager.Instance.DisplayPanelTel(PanelManager.panelsNames.EnterCode);
        }
        //Host
        else if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            PanelManager.Instance.DisplayPanelTel(PanelManager.panelsNames.CreateRoom);
        }
        startGameBtn.SetActive(false);
    }
    public void CreateRoom()
    {
        numberPlayer.gameObject.SetActive(true);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = RoomSettings.Instance._maxPlayer;
        PhotonNetwork.CreateRoom(null, roomOptions);
        print("create");
    }
    public override void OnConnectedToMaster()
    {
        createRoomBtn.SetActive(true);
        print("ready");
    }
    public void JoinRandomRoom()
    {
        if(!joined)
        {
            PhotonNetwork.JoinRandomRoom();
        }
    }

    public override void OnJoinedRoom()
    {
        joined = true;
        PanelManager.Instance.DisplayPanelTel(PanelManager.panelsNames.AvatarCreation);
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        numberPlayer.text = "Nombre de joueur minimum : " + (PhotonNetwork.CurrentRoom.PlayerCount - 1) + " / 3";
        if((PhotonNetwork.CurrentRoom.PlayerCount - 1) >= 3)
        {
            startGameBtn.SetActive(true);
        }
        GameObject joueur = Instantiate(player);
        joueur.name = PhotonNetwork.CurrentRoom.PlayerCount.ToString();
        joueur.GetComponent<Player>().ID = PhotonNetwork.CurrentRoom.PlayerCount - 1;
        
    }
    #endregion
    #region Error and Disconnect

    public static NetworkHolder Instance;
    public UnityEvent FailedToJoinRoom;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        failedToJoin.SetActive(true);
        FailedToJoinRoom?.Invoke();
        print("failure");
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("disconnect with reason {0}", cause);
    }
    #endregion


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(haveStart);
        }
        else
        {
            haveStart = (bool)stream.ReceiveNext();
        }
    }

    public void StartGame()
    {
        phview.RPC("changeSceneTakePhotoRpc", RpcTarget.Others);
        phview.RPC("changeSceneSwapPhotoRpc", RpcTarget.All);
    }

    [PunRPC]
    public void changeSceneTakePhotoRpc()
    {
        print("take photo panel activated");
        PanelManager.Instance.DisplayPanelTel(PanelManager.panelsNames.TakePicture);
    }
    [PunRPC]
    public void changeSceneSwapPhotoRpc()
    {
        SwapPhoto.Instance.StartChangeRightScene();
    }
}



