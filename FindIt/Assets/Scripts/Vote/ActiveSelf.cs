using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSelf : MonoBehaviour
{
    public static ActiveSelf Instance;

    [SerializeField] private GameObject hostGame;
    [SerializeField] private GameObject clientGame;

    private void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            ActiveClientScene();
        }
        else if(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            ActiveHostScene();
        }
    }
    public void ActiveClientScene()
    {
        clientGame.SetActive(true);
    }
    public void ActiveHostScene()
    {
        hostGame.SetActive(true);
    }
}
