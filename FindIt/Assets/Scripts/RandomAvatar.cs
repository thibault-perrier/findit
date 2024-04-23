using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomAvatar : MonoBehaviour
{
    [Header("Sprite renderer")]
    [SerializeField] GameObject _avatarSprite;
    [SerializeField] GameObject _cameraSprite;
    [SerializeField] GameObject _hatSprite;

    [Header("List Sprite")]
    [SerializeField] List<Sprite> _cameraSprites = new List<Sprite>();
    [SerializeField] List<Sprite> _avatarSprites = new List<Sprite>();
    [SerializeField] List<Sprite> _hatSprites = new List<Sprite>();
    [SerializeField] Slider Slider;
     
    private void Start()
    {
        RandomiseAvatar();
    }

    public void RandomiseAvatar()
    {
        if(_avatarSprite.TryGetComponent<SpriteRenderer>(out SpriteRenderer avatarSpriteRenderer))
            avatarSpriteRenderer.sprite = _avatarSprites[Random.Range(0, _avatarSprites.Count)];
        else if(_avatarSprite.TryGetComponent<Image>(out Image avatarImage))
            avatarImage.sprite = _avatarSprites[Random.Range(0, _avatarSprites.Count)];

        if (_cameraSprite.TryGetComponent<SpriteRenderer>(out SpriteRenderer cameraSpriteRenderer))
            cameraSpriteRenderer.sprite = _cameraSprites[Random.Range(0, _cameraSprites.Count)];
        else if (_cameraSprite.TryGetComponent<Image>(out Image cameraImage))
            cameraImage.sprite = _cameraSprites[Random.Range(0, _cameraSprites.Count)];

        if (_hatSprite.TryGetComponent<SpriteRenderer>(out SpriteRenderer hatSpriteRenderer))
            hatSpriteRenderer.sprite = _hatSprites[Random.Range(0, _hatSprites.Count)];
        else if (_hatSprite.TryGetComponent<Image>(out Image hatImage))
            hatImage.sprite = _hatSprites[Random.Range(0, _hatSprites.Count)];
    }

    

    
}
