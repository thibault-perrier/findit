using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine.UI;
using System.Net;
using System.Net.Sockets;

public class RandomScript : MonoBehaviour
{
    private bool pcAssigned;
    [Header("Client")]
        [SerializeField] private InputField ip;

        [Header("Host")]
        [SerializeField]private InputField _roomName;
        [SerializeField]public string ipAddress;
        [SerializeField]public UnityTransport transport;
        [SerializeField]public Text codeRoom;
    [SerializeField] Text ipAddressText;


    void Start()
    {
        ipAddress = "0.0.0.0";
        SetIpAddress(); // Set the Ip to the above address
                        //Client
        if (Application.platform == RuntimePlatform.Android)
        {
            Debug.Log("On Android");
        }
        //Host
        else if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            ipAddress = "0.0.0.0";
            SetIpAddress(); // Set the Ip to the above address
            Debug.Log("On Windows");
        }
    }

    private void CheckAllIp()
    {
        for (int y = 0; y < 255; y++)
        {
            for (int i = 0; i < 255; i++)
            {
                ipAddress = "192.168.1." + i.ToString();
            }
        }
    }
    // To Host a game
    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
        GetLocalIPAddress();
    }

    // To Join a game
    public void StartClient()
    {
        ipAddress = ip.text;
        SetIpAddress();
        NetworkManager.Singleton.StartClient();
    }

    /* Gets the Ip Address of your connected network and
	shows on the screen in order to let other players join
	by inputing that Ip in the input field */
    // ONLY FOR HOST SIDE 
    public string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                ipAddressText.text = ip.ToString();
                ipAddress = ip.ToString();
                return ip.ToString();
            }
        }
        throw new System.Exception("No network adapters with an IPv4 address in the system!");
    }

    /* Sets the Ip Address of the Connection Data in Unity Transport
	to the Ip Address which was input in the Input Field */
    // ONLY FOR CLIENT SIDE
    public void SetIpAddress()
    {
        transport = NetworkManager.Singleton.GetComponent<UnityTransport>();
        transport.ConnectionData.Address = ipAddress;
    }

}

