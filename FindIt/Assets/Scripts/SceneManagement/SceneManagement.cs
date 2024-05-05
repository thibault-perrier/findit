using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject takePhoto;
    public void TakePhoto()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            //takePhoto.SetActive(true);
        }
    }
    public void GetPhoto()
    {
        //SceneManager.LoadScene("DevroomPhoneUpdated");
    }
}
