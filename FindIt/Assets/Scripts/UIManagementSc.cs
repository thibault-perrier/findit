using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManagementSc : MonoBehaviour
{
    [SerializeField] private GameObject ParameterObject;

    public void Parameter() 
    {
        if (!ParameterObject.activeInHierarchy)
        {
            ParameterObject.SetActive(true);
        }
        else if (ParameterObject.activeInHierarchy)
        {
            ParameterObject.SetActive(false);
        }
    }
}
