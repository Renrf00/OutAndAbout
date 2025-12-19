using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class JumpOnSceneLoad : MonoBehaviour
{

    public string nodeToJumpTo = "Start";
    private DialogueRunner dialogueRunner;

    private void Start()
    {
        dialogueRunner = GetComponent<DialogueRunner>();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        dialogueRunner.StartDialogue(nodeToJumpTo);
    }
}
