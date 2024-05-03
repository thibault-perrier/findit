using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptSelector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private List<string> promptList = new List<string>();
    void Start()
    {
        promptList=PromptReader.ReadListFromJSON<string>("prompt.json");
    }

    // Update is called once per frame
    public string RandomPrompt()
    {
        int selectorIndex = UnityEngine.Random.Range(0, promptList.Count);
        string prompt = promptList[selectorIndex];
        promptList.RemoveAt(selectorIndex);
        return prompt;
    }
}
