using UnityEngine;
using Unity.Netcode;
using TMPro;
public class Detecte : MonoBehaviour
{
    public TextMeshProUGUI nbPlayer;
    public NetworkManager NetworkManager;
    private void Update()
    {
        nbPlayer.text = NetworkManager.Singleton.ConnectedClients.Count.ToString();
    }
}
