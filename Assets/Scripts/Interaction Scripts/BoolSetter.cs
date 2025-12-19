using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class BoolSetter : PlayerActivatable
{
    public DialogueRunner dialogueSystem;

    public string identifier;

    public bool value;

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
        if (identifier != "") {
            if (identifier.Substring(0, 1) != "$") {
                identifier = "$" + identifier;
            }
        }
    }

    override protected void OnActivate()
    {
        if (variableStorage != null && !string.IsNullOrEmpty(identifier))
        {
            variableStorage.SetValue(identifier, value);
        }
    }

    override protected bool IsActivated() 
    {
        return false;
    }

}
