using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class S_SoundsManager : MonoBehaviour
{
    public static S_SoundsManager Instance;

    // References
    [Header("References")]
    [SerializeField] private AudioSource _musicsPlayerAudioSource;
    [SerializeField] public AudioSource _sfxPlayerAudioSource;

    SettingsManager settingsManager;

    // Getters Setters

    public AudioSource _MusicsPlayerAudioSource { get { return _musicsPlayerAudioSource; } }
    public AudioSource _SFXPlayerAudioSource { get { return _sfxPlayerAudioSource; } }

    [Header("Sounds")]
    [SerializeField] private AllMusics _allMusics;
    [SerializeField] private AllSFX _allSFX;

    public enum TypesOfMusics
    {
        // Menu
        MAIN_MENU,

        // Picture turn
        PROMPT,

        // Vote
        VOTE
    }

    public enum TypesOfSFX
    {
        // Players's actions
        JOIN,
        LEAVE,
        CREATEROOM,
        PICTURETAKEN,
        VOTED,

        // UIs
        BUTTON_PRESSED,

        //Game Flow
        WOOSH1,
        WOOSH2,
        PAGETURN,
        VOTEBEGIN,
        ENDGAME,
        REVEAL,
        ADDSCORE,

    }

    // Structs
    [Serializable]
    struct AllMusics
    {
        [Header("Menus :")]
        public List<AudioClip> _mainMenu;

        [Header("Prompt :")]
        public List<AudioClip> _prompt;

        [Header("Vote :")]
        public List<AudioClip> _vote;
    }

    [Serializable]
    struct AllSFX
    {
        [Header("Player actions :")]
        public AudioClip[] _join;
        public AudioClip[] _leave;
        public AudioClip[] _createRoom;
        public AudioClip[] _pictureTaken;
        public AudioClip[] _voted;

        [Header("UIs :")]
        public AudioClip[] _ButtonPressed;

        [Header("Game Flow :")]
        public AudioClip[] _woosh1;
        public AudioClip[] _woosh2;
        public AudioClip[] _pageTurn;
        public AudioClip[] _voteBegin;
        public AudioClip[] _endGame;
        public AudioClip[] _reveal;
        public AudioClip[] _addScore;
    }

    // -- Methods -- //
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }

    void Start()
    {
        settingsManager = SettingsManager.Instance;
        
    }

    /// <summary> Return a random AudioClip of the type of Music wanted </summary>
    public List<AudioClip> ReturnMusic(TypesOfMusics _typesOfMusics)
    {
        // NOTE : If you are here because of a Unity error (not in default) that's surely because :
        // The music is not define. Go in SoundManager GameObject to define it in the Inspector. 

        switch (_typesOfMusics)
        {
            // Menus
            case TypesOfMusics.MAIN_MENU:
                return _allMusics._mainMenu;

            //  Prompt
            case TypesOfMusics.PROMPT:
                return _allMusics._prompt;

            // Vote
            case TypesOfMusics.VOTE:
                return _allMusics._vote;

            default:
                Debug.LogError($"The type of SFX {_typesOfMusics} is not planned in the switch statement.");
                return null;
        }
    }

    /// <summary> Randomize the music list given and play it endlessly /!\ It's a Coroutine /!\ </summary>
    public IEnumerator PlayMusicEndlessly(TypesOfMusics _typesOfMusics)
    {
        List<AudioClip> musicList = ReturnMusic(_typesOfMusics);

        while (true)
        {
            // Generation of a random number
            System.Random _randomNumber = new();

            // Shuffling the musicList
            for (int i = musicList.Count - 1; i > 0; i--)
            {
                // Get a random emplacement in the list
                int randomIndex = _randomNumber.Next(0, i + 1);

                // Change the position of the music into a random one in the list without making a temporary variable
                (musicList[randomIndex], musicList[i]) = (musicList[i], musicList[randomIndex]);
            }

            // Playing the music list entierely
            for (int i = 0; i < musicList.Count; i++)
            {
                _musicsPlayerAudioSource.clip = musicList[i];

                _musicsPlayerAudioSource.Play();

                _musicsPlayerAudioSource.volume = settingsManager.MainVolume * settingsManager.MusicVolume;

                yield return new WaitForSecondsRealtime(musicList[i].length);
            }
        }
    }

    public void StopMusic()
    {
        _musicsPlayerAudioSource.Stop();
    }

    /// <summary> Return a random AudioClip of the type of SFX wanted </summary>
    public AudioClip ReturnSFX(TypesOfSFX _typeOfSFX)
    {
        // NOTE : If you are here because of a Unity error (not in default) that's surely because :
        // The SFX is not define. Go in SoundManager GameObject to define it in the Inspector. 

        switch (_typeOfSFX)
        {
            // Players's actions
            case TypesOfSFX.JOIN:
                return _allSFX._join[Random.Range(0, _allSFX._join.Length)];

            case TypesOfSFX.LEAVE:
                return _allSFX._leave[Random.Range(0, _allSFX._leave.Length)];

            case TypesOfSFX.CREATEROOM:
                return _allSFX._createRoom[Random.Range(0, _allSFX._createRoom.Length)];

            case TypesOfSFX.PICTURETAKEN:
                return _allSFX._pictureTaken[Random.Range(0, _allSFX._pictureTaken.Length)];

            case TypesOfSFX.VOTED:
                return _allSFX._voted[Random.Range(0, _allSFX._voted.Length)];

            //UI
            case TypesOfSFX.BUTTON_PRESSED:
                return _allSFX._ButtonPressed[Random.Range(0, _allSFX._ButtonPressed.Length)];

            //Game Flow
            case TypesOfSFX.WOOSH1:
                return _allSFX._woosh1[Random.Range(0, _allSFX._woosh1.Length)];

            case TypesOfSFX.WOOSH2:
                return _allSFX._woosh2[Random.Range(0, _allSFX._woosh2.Length)];

            case TypesOfSFX.PAGETURN:
                return _allSFX._pageTurn[Random.Range(0, _allSFX._pageTurn.Length)];

            case TypesOfSFX.VOTEBEGIN:
                return _allSFX._voteBegin[Random.Range(0, _allSFX._voteBegin.Length)];

            case TypesOfSFX.ENDGAME:
                return _allSFX._endGame[Random.Range(0, _allSFX._endGame.Length)];

            case TypesOfSFX.REVEAL:
                return _allSFX._reveal[Random.Range(0, _allSFX._reveal.Length)];

            case TypesOfSFX.ADDSCORE:
                return _allSFX._addScore[Random.Range(0, _allSFX._addScore.Length)];

            default:
                Debug.LogError($"The type of SFX {_typeOfSFX} is not planned in the switch statement.");
                return null;
        }
    }

    /// <summary> Play a random SFX of the type of SFX you wanted, Used to pass a type of SFX in a button by int </summary>
    public void PlaySFXInButton(int _typesOfSFX)
    {
        AudioClip test = ReturnSFX((TypesOfSFX)_typesOfSFX);
        _sfxPlayerAudioSource.gameObject.active=true;
        Debug.Log(_sfxPlayerAudioSource.gameObject.active);
        _sfxPlayerAudioSource.PlayOneShot(test,1);//, settingsManager.MainVolume * settingsManager.SFXVolume);
        Debug.Log(_sfxPlayerAudioSource.isActiveAndEnabled);
        Debug.Log(_sfxPlayerAudioSource.enabled);
        Debug.Log(_sfxPlayerAudioSource.gameObject.active);
        
    }

    /// <summary> Play a random SFX of the type of SFX you wanted /// </summary>
    public void PlaySFX(TypesOfSFX _typesOfSFX)
    {
        _sfxPlayerAudioSource.PlayOneShot(ReturnSFX(_typesOfSFX));//, settingsManager.MainVolume * settingsManager.SFXVolume);
    }
}
