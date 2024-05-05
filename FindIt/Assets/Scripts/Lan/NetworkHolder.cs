using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NetworkHolder : MonoBehaviourPunCallbacks,IPunObservable
{
    #region hosting
    [Header("Client")]
    [SerializeField] private GameObject JoinRoomUi;
    [SerializeField] private GameObject WaitingRoomUI;

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

    #region create and join room
    bool joined = false;
    void Start()
    {
        createRoomBtn.SetActive(false);
        PhotonNetwork.ConnectUsingSettings();
        //Client
        if (Application.platform == RuntimePlatform.Android)
        {
            JoinRoomUi.SetActive(true);
        }
        //Host
        else if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            CreateRoomUi.SetActive(true);
        }
    }
    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 8;
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
        if(Application.platform == RuntimePlatform.Android)
        {
            JoinRoomUi.SetActive(false);
            WaitingRoomUI.SetActive(true);
        }
        joined = true;
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        GameObject joueur = Instantiate(player);
        joueur.name = (PhotonNetwork.CurrentRoom.PlayerCount-1).ToString();
        joueur.GetComponent<Player>().ID = int.Parse(name) - 1;
        
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
        FailedToJoinRoom?.Invoke();
        print("failure");
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("disconnect with reason {0}", cause);
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        print("new player");
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



