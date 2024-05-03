using System;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{

    public static PanelManager Instance;



    public enum panelsNames
    {
        CreateRoom, RevealPicture, WaitingScreen, AttribPoints, RevealPrompt, Transition, Classement, Credits, Parameter
    }
    [Serializable]
    public struct panelStruct
    {
        public panelsNames name;
        public GameObject panel;
    }

    public panelStruct[] panels;
    public Dictionary<panelsNames, GameObject> panelsDict = new Dictionary<panelsNames, GameObject>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        foreach (panelStruct panelObject in panels)
        {
            panelsDict[panelObject.name] = panelObject.panel;
        }
    }

    public void DisplayPanel(panelsNames name)
    {
        S_SoundsManager.Instance.PlaySFX(S_SoundsManager.TypesOfSFX.WOOSH1);
        foreach(var panelObject in panelsDict)
        {
            panelObject.Value.SetActive(false);
        }
        panelsDict[name].SetActive(true);
    }
}
