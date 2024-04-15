using UnityEngine;
using UnityEngine.SceneManagement;  // Required for handling scene changes

public class MusicManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);  // Keep this object across scenes
        SceneManager.sceneLoaded += OnSceneLoaded;  // Subscribe to the sceneLoaded event
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainScene")  // Check if the loaded scene is MainScene
        {
            StopMusic();  // Stop the music if it is MainScene
        }
        else
        {
            // Optionally, restart or change music for other scenes
        }
    }

    public void PlayMusic(AudioClip musicClip)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (!audioSource.isPlaying)
        {
            audioSource.clip = musicClip;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void StopMusic()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;  // Unsubscribe when destroyed
    }
}
