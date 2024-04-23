using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoseAvatar : MonoBehaviour
{

    [Header("Sprite renderer")]
    [SerializeField] Image _avatarSprite;
    [SerializeField] Image _cameraSprite;
    [SerializeField] Image _hatSprite;

    [Header("List Sprite")]
    [SerializeField] List<Sprite> _cameraSprites = new List<Sprite>();
    [SerializeField] List<Sprite> _avatarSprites = new List<Sprite>();
    [SerializeField] List<Sprite> _hatSprites = new List<Sprite>();
    public void PreviousAvatar()
    {
        if (_avatarSprites.IndexOf(_avatarSprite.sprite) > 0)
            _avatarSprite.sprite = _avatarSprites[_avatarSprites.IndexOf(_avatarSprite.sprite) - 1];
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
            _cameraSprite.sprite = _cameraSprites[_cameraSprites.Count - 1];
    }

    public void NextCamera()
    {
        if (_cameraSprites.IndexOf(_cameraSprite.sprite) < _cameraSprites.Count - 1)
            _cameraSprite.sprite = _cameraSprites[_cameraSprites.IndexOf(_cameraSprite.sprite) + 1];
        else
            _cameraSprite.sprite = _cameraSprites[0];
    }

    public void PreviousHat()
    {
        if (_hatSprites.IndexOf(_hatSprite.sprite) > 0)
            _hatSprite.sprite = _hatSprites[_hatSprites.IndexOf(_hatSprite.sprite) - 1];
        else
            _hatSprite.sprite = _hatSprites[_hatSprites.Count - 1];
    }

    public void NextHat()
    {
        if (_hatSprites.IndexOf(_hatSprite.sprite) < _hatSprites.Count - 1)
            _hatSprite.sprite = _hatSprites[_hatSprites.IndexOf(_hatSprite.sprite) + 1];
        else
            _hatSprite.sprite = _hatSprites[0];
    }


}
