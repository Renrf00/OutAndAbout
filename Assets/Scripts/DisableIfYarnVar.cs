using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DisableIfYarnVar : MonoBehaviour
{
    public VariableStorageBehaviour variableStorageBehaviour;
    public string variableName;
    public List<string> DisableStrings;

    void Awake()
    {
        variableStorageBehaviour = FindObjectOfType<VariableStorageBehaviour>();
    
    }
    void Start()
    {
        if (variableStorageBehaviour == null) {
            Debug.LogWarning("VariableStorageBehaviour not defined. This will result in errors.");
        }
        if (!variableName.StartsWith("$"))
            variableName = "$" + variableName;

        if (DisableStrings.Contains(GetValue(variableName)))
        {
            gameObject.SetActive(false);
        }
    }

    string GetValue(string key)
    {
        if (variableStorageBehaviour.TryGetValue<object>(key, out var value)) 
        {
            return string.Format("{0}", value.ToString());
        } 
        else
        {
            return string.Empty;
        }
    }
}