using Unity.Netcode;
using UnityEngine;

public class DataTransfer : NetworkBehaviour
{
    public GameObject[] players;
    public SceneManagement sceneManagement;
    public NetworkVariable<bool> haveStart;
    public GameManager gameManager;

    private bool hasTakePhoto = false;
    void Update()
    {
        if(haveStart.Value && !hasTakePhoto)
        {
            players = GameObject.FindGameObjectsWithTag("Player");

            if(Application.platform == RuntimePlatform.Android)
            {
                hasTakePhoto = true;
                sceneManagement.TakePhoto();
            }
        }
    }
    
    
}
