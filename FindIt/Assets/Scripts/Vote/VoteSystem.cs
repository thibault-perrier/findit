using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VoteSystem : MonoBehaviour
{
    public Transform picturesParents;
    public List<Image> picturesList = new List<Image>();
    private int _pictureIndex = -1;
    public List<Image> characterList = new List<Image>();
    private int _characterIndex = -1;

    public TextMeshProUGUI prontText;

    private bool _endRound = false;

    private void Start()
    {
        prontText.text = string.Empty; // mettre le bon pront a la place
        //SetCharacter();
        //SetPicture();
    }

    private void SetCharacter() // set current player sprite 
    {
        foreach(var character in characterList)
        {
            character.GetComponent<Image>().sprite = null; //PlayerList[_characterIndex].sprite;
            _characterIndex++;
        }
    }

    private void SetPicture() // set current Picture 
    {
        foreach(var picture in picturesList)
        {
            picture.GetComponent<Image>().sprite = null;// CurrentPictureList[_characterIndex].sprite;
            _characterIndex++;
        }
    }
}
