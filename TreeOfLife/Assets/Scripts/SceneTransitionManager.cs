using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;
    public Image blackFadePanel;
    public Image whiteFadePanel;
    public float fadeDuration = 1f;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // Make this object persistent across scenes

        SetupFadePanels(); // Notice the plural in the method name since we now handle two panels
    }

    private void SetupFadePanels()
    {
        // Check and protect the parent canvas of the black fade panel
        if (blackFadePanel != null)
        {
            DontDestroyOnLoad(blackFadePanel.transform.parent.gameObject);
        }
        else
        {
            Debug.LogError("Black fade panel is not assigned. Please assign it in the inspector.");
        }
    }

    public void LoadScene(string sceneName)
    {
        if (sceneName == "forest1.1")
        {
            StartCoroutine(Transition(sceneName, blackFadePanel));
        }
        else
        {
            StartCoroutine(Transition(sceneName, whiteFadePanel));
        }
    }

    private IEnumerator Transition(string sceneName, Image fadePanel)
    {
        yield return StartCoroutine(Fade(fadePanel, 1)); // Fade to color
        SceneManager.LoadScene(sceneName);
        yield return new WaitForEndOfFrame(); // Ensure the scene is fully loaded
        yield return StartCoroutine(Fade(fadePanel, 0)); // Fade to clear
    }

    private IEnumerator Fade(Image fadePanel, float targetAlpha)
    {
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
