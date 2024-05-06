using System;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{

    public static PanelManager Instance;



    public enum panelsNames
    {
        CreateRoom, RevealPicture, WaitingScreen, AttribPoints, RevealPrompt, Transition, Classement, Credits, ParameterPC, AvatarCreation, EnterCode, SelectServ, TakePicture, WritingText, VotePanel, SettingsParameter
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

    public void DisplayPanelPC(panelsNames name)
    {
        if(Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            foreach(var panelObject in panelsPCDict)
            {
                if(panelObject.Value.GetComponent<AnimationHandler>() != null)
                    panelObject.Value.GetComponent<AnimationHandler>().StartOut();
            }
            if(panelsPCDict[name].GetComponent<AnimationHandler>() != null)
                panelsPCDict[name].GetComponent<AnimationHandler>().StartIn();
        }
    }
    
    public void DisplayPanelTel(panelsNames name)
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            foreach (var panelObject in panelsTelDict)
            {
                if(panelObject.Value.GetComponent<AnimationHandler>() != null)
                    panelObject.Value.GetComponent<AnimationHandler>().StartOut();
            }
            if(panelsTelDict[name].GetComponent<AnimationHandler>() != null)
                panelsTelDict[name].GetComponent<AnimationHandler>().StartIn();
        }
    }

    public void UnDisplayPanelTel(panelsNames name)
    {
        if(panelsTelDict[name].GetComponent<AnimationHandler>() != null)
            panelsTelDict[name].GetComponent<AnimationHandler>().StartOut();
    }
    
    public void UnDisplayPanelPC(panelsNames name)
    {
        if(panelsPCDict[name].GetComponent<AnimationHandler>() != null)
            panelsPCDict[name].GetComponent<AnimationHandler>().StartOut();
    }

    public void DisplayParameter()
    {
        panelsPCDict[panelsNames.ParameterPC].SetActive(!panelsPCDict[panelsNames.ParameterPC].activeSelf);
    }
}
