using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Netcode;
using UnityGoogleDrive;
using System.Collections;

public class GameManager : NetworkBehaviour
{
    NetworkObject networkObject;
    int Id = -1;
    public List<Texture2D> AllPicture = new List<Texture2D>();
    public byte[] Picture;
    public TextMeshProUGUI debugdefou;
    Texture2D image;
    public string imageKey;

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

    public IEnumerator PullToDrive()
    {
        var request = GoogleDriveFiles.Download(imageKey);
        yield return request.Send();
        image.LoadImage(request.ResponseData.Content);
        image.Apply();
        AllPicture.Add(image);
    }

}
