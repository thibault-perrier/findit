using Photon.Pun;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.Events;
using TMPro;

public class NetworkHolder : MonoBehaviourPunCallbacks,IPunObservable
{
    #region hosting
    [Header("Client")]
    [SerializeField] private GameObject JoinRoomUi;

    [Header("Host")]
    [SerializeField] private GameObject CreateRoomUi;
    #endregion
    #region UI management
    [SerializeField] public GameObject takephoto;
    #endregion
    bool haveStart = false;
    public PhotonView phview;
    #region create and join room
    bool joined = false;
    void Start()
    {
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
        PhotonNetwork.CreateRoom(null);
        print("create");
    }
    public override void OnConnectedToMaster()
    {
        print("ready");
    }
    public void JoinRandomRoom()
    {
        if(!joined)
            PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinedRoom()
    {
        joined = true;
        base.OnJoinedRoom();
        print(PhotonNetwork.CurrentRoom.PlayerCount);
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
        takephoto.SetActive(true);
    }
    [PunRPC]
    public void changeSceneSwapPhotoRpc()
    {
        SwapPhoto.Instance.StartChangeRightScene();
    }
}
