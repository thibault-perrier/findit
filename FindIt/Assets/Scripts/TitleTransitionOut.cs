using UnityEngine;

public class TitleTransitionOut : MonoBehaviour
{
    public GameObject title;
    public GameObject roomCreation;
    bool failed = false;

    private void Start()
    {
        NetworkHolder.Instance.FailedToJoinRoom.AddListener(IsFailedJoinServer);
    }
    public void TransitionOut()
    {
        roomCreation.SetActive(true);
        title.SetActive(false);
    }

    public void IsFailedJoinServer()
    {
        print("failure 2");
        failed = true;
    }

    public void FailJoinServer()
    {
        if (!failed)
        {
            PanelManager.Instance.DisplayPanelTel(PanelManager.panelsNames.AvatarCreation);
        }
        else
        {
            GetComponent<Animator>().SetBool("FailedToJoinServer", true);
            GetComponent<Animator>().SetBool("titleOut", false);
        }
    }

    public void ResetJoinServer()
    {
        GetComponent<Animator>().SetBool("FailedToJoinServer", false);
        GetComponent<Animator>().SetBool("titleOut", false);
        failed = false;
    }
}
