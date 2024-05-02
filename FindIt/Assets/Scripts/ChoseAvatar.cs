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
    public int currentIndexHat;
    public int currentIndexCamera;
    public int currentIndexAvatar;

    public static ChoseAvatar Instance;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    public enum CharacterToChose
    {
        Hat, 
        Camera, 
        Avatar
    }

    public enum Direction
    {
        Next, 
        Previous
    }

    private void ChooseCharacter(CharacterToChose character, Direction direction)
    {
        List<Sprite> sprites;
        Image img;
        int currentIndex;

        switch (character)
        {
            case CharacterToChose.Avatar:
                sprites = _avatarSprites;
                img = _avatarSprite;
                currentIndexAvatar = (currentIndexAvatar + ((direction == Direction.Previous) ? -1 : 1) + _avatarSprites.Count) % _avatarSprites.Count;
                img.sprite = sprites[currentIndexAvatar];
                break;
            case CharacterToChose.Camera:
                sprites = _cameraSprites;
                img = _cameraSprite;
                currentIndexCamera = (currentIndexCamera + ((direction == Direction.Previous) ? -1 : 1) + _cameraSprites.Count) % _cameraSprites.Count;
                img.sprite = sprites[currentIndexCamera];
                break;
            case CharacterToChose.Hat:
                sprites = _hatSprites;
                img = _hatSprite;
                currentIndexHat = (currentIndexHat + ((direction == Direction.Previous) ? -1 : 1) + _hatSprites.Count) % _hatSprites.Count;
                img.sprite = sprites[currentIndexHat];
                break;
            default:
                return;
        }
    }

    public void NextCharacter(int characterIndex)
    {
        CharacterToChose character = (CharacterToChose)characterIndex;
        ChooseCharacter(character, Direction.Next);
    }

    public void PreviousCharacter(int characterIndex)
    {
        CharacterToChose character = (CharacterToChose)characterIndex;
        ChooseCharacter(character, Direction.Previous);
    }
}
