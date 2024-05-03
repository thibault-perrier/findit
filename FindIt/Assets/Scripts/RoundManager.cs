using System.Collections;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [HideInInspector] public int roundIndex;
    [SerializeField] float promptTime = 10;

    private void Start()
    {
        PanelManager.Instance.DisplayPanelPC(PanelManager.panelsNames.Transition);
    }

    public void StartRound()
    {
        roundIndex = 0;
        PanelManager.Instance.DisplayPanelPC(PanelManager.panelsNames.RevealPrompt);
    }

    public void NextRound()
    {
        roundIndex++;
        if (roundIndex >= RoomSettings.Instance.maxScore)
        {
            EndRound();
        }
    }

    public void EndRound()
    {
        PanelManager.Instance.DisplayPanelPC(PanelManager.panelsNames.Classement);
    }
}
