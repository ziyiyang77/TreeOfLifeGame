using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gemGlow : MonoBehaviour
{
    public Renderer gemRenderer;
    public float maxGlowRadius = 50.0f; // 最大光环半径
    public float glowDuration =3.0f; // 光照扩展持续时间
    public float initialIntensity = 0.5f; // 初始发光强度
    public float maxIntensity = 2.0f; // 最大发光强度

    private MaterialPropertyBlock materialProperties;
    private float elapsedTime = 0f;
    public static bool isfinal = false;
    public Image whiteImage;
    void Start()
    {
        StartCoroutine(BeginGlowAfterDelay(3.0f)); // Wait 3 seconds before starting glow
    }

    IEnumerator BeginGlowAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for 3 seconds

        materialProperties = new MaterialPropertyBlock();
        gemRenderer.GetPropertyBlock(materialProperties);
    }

    void Update()
    {
        if (materialProperties == null)
            return; // Skip the Update if the material properties are not set yet

        elapsedTime += Time.deltaTime;
        float progress = elapsedTime / glowDuration;
        float glowRadius = Mathf.Lerp(0, maxGlowRadius, progress);
        float glowIntensity = Mathf.Lerp(initialIntensity, maxIntensity, progress);

        materialProperties.SetFloat("_GlowRadius", glowRadius);
        materialProperties.SetFloat("_GlowIntensity", glowIntensity);
        gemRenderer.SetPropertyBlock(materialProperties);

        if (elapsedTime >= glowDuration)
        {
            isfinal = true;
            enabled = false; // Optionally stop further updates
            gameObject.SetActive(false);
            whiteImage.gameObject.SetActive(true);
        }
    }
}
