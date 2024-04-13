using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


// Load the next scene call:
// SceneTransitionManager.Instance.LoadScene(nextSceneName);

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;
    public Image fadePanel;
    public float fadeDuration = 1f;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // Make this object persistent
        SetupFadePanel();
    }

    private void SetupFadePanel()
    {
        // Make sure the parent canvas is also not destroyed on load
        if (fadePanel != null)
        {
            DontDestroyOnLoad(fadePanel.transform.parent.gameObject);
        }
        else
        {
            Debug.LogError("Fade panel is not assigned. Please assign it in the inspector.");
        }
    }

    public void LoadScene(string sceneName)
    {
        if (fadePanel == null)
        {
            Debug.LogError("Fade panel is null. Check your setup.");
            return;
        }
        StartCoroutine(Transition(sceneName));
    }

    private IEnumerator Transition(string sceneName)
    {
        yield return StartCoroutine(Fade(1)); // Fade to black
        SceneManager.LoadScene(sceneName);
        yield return new WaitForEndOfFrame(); // Ensure the scene is fully loaded
        yield return StartCoroutine(Fade(0)); // Fade to clear
    }

    private IEnumerator Fade(float targetAlpha)
    {
        if (fadePanel == null)
        {
            Debug.LogError("Fade panel is null. Check your setup.");
        }
        fadePanel.gameObject.SetActive(true);
        Color color = fadePanel.color;
        float startAlpha = color.a;

        float timer = 0;
        while (timer <= fadeDuration)
        {
            color.a = Mathf.Lerp(startAlpha, targetAlpha, timer / fadeDuration);
            fadePanel.color = color;
            timer += Time.deltaTime;
            yield return null;
        }
        color.a = targetAlpha;
        fadePanel.color = color;

        if (targetAlpha == 0)
        {
            fadePanel.gameObject.SetActive(false);
        }
    }
}

