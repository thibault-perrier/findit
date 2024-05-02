using UnityEngine;

public class Picture : MonoBehaviour
{
    public static Picture Instance;
    //public LanManager lanManager;
    private int nbPlayer;
    [SerializeField] private GameObject _prefabsVotes;
    [SerializeField] private Transform _transformParent;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    public void InstantiateButtonVote()
    {
        //nbPlayer = lanManager.GetAllPlayerInRoom();
        for (int i = 0; i <= nbPlayer; i++)
        {
            Instantiate(_prefabsVotes, Vector3.zero,Quaternion.identity,_transformParent);
        }
    }
    public void Vote(int nbPlayer)
    {
        foreach(Transform imageVote in transform)
        {
            imageVote.GetComponent<SelectScript>().Deselect();
        }
    }
}
