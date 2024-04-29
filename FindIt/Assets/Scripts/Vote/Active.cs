using UnityEngine;

public class Active : MonoBehaviour
{
    public static Active Instance;

    [SerializeField] private GameObject hostGame;
    [SerializeField] private GameObject clientGame;
    [SerializeField] private SwapPhoto _swapPhoto;

    private void Awake()
    {
        //_swapPhoto = GetComponent<SwapPhoto>();
    }
    private void Update()
    {
        if (_swapPhoto.pickPicture)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                ActiveClientScene();
            }
            else if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
            {
                ActiveHostScene();
            }
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
