using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomSettings : MonoBehaviour
{
    [SerializeField] private GameObject _settingsPanel;
    //maxPlayer
    [SerializeField] private Slider _maxPlayerSlider;
    [SerializeField] private TextMeshProUGUI _maxPlayerText;
    [SerializeField] private int _maxPlayer;
    //MaxScore
    [SerializeField] private Slider _maxScoreInput;
    [SerializeField] private TextMeshProUGUI _maxScoreText;
    [SerializeField] private int _maxScore;
    //Time by Round
    [SerializeField] private TextMeshProUGUI _timeByRoundText;
    [SerializeField] private float _timeByRound;
    [SerializeField] private int[] _timeByRoundPossibilities = new int[] { 5,10,15,20,30,40,50,60,75,90,105,120};
    [SerializeField] private int _index = 0;
    //GameMade
    [SerializeField] private Toggle _image;
    [SerializeField] private Toggle _text;
    [SerializeField] private bool _useImage,_useText;

    private void Start()
    {
        InitializeSettings();
    }
    private void InitializeSettings()
    {
        _settingsPanel.SetActive(false);
        _index = 0;
        _timeByRoundText.text = _timeByRoundPossibilities[_index].ToString();
        _maxScoreInput.value = 3;
        _maxScore = (int)_maxScoreInput.value;
        _maxPlayerSlider.value = 3;
        _maxPlayer = (int)_maxPlayerSlider.value;
    }
    public void DysplaySettings()
    {
        _settingsPanel.SetActive(!_settingsPanel.activeSelf);
    }
    public void ChangeMaxPlayer()
    {
        _maxPlayerText.text = _maxPlayerSlider.value.ToString();
        _maxPlayer = (int)_maxPlayerSlider.value;
    }
    public void ChangeMaxScore()
    {
        _maxScoreText.text = _maxScoreInput.value.ToString();
        _maxScore = (int)_maxScoreInput.value;
    }
    public void AddTime()
    {
        if(_index<_timeByRoundPossibilities.Length-1)
        {
            _index ++;
        }
        _timeByRoundText.text = _timeByRoundPossibilities[_index].ToString();
    }
    public void RemoveTime()
    {
        if( _index>0 )
        {
            _index--;
        }
        _timeByRoundText.text = _timeByRoundPossibilities[_index].ToString();
    }
    public void GetGameMode()
    {
        if(_image.isOn)
        {
            _useImage = true;
        }
        else 
        { 
            _useImage = false;
        }

        if(_text.isOn)
        {
            _useText = true;
        }
        else
        {
            _useText = false;
        }
    }
}
