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

    public enum CharacterToChose
    {
        Hat, Camera, Avatar
    }

    public enum Direction
    {
        Next, Previous
    }

    private void ChooseCharacter(CharacterToChose character, Direction direction)
    {
        List<Sprite> sprites;
        Image sprite;

        switch (character)
        {
            case CharacterToChose.Avatar:
                sprites = _avatarSprites;
                sprite = _avatarSprite;
                break;
            case CharacterToChose.Camera:
                sprites = _cameraSprites;
                sprite = _cameraSprite;
                break;
            case CharacterToChose.Hat:
                sprites = _hatSprites;
                sprite = _hatSprite;
                break;
            default:
                return;
        }

        int currentIndex = sprites.IndexOf(sprite.sprite);
        int count = sprites.Count;

        int nextIndex;
        if (direction == Direction.Next)
            nextIndex = (currentIndex + 1) % count;
        else
            nextIndex = (currentIndex - 1 + count) % count;

        sprite.sprite = sprites[nextIndex];
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
