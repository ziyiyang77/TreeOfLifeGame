using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class whitefade : MonoBehaviour
{
    public Image whiteLightPlane; // 全屏白光效果的平面对象
    public Material whiteLightMaterial; // 白光效果的材质
    public float fadeInTime = 2f; // 渐变到全白的时间
    public float fadeOutTime = 0.5f; // 渐变回正常的时间

    public GameObject cue;//F;
    public Collider trigger;//阅读完之后不能再阅读
    void Start()
    {
        // 确保白光效果初始状态为不可见
        whiteLightPlane.gameObject.SetActive(false);
    }
    void Update()
    {
        if (gemGlow.isfinal)
        {
            whiteLightPlane.gameObject.SetActive(true);
            StartCoroutine(GraduallyIncreaseRadius());
        }

    }

    IEnumerator FadeInOut()
    {
        // 渐变到全白
        float elapsedTime = 0f;
        while (elapsedTime < fadeInTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInTime);
            whiteLightMaterial.color = new Color(1f, 1f, 1f, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 持续一段时间

        yield return new WaitForSeconds(1.0f);

        // 渐变回正常
        elapsedTime = 0f;
        while (elapsedTime < fadeOutTime)
        {
            Debug.Log("zhengchang");
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeOutTime);
            whiteLightMaterial.color = new Color(1f, 1f, 1f, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        whiteLightPlane.gameObject.SetActive(false);


    }

    IEnumerator GraduallyIncreaseRadius()
    {
        float elapsedTime = 0f;
        float initialRadius = 0.05f;
        float targetRadius = 1f;

        while (elapsedTime < fadeInTime)
        {
            float newRadius = Mathf.Lerp(initialRadius, targetRadius, elapsedTime / fadeInTime);
            whiteLightMaterial.SetFloat("_TransparencyRadius", newRadius);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait until the next frame
        }

        // Ensure the final value is set exactly to the target
        whiteLightMaterial.SetFloat("_TransparencyRadius", targetRadius);

        elapsedTime = 0f;
        while (elapsedTime < fadeOutTime)
        {
            Debug.Log("fadeout");
            float newRadius = Mathf.Lerp(targetRadius, initialRadius, elapsedTime / fadeOutTime);
            whiteLightMaterial.SetFloat("_TransparencyRadius", newRadius);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        whiteLightMaterial.SetFloat("_TransparencyRadius", initialRadius);
        whiteLightPlane.gameObject.SetActive(false);
        cue.SetActive(false);
        trigger.enabled = false;
    }
}
