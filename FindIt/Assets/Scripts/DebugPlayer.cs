using System.Collections.Generic;
using UnityEngine;

public class DebugPlayer : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] List<Vector3> positions;

    int positionIndex;

    private void Start()
    {
        UIManagementSc.Instance.PlayerCreated.AddListener(CreatePlayerDebug);
    }

    private void CreatePlayerDebug()
    {
        GameObject playerGameObject =  Instantiate(player, transform);
        playerGameObject.GetComponent<RectTransform>().localPosition = positions[positionIndex];
        positionIndex++;
        print("Player created");
    }
}
