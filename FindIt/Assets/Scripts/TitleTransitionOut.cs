using UnityEngine;

public class TitleTransitionOut : MonoBehaviour
{
    public GameObject title;
    public GameObject roomCreation;

    public void TransitionOut()
    {
        roomCreation.SetActive(true);
        title.SetActive(false);
    }
}
