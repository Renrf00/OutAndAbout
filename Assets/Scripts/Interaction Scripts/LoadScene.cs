using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class LoadScene : PlayerActivatable
{
    public static bool loadingScene = false;

    public string sceneToLoad;
    public List<GameObject> ObjectsToKeep;  // Public list for objects to keep
    [Range(0, 5)] public float loadDelay = 0f;

    private bool isReady = true;
    private static List<GameObject> keptObjects = new List<GameObject>(); // Track kept objects
 
    override protected void OnActivate()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene != sceneToLoad){
            isReady = false;
    
            // Loop through each object in the list and apply DontDestroyOnLoad
            foreach (GameObject obj in ObjectsToKeep)
            {
                if (obj != null && !keptObjects.Contains(obj))
                {
                    DontDestroyOnLoad(obj);
                    keptObjects.Add(obj);  // Track the object
                }
            }
    
            if (!string.IsNullOrEmpty(sceneToLoad) && !loadingScene)
            {
                loadingScene = true;

                SceneManager.sceneLoaded += OnSceneLoaded;  // Subscribe to scene loaded event
                StartCoroutine(LoadSceneAfterDelay());
            }
        }
    }
    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene(sceneToLoad);
        loadingScene = false;
    }
 
    override protected bool IsActivated()
    {
        return !isReady;
    }
 
    // This is called when the scene has finished loading
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;  // Unsubscribe from event
 
        // Move each kept object to the current scene
        foreach (GameObject obj in keptObjects)
        {
            if (obj != null)
            {
                SceneManager.MoveGameObjectToScene(obj, scene);
            }
        }
    }
}
 