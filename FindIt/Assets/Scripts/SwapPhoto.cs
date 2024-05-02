using System.Collections;
using UnityEngine;

public class SwapPhoto : MonoBehaviour
{
    [SerializeField]float timeSwap;
    [SerializeField] GameObject takePhoto;
    [SerializeField] GameObject vote;
    public Picture picture;
    public void StartChange()
    { 
        StartCoroutine(ChangeScene());
    }
    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(timeSwap);
        takePhoto.SetActive(false);
        vote.SetActive(true);
        picture.InstantiateButtonVote();
    }
}
