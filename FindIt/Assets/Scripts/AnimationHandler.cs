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

    public void StartAnim(string animationBool)
    {
        animator.SetBool(animationBool, true);
    }

}
