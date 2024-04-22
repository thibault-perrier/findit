using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManagementSc : MonoBehaviour
{
    [SerializeField] private GameObject ParameterUI;
    [SerializeField] private GameObject SelectServUI;
    [SerializeField] private GameObject EnterCodeUI;
    [SerializeField] private GameObject AvataCreateUI;
    [SerializeField] private GameObject WaitingUI;
    [SerializeField] private GameObject CreditsUI;
    
    [SerializeField] private GameObject NameOfTheServ;
    [SerializeField] private GameObject Avatar;
    [SerializeField] private GameObject PlayerName;
    [SerializeField] private Player_ScriptableObject PlayerScriptableObjectPrefab;
    public List<Player_ScriptableObject> PlayerList = new List<Player_ScriptableObject>();
    
    private string ipServToConnect;

    public void Parameter() 
    {
        if (!ParameterUI.activeInHierarchy)
        {
            ParameterUI.SetActive(true);
        }
        else if (ParameterUI.activeInHierarchy)
        {
            ParameterUI.SetActive(false);
        }
    }

    public void ServSelected(GameObject ServObject) 
    {
            EnterCodeUI.SetActive(true);
            SelectServUI.SetActive(false);
            
            NameOfTheServ.GetComponent<TextMeshProUGUI>().text = ServObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;

            ipServToConnect = ServObject.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text;
    }

    public void ValidServCode(GameObject CodeServ) 
    {
        //Check if the code of the Server is the good with ipServToConnect and CodeServ
        //if good
        AvataCreateUI.SetActive(true);
        EnterCodeUI.SetActive(false);
    }

    public void CreateAvatar() 
    {
        WaitingUI.SetActive(true);
        AvataCreateUI.SetActive(false);
        Player_ScriptableObject Player = Instantiate(PlayerScriptableObjectPrefab);
        Player.ID = PlayerList.Count;
        PlayerList.Add(Player);
        Player.PlayerAvatar = Avatar;
        Player.PlayerName = PlayerName.GetComponent<TextMeshProUGUI>().text;
    }

    public void Crédits() 
    {
        ParameterUI.SetActive(false);
    }
}
