using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;


public class UIManagementPC : MonoBehaviour
{
    [Header("UI GameObject")]
    [SerializeField] private GameObject ParameterUI;
    [SerializeField] private GameObject TitleUI;
    [SerializeField] private GameObject CreateServUI;
    [SerializeField] private GameObject ParametreServUI;
    [SerializeField] private GameObject WaitingRoomUI;
    [SerializeField] private GameObject PromptRevealUI;
    [SerializeField] private GameObject PictureRevealUI;
    [SerializeField] private GameObject PersonRevealUI;
    [SerializeField] private GameObject VictoiryUI;
    [SerializeField] private GameObject AttribPointUI;
    [SerializeField] private GameObject CreditsUI;
    
    [Header("Player Info")]
    [SerializeField] private GameObject NameOfTheServ;
    [SerializeField] private GameObject Avatar;
    [SerializeField] private GameObject PlayerName;
    [SerializeField] private Player_ScriptableObject PlayerScriptableObjectPrefab;
    
    // [HideInInspector]
    public List<Player_ScriptableObject> PlayerList = new List<Player_ScriptableObject>();
    
    [Header("Audio")]
    [SerializeField] private AudioMixer GeneralMixer;
    
    private string ipServToConnect;

    public static UIManagementPC Instance;

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

    public void Crédits() 
    {
        ParameterUI.SetActive(false);
        CreditsUI.SetActive(true);
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

    public void TransitionTitleToCreteServ() 
    {
        if (Input.anyKey)
        {
            
        }
    }
}
