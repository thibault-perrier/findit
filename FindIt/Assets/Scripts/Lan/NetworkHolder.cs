using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class NetworkHolder : MonoBehaviourPunCallbacks,IPunObservable
{
    #region hosting
    [Header("Client")]
    [SerializeField] private GameObject JoinRoomUi;
    public InputField roomNameForJoin;

    [Header("Host")]
    [SerializeField] private GameObject CreateRoomUi;
    public InputField roomNameForCreate;
    #endregion
    #region UI management
    [SerializeField] public GameObject takephoto;
    #endregion
    bool haveStart = false;
    public PhotonView phview;
    #region create and join room
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
        PhotonNetwork.CreateRoom(roomNameForCreate.text);
        print("create");
    }
    public override void OnConnectedToMaster()
    {
        print("ready");
    }
    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print(PhotonNetwork.CurrentRoom.PlayerCount);
    }
    #endregion
    #region Error and Disconnect
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
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
