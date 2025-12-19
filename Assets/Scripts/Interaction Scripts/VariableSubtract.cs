using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class VariableSubract : MonoBehaviour 
{
    public DialogueRunner dialogueSystem;

    public int value;

    private VariableStorageBehaviour variableStorage;

    [System.Obsolete]
    void Start() 
    {
        if (dialogueSystem == null) {
            dialogueSystem = FindFirstObjectByType<DialogueRunner>();
        }
        if (dialogueSystem != null) {
            variableStorage = dialogueSystem.GetComponent<InMemoryVariableStorage>();
        }
    }

    public void Subtract(string id)
    {
        if (id != "") {
            if (id.Substring(0, 1) != "$") {
                id = "$" + id;
            }
        }

        if (variableStorage != null && !string.IsNullOrEmpty(id))
        {
            float variableValue;
            variableStorage.TryGetValue(id, out variableValue);
            Debug.Log("" + variableValue);

            variableValue--;

            variableStorage.SetValue(id, variableValue);
        }
    }
}
