using System;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class UIManagementSc : MonoBehaviour
{
    [Header("UI GameObject")]
    [SerializeField] private GameObject ParameterUI;
    [SerializeField] private GameObject SelectServUI;
    [SerializeField] private GameObject EnterCodeUI;
    [SerializeField] private GameObject AvataCreateUI;
    [SerializeField] private GameObject WaitingUI;
    [SerializeField] private GameObject CreditsUI;
    
    [Header("Player Info")]
    [SerializeField] private GameObject NameOfTheServ;
    [SerializeField] private GameObject Avatar;
    [SerializeField] private GameObject PlayerName;
    [SerializeField] private GameObject PlayerScriptableObjectPrefab;
    
    // [HideInInspector]
    public List<GameObject> PlayerList = new List<GameObject>();
    
    [Header("Audio")]
    [SerializeField] private AudioMixer GeneralMixer;
    
    private string ipServToConnect;

    public static UIManagementSc Instance;

    public UnityEvent PlayerCreated;

    public static bool GameStarted = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

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
        GameObject Player = Instantiate(PlayerScriptableObjectPrefab);
        //Player.ID = PlayerList.Count;
        PlayerList.Add(Player);
        Player.GetComponent<Player>().PlayerAvatar = Avatar;
        Player.GetComponent<Player>().PlayerName = PlayerName.GetComponent<InputField>().text;
        PlayerCreated?.Invoke();
        GameStarted = true;
    }

    public void Crédits() 
    {
        ParameterUI.SetActive(false);
    }

    public void UpdateGeneralAudio(float volume) {
        GeneralMixer.SetFloat("Master", volume);
    }
    
    public void UpdateMusicAudio(float volume) {
        GeneralMixer.SetFloat("Music", volume);
    }
    
    public void UpdateSFXAudio(float volume) {
        GeneralMixer.SetFloat("SFX", volume);
    }
}
