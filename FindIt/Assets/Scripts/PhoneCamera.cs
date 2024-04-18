using UnityEngine;
using UnityEngine.UI;

public class PhoneCamera : MonoBehaviour
{
    private bool _camAvailable;
    private WebCamTexture _backCam;
    private Texture _defaultBackground;

    public RawImage background;
    public AspectRatioFitter fit;
    private void Start()
    {
        _defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        if(devices.Length == 0)
        {
            Debug.Log("No Camera Detected");
            _camAvailable = false;
            return;
        }
        for(int i = 0; i < devices.Length; i++)
        {
            if(devices[i].isFrontFacing)
            {
                 _backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);

            }
        }

        if(_backCam == null)
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
        if(!_camAvailable)
        {
            return;
        }

        float ratio = (float)_backCam.width / (float)_backCam.height;
        fit.aspectRatio = ratio;

        float scaleY = _backCam.videoVerticallyMirrored ? -1.0f : 1.0f;
        background.rectTransform.localScale = new Vector3(1, scaleY, 1);

        int orient = -_backCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }
}
