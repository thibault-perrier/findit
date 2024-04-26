using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class DataTransfer : NetworkBehaviour
{
    public GameObject[] players;
    public SceneManagement sceneManagement;
    public NetworkVariable<bool> haveStart;
    public GameManager gameManager;
    void Update()
    {
        if(haveStart.Value)
        {
            players = GameObject.FindGameObjectsWithTag("Player");

            if(Application.platform == RuntimePlatform.Android)
            {
                sceneManagement.TakePhoto();
            }
        }
    }
    
    
}
