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
            Debug.Log("next scene");
        }
    }

    // Method to load the next scene
    void LoadNextScene()
    {
        SceneTransitionManager.Instance.LoadScene(nextSceneName);  // Load the next scene
    }
}
