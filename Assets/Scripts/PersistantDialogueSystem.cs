using UnityEngine;

public class PersistantDialogueSystem : MonoBehaviour
{
    public static PersistantDialogueSystem Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
