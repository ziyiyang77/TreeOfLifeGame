using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OpeningSceneController : MonoBehaviour
{
    public TextMeshProUGUI scriptText; // Use TextMeshProUGUI instead of Text
    public float delayBetweenLines = 2.5f; // Time between lines of script
    public float fadeDuration = 1f; // Duration for the fade in and fade out effects
    public string[] scriptLines; // Lines of script to display
    public string nextSceneName = "NextScene"; // Name of the next scene to load

    private IEnumerator Start()
    {
        scriptText.text = "";
        scriptText.color = new Color(scriptText.color.r, scriptText.color.g, scriptText.color.b, 0); // Start with invisible text

        foreach (var line in scriptLines)
        {
            // Fade in
            yield return StartCoroutine(FadeTextToFullAlpha(fadeDuration, scriptText, line));

            // Wait with visible text
            yield return new WaitForSeconds(delayBetweenLines);

            // Fade out
            yield return StartCoroutine(FadeTextToZeroAlpha(fadeDuration, scriptText));
        }

        // Wait a moment before switching scenes
        yield return new WaitForSeconds(fadeDuration);

        // Load the next scene
        SceneTransitionManager.Instance.LoadScene(nextSceneName);
    }

    public IEnumerator FadeTextToFullAlpha(float t, TextMeshProUGUI text, string line)
    {
        text.text = line;
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI text)
    {
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
