using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public int roundIndex;

    public void StartRound()
    {
        roundIndex = 0;
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
        //Lancer le classement
    }
}
