using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class showImage : MonoBehaviour
{
    [SerializeField] private RawImage _origineImage;
    [SerializeField] private Transform TransformParent;
    public GameManager gameManager;

    public static showImage Instance;
    public void ShowImage()
    {
        for (int i = 0; i < gameManager.AllPicture.Count; i++)
        {
            RawImage newImage = Instantiate(_origineImage, TransformParent.transform.position + new Vector3(0,i * 10,0), Quaternion.identity);
            newImage.AddComponent<NetworkObject>();
            newImage.transform.parent = TransformParent;
            //newImage.GetComponent<RawImage>().texture = gameManager.AllPicture[i];
        }
    }
}
