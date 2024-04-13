using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string nextSceneName = "NextScene";
    // Method called when something enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Make sure it's the player entering the trigger
        {
            LoadNextScene();
        }
    }

    // Method to load the next scene
    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;  // Loop back to the first scene if it's the last one
        SceneTransitionManager.Instance.LoadScene(nextSceneName);  // Load the next scene
    }
}
