using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnButton : MonoBehaviour
{
    public static bool loadingScene = false;
    public KeyCode TeleportButton = KeyCode.R;
    public string SceneName = "ControlRoom";
    [Range(0,5)] public float loadDelay = 0.5f;

    void Update()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene != SceneName){
            if (Input.GetKeyDown(TeleportButton) && !loadingScene)
            {
                loadingScene = true;
                StartCoroutine(LoadSceneAfterDelay());
            }
        }
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene(SceneName);
        loadingScene = false;
    }
}