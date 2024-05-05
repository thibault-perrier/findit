using System.Collections;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public GameObject objectToDisable;
    public Animator animator;

    public void DisableObject()
    {
        if (objectToDisable != null)
        {
            objectToDisable.SetActive(false);
        }
    }

    public void ToggleObject()
    {
        if (objectToDisable != null)
        {
            objectToDisable.SetActive(!objectToDisable.activeSelf);
        }
    }
    
    public void ActiveObject()
    {
        if (objectToDisable != null)
        {
            objectToDisable.SetActive(true);
        }
    }

    public void StartIn()
    {
        gameObject.SetActive(true);
        animator.SetBool("In", true);
        StartCoroutine(EndIn());
    }

    private IEnumerator EndIn()
    {
        yield return new WaitForEndOfFrame();
        animator.SetBool("In", false);
    }

    public void StartOut()
    {
        if (gameObject.activeSelf)
        {
            animator.SetBool("Out", true);
            StartCoroutine(EndOut());
        }
    }

    private IEnumerator EndOut()
    {
        yield return new WaitForEndOfFrame();
        animator.SetBool("Out", false);
    }

}
