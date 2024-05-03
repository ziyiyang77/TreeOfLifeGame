using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//此脚本是全屏白的效果
public class ButtonWhiteLightEffect : MonoBehaviour
{
    public Image whiteLightPlane; // 全屏白光效果的平面对象
    public Material whiteLightMaterial; // 白光效果的材质
    public float fadeInTime = 2f; // 渐变到全白的时间
    public float fadeOutTime = 0.5f; // 渐变回正常的时间

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
            StartCoroutine(FadeInOut());
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
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeOutTime);
            whiteLightMaterial.color = new Color(1f, 1f, 1f, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        whiteLightPlane.gameObject.SetActive(false);

       
    }
}
