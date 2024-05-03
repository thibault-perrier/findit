using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PromptSelector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private List<string> promptList = new List<string>();
    [SerializeField] TextMeshProUGUI promptText;

    private void Awake()
    {
        promptList=PromptReader.ReadListFromJSON<string>("prompt.json");
    }

    private void OnEnable()
    {
        RandomPrompt();
    }

    // Update is called once per frame
    public string RandomPrompt()
    {
        int selectorIndex = UnityEngine.Random.Range(0, promptList.Count);
        string prompt = promptList[selectorIndex];
        promptList.RemoveAt(selectorIndex);
        promptText.text = prompt;
        return prompt;
    }
}
