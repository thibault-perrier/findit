using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Netcode;

public class GameManager : NetworkBehaviour
{
    NetworkObject networkObject;
    int Id = -1;
    public NetworkVariable<List<byte[]>> AllPicture = new NetworkVariable<List<byte[]>>();
    public List<Texture2D> FinalPictureList = new List<Texture2D>();
    public byte[] Picture;
    public TextMeshProUGUI debugdefou;
    Texture2D image;

    private void Start()
    {
        networkObject = GetComponent<NetworkObject>();
    }
    private void Update()
    {
        if(Id == -1)
        {
            Id = (int)networkObject.OwnerClientId;
            print(Id);
        }
    }

}
