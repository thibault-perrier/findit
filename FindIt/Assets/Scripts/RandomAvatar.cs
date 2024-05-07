using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.U2D;
using UnityEngine.UI;

public class RandomAvatar : MonoBehaviour
{
    [Header("Sprite renderer")]
    public  GameObject _avatarSprite;
    public  GameObject _cameraSprite;
    public  GameObject _hatSprite;

    [Header("List Sprite")]
    public List<Sprite> _cameraSprites = new List<Sprite>();
    public List<Sprite> _avatarSprites = new List<Sprite>();
    public List<Sprite> _hatSprites = new List<Sprite>();
    public CharacterToChose part = new CharacterToChose();
    public enum CharacterToChose
    {
        Hat, Camera, Avatar
    }

    private void Start()
    {
        RandomiseAvatar();
    }

    public void SetRandomSprite(CharacterToChose character, int index)
    {
        GameObject sprite = null;
        List<Sprite> sprites = new List<Sprite>();

        switch (character)
        {
            case CharacterToChose.Hat:
                sprite = _hatSprite;
                sprites = _hatSprites;
                ChoseAvatar.Instance.currentIndexHat = index;
                print(index);
                break;
            case CharacterToChose.Camera:
                sprite = _cameraSprite;
                sprites = _cameraSprites;
                ChoseAvatar.Instance.currentIndexCamera = index;
                break;
            case CharacterToChose.Avatar:
                sprite = _avatarSprite;
                sprites = _avatarSprites;
                ChoseAvatar.Instance.currentIndexAvatar = index;
                break;
            default:
                return;
        }
        

        SpriteRenderer spriteRenderer = sprite.GetComponent<SpriteRenderer>();
        Image image = sprite.GetComponent<Image>();

        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = sprites[index];
        }
        else if (image != null)
        {
            image.sprite = sprites[index];
        }
    }

    private void RandomiseAvatar()
    {
        SetRandomSprite(CharacterToChose.Avatar, Random.Range(0, _avatarSprites.Count));
        SetRandomSprite(CharacterToChose.Avatar, Random.Range(0, _cameraSprites.Count));
        SetRandomSprite(CharacterToChose.Hat, Random.Range(0, _hatSprites.Count));
    }
}
