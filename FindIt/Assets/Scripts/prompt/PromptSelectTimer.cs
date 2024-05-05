using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PromptSelectTimer : MonoBehaviour
{
    [SerializeField] Image Timer;
    [SerializeField] GameObject Game;
    public float maxTime = 30f;
    float timeLeft;
    public static bool GameStarted = false;

    private void Start()
    {
        Timer.fillAmount = 1;
        timeLeft = maxTime;
    }
    void Update()
    {
        if (UIManagementSc.GameStarted)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                Timer.fillAmount = timeLeft / maxTime;
            }
            else
            {
                Game.SetActive(true);
                GameStarted = true;
            }
        }
    }
}
