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
using UnityEngine.SceneManagement;

public class LanManager : MonoBehaviour
{
    [Header("Client")]
    [SerializeField] private GameObject JoinRoom;
    [SerializeField]private List<string> _server = new List<string>();
    //Network
    [SerializeField] private InputField ip;


    [Header("Host")]
    [SerializeField] private GameObject CreateRoom;
    //Network
    [SerializeField]private InputField _roomName;
    [SerializeField]public string ipAddress;
    [SerializeField]public UnityTransport transport;
    [SerializeField]public Text codeRoom;
    [SerializeField]Text ipAddressText;


    //IP
    [SerializeField] private int[] _broadcast = new int[32];
    [SerializeField] private int[] _pIP = new int[32];
    [SerializeField] private int[] _mask = new int[32];
    [SerializeField] private string _broacastIP ="";

    void Start()
    {
        //Client
        if (Application.platform == RuntimePlatform.Android)
        {
            JoinRoom.SetActive(true);
            TryConnection();
        }
        //Host
        else if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            CreateRoom.SetActive(true);
            TryConnection();
            ipAddress = "0.0.0.0";
            SetIpAddress(); // Set the Ip to the above address
        }
    }
    private void GetSubnetMaskBinaries()
    {
        NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

        foreach (NetworkInterface netInterface in interfaces)
        {
            // Ne récupère que les interfaces réseau connectées
            if (netInterface.OperationalStatus == OperationalStatus.Up)
            {
                IPInterfaceProperties ipProps = netInterface.GetIPProperties();
                foreach (UnicastIPAddressInformation unicastAddr in ipProps.UnicastAddresses)
                {
                    // Vérifie si l'adresse IP est IPv4
                    if (unicastAddr.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        uint subnetMaskInt = BitConverter.ToUInt32(unicastAddr.IPv4Mask.GetAddressBytes(), 0);
                        string mask = Convert.ToString(subnetMaskInt, 2);
                        for (int i = 0; i < mask.Length; i++)
                        {
                            _mask[i] = Convert.ToInt32(mask[i]) - '0';
                        }
                        return;
                    }
                }
            }
        }
    }
    private void GetIPBinaries()
    {
        // Obtient les octets de l'adresse IP
        byte[] ipBytes = IPAddress.Parse(GetLocalIPAddress()).GetAddressBytes();

        int index = 0;
        // Copie chaque octet dans le tableau d'entiers
        for (int i = 0; i < ipBytes.Length; i++)
        {
            string binaryByte = Convert.ToString(ipBytes[i], 2).PadLeft(8, '0');

            foreach (char c in binaryByte)
            {
                _pIP[index++] = c - '0'; // Convertit le caractère '0' ou '1' en entier
            }
        }
    }
    private void GetBroadcast()
    {
        for (int i = 0 ; i < _broadcast.Length ; i++)
        {
            if (_mask[i] == 0)
            {
                _broadcast[i] = 1;
            }
            else
            {
                _broadcast[i] = _pIP[i];
            }
        }
        
        for (int i = 0; i < _broadcast.Length; i += 8)
        {
            string octet = "";
            for (int y = 0; y < 8; y++)
            {
                octet += _broadcast[i + y].ToString();
            }//extrait un octet binaire
            int decimalValue = Convert.ToInt32(octet, 2); // Convertir l'octet binaire en décimal
            _broacastIP += decimalValue;
            if (i != 24) // Si ce n'est pas le dernier octet, ajouter un point
            {
                _broacastIP += '.';
            }
        }
    }
    private void CheckIp()
    {
        GetSubnetMaskBinaries();
        GetIPBinaries();
        GetBroadcast();
    }

    
    private void TryConnection()
    {
        CheckIp();
        
        
    }


    public void GetAllPlayerInRoom()
    {
        Debug.Log(NetworkManager.Singleton.ConnectedClients.Count);
    }
    // To Host a game
    public void StartHost()
    {
        NetworkManager.Singleton.StartServer();
        GetLocalIPAddress();
    }

    // To Join a game
    public void StartClient()
    {
        ipAddress = ip.text;
        SetIpAddress();
        NetworkManager.Singleton.StartClient();
       // SceneManager.LoadScene("DevroomPhoneUpdated");
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
        throw new Exception("No network adapters with an IPv4 address in the system!");
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

