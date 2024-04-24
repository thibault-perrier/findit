using UnityEngine;
using System;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine.UI;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using TMPro;

public class TestJoinPlayer : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public NetworkManager networkManager;
    public LanManager lanManager;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro.text = "Player = 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (lanManager.isHost)
            textMeshPro.text = "Players = " + NetworkManager.Singleton.ConnectedClients.Count.ToString();
    }
}
