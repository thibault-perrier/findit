using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomAvatar : MonoBehaviour
{
    [Header("Sprite renderer")]
    [SerializeField] Image _avatarSprite;
    [SerializeField] Image _cameraSprite;

    [Header("List Sprite")]
    [SerializeField] List<Sprite> _cameraSprites = new List<Sprite>();
    [SerializeField] List<Sprite> _avatarSprites = new List<Sprite>();

    private void Start()
    {
        RandomiseAvatar();
    }

    public void RandomiseAvatar()
    {
        _avatarSprite.sprite = _avatarSprites[Random.Range(0, _avatarSprites.Count)];
        _cameraSprite.sprite = _cameraSprites[Random.Range(0, _cameraSprites.Count)];
    }

    public void PreviousAvatar()
    {
        if (_avatarSprites.IndexOf(_avatarSprite.sprite) > 0)
            _avatarSprite.sprite = _avatarSprites[_avatarSprites.IndexOf(_avatarSprite.sprite)-1];
        else
            _avatarSprite.sprite = _avatarSprites[_avatarSprites.Count - 1];
    }

    public void NextAvatar()
    {
        if (_avatarSprites.IndexOf(_avatarSprite.sprite) < _avatarSprites.Count - 1)
            _avatarSprite.sprite = _avatarSprites[_avatarSprites.IndexOf(_avatarSprite.sprite) + 1];
        else
            _avatarSprite.sprite = _avatarSprites[0];
    }

    public void PreviousCamera()
    {
        if (_cameraSprites.IndexOf(_cameraSprite.sprite) > 0)
            _cameraSprite.sprite = _cameraSprites[_cameraSprites.IndexOf(_cameraSprite.sprite) - 1];
        else
            _cameraSprite.sprite = _cameraSprites[_cameraSprites.Count-1];
    }

    public void NextCamera()
    {
        if (_cameraSprites.IndexOf(_cameraSprite.sprite) < _cameraSprites.Count-1)
            _cameraSprite.sprite = _cameraSprites[_cameraSprites.IndexOf(_cameraSprite.sprite) + 1];
        else
            _cameraSprite.sprite = _cameraSprites[0];
    }
}
