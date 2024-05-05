using System;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{

    public static PanelManager Instance;



    public enum panelsNames
    {
        CreateRoom, RevealPicture, WaitingScreen, AttribPoints, RevealPrompt, Transition, Classement, Credits, Parameter, AvatarCreation, EnterCode, SelectServ, TakePicture, WritingText, VotePanel, SettingsParameter
    }
    [Serializable]
    public struct panelStruct
    {
        public panelsNames name;
        public GameObject panel;
    }

    public panelStruct[] panelsPC;
    public panelStruct[] panelsTel;
    public Dictionary<panelsNames, GameObject> panelsPCDict = new Dictionary<panelsNames, GameObject>();
    public Dictionary<panelsNames, GameObject> panelsTelDict = new Dictionary<panelsNames, GameObject>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        foreach (panelStruct panelObject in panelsPC)
        {
            panelsPCDict[panelObject.name] = panelObject.panel;
        }
        foreach (panelStruct panelObject in panelsTel)
        {
            panelsTelDict[panelObject.name] = panelObject.panel;
        }
    }

    private void Start()
    {
        if(Application.platform == RuntimePlatform.Android)
            panelsPCDict[panelsNames.Parameter].SetActive(false);
        else
            panelsPCDict[panelsNames.Parameter].SetActive(false);
    }

    public void DisplayPanelPC(panelsNames name)
    {
        if(Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            foreach(var panelObject in panelsPCDict)
            {
                panelObject.Value.SetActive(false);
            }
            panelsPCDict[name].SetActive(true);
        }
    }
    
    public void DisplayPanelTel(panelsNames name)
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            foreach (var panelObject in panelsTelDict)
            {
                panelObject.Value.SetActive(false);
            }
            panelsTelDict[name].SetActive(true);
        }
    }

    public void DisplayParameter()
    {
        panelsPCDict[panelsNames.Parameter].SetActive(!panelsPCDict[panelsNames.Parameter].activeSelf);
    }
}
