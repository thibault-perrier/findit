using TMPro;
using UnityEngine;

public class debug : MonoBehaviour
{
    public TextMeshProUGUI consoleText;
    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }
    private void HandleLog(string logText, string stackTrace, LogType type)
    {
        if (type == LogType.Error || type == LogType.Exception || type == LogType.Assert)
        {
            consoleText.text += "<color=red>" + logText + "</color>\n";
        }
        else if (type == LogType.Warning)
        {
            consoleText.text += "<color=yellow>" + logText + "</color>\n";
        }
        else
        {
            consoleText.text += logText + "\n";
        }
    }
}
