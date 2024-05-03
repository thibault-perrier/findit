using Photon.Pun;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PhoneCamera : MonoBehaviour
{

    private bool _camAvailable;
    private WebCamTexture _backCam;
    private Texture _defaultBackground;

    public RawImage background;
    public AspectRatioFitter fit;

    [SerializeField] private GameObject _confirmPhoto;
    [SerializeField] RawImage picture;
    [SerializeField] TextMeshProUGUI debugText;

    //Timer
    [SerializeField] Image Timer;
    public float maxTime = 30f;
    float timeLeft;

    public bool randomFacing;
    public Texture2D pictureForDisplay;
    public GameObject panelPicture;
    public DataTransfer dataTransfer;
    public GameObject player;
    public Texture2D texture;

    string filename = "";
    public byte[] Download;

    public PhotonView phview;
    public RawImage pictureDeFou;
    private void Start()
    {
        _confirmPhoto.SetActive(false);
        Timer.fillAmount = 1;
        timeLeft = maxTime;
        _defaultBackground = background.texture;
        if(Application.platform == RuntimePlatform.Android)
        {
            GetCam();
        }
    }
    private void GetCam()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        bool frontFacing = true;
        if (randomFacing)
        {
            frontFacing = (Random.Range(0, 2) == 0) ? true : false;
        }
        if (devices.Length == 0)
        {
            Debug.Log("No Camera Detected");
            _camAvailable = false;
            return;
        }
        for (int i = 0; i < devices.Length; i++)
        {
            if (frontFacing != devices[i].isFrontFacing)
            {
                _backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            }
        }
        if (_backCam == null)
        {
            Debug.Log("Unable to find back camera");
            return;
        }
        _backCam.Play();
        background.texture = _backCam;

        _camAvailable = true;
    }
    private void Update()
    {
        if (!_camAvailable)
        {
            return;
        }

        float ratio = (float)_backCam.width / (float)_backCam.height;
        fit.aspectRatio = ratio;

        float scaleY = _backCam.videoVerticallyMirrored ? -1.0f : 1.0f;
        background.rectTransform.localScale = new Vector3(1.25f, 1.25f, 0);
        picture.rectTransform.localScale = new Vector3(1, scaleY, 1);

        int orient = -_backCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
        picture.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
        if (panelPicture.activeSelf)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                Timer.fillAmount = timeLeft / maxTime;
            }
            else
                TakePhoto();
        }
    }
    public void TakePhoto()
    {
        StartCoroutine(TakePicture());
    }
    IEnumerator TakePicture()
    {
        yield return new WaitForEndOfFrame();

        Texture2D photo = new Texture2D(_backCam.width, _backCam.height);
        photo.SetPixels(_backCam.GetPixels());
        photo.Apply();
        Texture2D squarePhoto = CropToSquare(photo);
        _confirmPhoto.SetActive(true);
        timeLeft = maxTime; // remet le timer a zero quand on prend une photo.
        picture.texture = squarePhoto;
        S_SoundsManager.Instance.PlaySFX(S_SoundsManager.TypesOfSFX.PICTURETAKEN);

        byte[] bytes = squarePhoto.EncodeToJPG();
        Download = bytes;
        phview.RpcSecure("RPC_SharePhoto",RpcTarget.Others,true,Download);
        filename = /*System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + */ "_photo.png";
        string filePath = System.IO.Path.Combine(Application.persistentDataPath, filename);
        System.IO.File.WriteAllBytes(filePath, bytes);
        //showImage.Instance.ShowImage();
    }
    private Texture2D CropToSquare(Texture2D source)
    {
        int size = Mathf.Min(source.width, source.height);
        int offsetX = (source.width - size) / 2;
        int offsetY = (source.height - size) / 2;

        Color[] pixels = source.GetPixels(offsetX, offsetY, size, size);
        Texture2D squareTexture = new Texture2D(size, size);
        squareTexture.SetPixels(pixels);
        squareTexture.Apply();
        texture = squareTexture;
        return squareTexture;
    }

    [PunRPC]
    private void RPC_SharePhoto(byte[] photoByte)
    {
        texture.LoadImage(photoByte);
        pictureDeFou.texture = texture;
    }

}