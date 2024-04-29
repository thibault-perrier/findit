using System.Collections;
using UnityEngine;

public class SwapPhoto : MonoBehaviour
{
    [SerializeField]float timeSwap;
    [SerializeField] GameObject takePhoto;
    [SerializeField] GameObject vote;
    public Picture picture;
    public bool pickPicture;
    public void StartChange()
    { 
        StartCoroutine(ChangeScene());
    }
    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(timeSwap);
        takePhoto.SetActive(false);
        pickPicture = true;
        //vote.SetActive(true);
        picture.InstantiateButtonVote();
    }
}
