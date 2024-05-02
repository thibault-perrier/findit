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
     
    private void Start()
    {
        RandomiseAvatar();
    }

    private void SetRandomSprite(GameObject gameObject, List<Sprite> sprites)
    {
        if (gameObject == null)
            return;

        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Image image = gameObject.GetComponent<Image>();

        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = sprites[Random.Range(0, sprites.Count)];
        }
        else if (image != null)
        {
            image.sprite = sprites[Random.Range(0, sprites.Count)];
        }
    }

    // Utilisation

    public void RandomiseAvatar()
    {
        SetRandomSprite(_avatarSprite, _avatarSprites);
        SetRandomSprite(_cameraSprite, _cameraSprites);
        SetRandomSprite(_hatSprite, _hatSprites);
    }

    

    
}
