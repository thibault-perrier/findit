using UnityEngine;

public class Picture : MonoBehaviour
{
    public static Picture Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public void Vote(int nbPlayer)
    {
        foreach (Transform imageVote in transform)
        {
            imageVote.GetComponent<SelectScript>().Deselect();
        }
    }
}