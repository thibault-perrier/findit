using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;

    [Header("Slider references :")]
    [SerializeField] Slider mainSoundVolumeSlider;
    [SerializeField] Slider musicsVolumeSlider;
    [SerializeField] Slider SFXVolumeSlider;
    /*
    [Header("Graphism references :")]
    [SerializeField] Toggle m_fullScreenToggle;
    [SerializeField] TMP_Dropdown m_resolutionDropDown;


    [Header("References :")]
    public GameObject m_BackButton;
    public GameObject m_BackToMainMenuButton;
    */
    // Sound variables
    float mainVolume = 0.5f;
    float musicVolume = 0.5f;
    float sfxVolume = 0.5f;
    /*
    // Graphic variables
    bool m_isOnFullScreen = false;
    int m_resolutionValue = 1;
    */
    public float MainVolume { get { return mainVolume; } }
    public float MusicVolume { get { return musicVolume; } }
    public float SFXVolume { get { return sfxVolume; } }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        DontDestroyOnLoad(transform);

        // Link volume sliders to their respective functions
        mainSoundVolumeSlider.onValueChanged.AddListener(delegate { OnMainSoundVolumeChanged(); });
        musicsVolumeSlider.onValueChanged.AddListener(delegate { OnMusicSoundVolumeChanged(); });
        SFXVolumeSlider.onValueChanged.AddListener(delegate { OnSFXSoundVolumeChanged(); });
        /*
        // Link graphic's UI to their respective functions
        m_fullScreenToggle.onValueChanged.AddListener(delegate { OnFullScreenChanged(); });
        m_resolutionDropDown.onValueChanged.AddListener(delegate { OnResolutionChanged(m_resolutionDropDown.value); });
        */
    }

    private void Start()
    {
        // Set sound's value to be equal to our variables
        mainSoundVolumeSlider.value = mainVolume;
        musicsVolumeSlider.value = musicVolume;
        SFXVolumeSlider.value = sfxVolume;
        /*
        // Set graphic's value to be equal to our variables
        if (Screen.fullScreen)
        {
            m_fullScreenToggle.isOn = true;
            m_isOnFullScreen = true;
        }
        else
        {
            m_fullScreenToggle.isOn = false;
            m_isOnFullScreen = false;
        }

        m_resolutionDropDown.value = m_resolutionValue;
        */
    }

    // -- Sound part -- //

    void OnMainSoundVolumeChanged()
    {
        mainVolume = mainSoundVolumeSlider.value;
    }

    void OnMusicSoundVolumeChanged()
    {
        musicVolume = musicsVolumeSlider.value;
    }

    void OnSFXSoundVolumeChanged()
    {
        sfxVolume = SFXVolumeSlider.value;
    }
    /*
    // -- Graphic part -- //

    void OnFullScreenChanged()
    {
        if (m_isOnFullScreen)
        {
            Screen.SetResolution(Screen.width, Screen.height, FullScreenMode.Windowed);
            m_isOnFullScreen = false;
        }
        else
        {
            Screen.SetResolution(Screen.width, Screen.height, FullScreenMode.ExclusiveFullScreen);
            m_isOnFullScreen = true;
        }
    }

    void OnResolutionChanged(int _index)
    {
        switch (_index)
        {
            // HD Resolution
            case 0:

                m_fullScreenToggle.isOn = false;

                Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
                m_isOnFullScreen = false;
                break;

            // Full HD Resolution
            case 1:

                m_fullScreenToggle.isOn = false;

                Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
                m_isOnFullScreen = false;
                break;

            // Ultra HD 4K Resolution
            case 2:

                m_fullScreenToggle.isOn = false;

                Screen.SetResolution(3840, 2160, FullScreenMode.Windowed);
                m_isOnFullScreen = false;
                break;

            // Ultra HD 8K Resolution
            case 3:

                m_fullScreenToggle.isOn = false;

                Screen.SetResolution(7680, 4320, FullScreenMode.Windowed);
                m_isOnFullScreen = false;
                break;

            default:
                Debug.LogError("ERROR ! Case not planned. UNITY IS STOPPED");
                Debug.Break();
                break;
        }
    }
    */
}