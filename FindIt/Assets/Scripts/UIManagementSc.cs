using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;


public class UIManagementSc : MonoBehaviour
{
    [Header("UI GameObject")]
    [SerializeField] private GameObject ParameterUI;
    [SerializeField] private GameObject SelectServUI;
    [SerializeField] private GameObject EnterCodeUI;
    [SerializeField] private GameObject AvatarCreateUI;
    [SerializeField] private GameObject WaitingUI;
    [SerializeField] private GameObject CreditsUI;
    [SerializeField] private GameObject CreateRoomUI;
    [SerializeField] private GameObject TransitionPCUI;
    [SerializeField] private GameObject ParametreButton;
    
    [Header("Player Info")]
    [SerializeField] private GameObject NameOfTheServ;
    [SerializeField] private GameObject Avatar;
    [SerializeField] private GameObject PlayerName;
    [SerializeField] private Player_ScriptableObject PlayerScriptableObjectPrefab;
    [SerializeField] float transitionSpeed;


    // [HideInInspector]
    public List<Player_ScriptableObject> PlayerList = new List<Player_ScriptableObject>();

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
        AvatarCreateUI.SetActive(true);
        EnterCodeUI.SetActive(false);
    }

    public void CreateAvatar() 
    {
        WaitingUI.SetActive(true);
        AvatarCreateUI.SetActive(false);
        Player_ScriptableObject Player = Instantiate(PlayerScriptableObjectPrefab);
        Player.ID = PlayerList.Count;
        PlayerList.Add(Player);
        Player.PlayerAvatar = Avatar;
        Player.PlayerName = PlayerName.GetComponent<TextMeshProUGUI>().text;
        PlayerCreated?.Invoke();
        GameStarted = true;
    }

    public void Crédits() 
    {
        ParameterUI.SetActive(!ParameterUI.activeSelf);
        ParametreButton.SetActive(!ParametreButton.activeSelf);
        CreditsUI.SetActive(!CreditsUI.activeSelf);
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
        
        if (TransitionPCUI && Input.anyKeyDown)
        {
            if(Application.platform == RuntimePlatform.Android)
            {
                print("android"); 
                NetworkHolder.Instance.JoinRandomRoom();
                TransitionPCUI.GetComponent<Animator>().SetBool("titleOut", true);
                TransitionPCUI.GetComponent<Animator>().SetBool("FailedToJoinServer", false);
                
            }
            else
            {
                NetworkHolder.Instance.JoinRandomRoom();
                TransitionPCUI.GetComponent<Animator>().SetBool("titleOut", true);
            }
        }
    }

    private void Update()
    {
        TransitionTitleToCreteServ();
    }
}
