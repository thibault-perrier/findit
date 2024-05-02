using UnityEngine;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization;

public class Test : MonoBehaviour
{
    public TcpClient client;
    public NetworkStream stream;


    private byte[] SerializeData(byte[] data)
    {
        return data;
    }

    private byte[] DeserializeData(byte[] data)
    {
        return data;
    }

    public void SendData(byte[] data)
    {
        byte[] bytes = SerializeData(data);
        stream.Write(bytes, 0, bytes.Length);
    }

    public void ReceiveData()
    {
        byte[] buffer = new byte[4096];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        byte[] receivedData = DeserializeData(buffer);
        // Process received data
    }

    public void ConnectToServer(string ipAddress, int port)
    {
        client = new TcpClient();
        client.Connect(ipAddress, port);
        stream = client.GetStream();
    }

    private void DisconnectFromServer()
    {
        if (stream != null)
            stream.Close();
        if (client != null)
            client.Close();
    }

    private void OnDestroy()
    {
        DisconnectFromServer();
    }
}