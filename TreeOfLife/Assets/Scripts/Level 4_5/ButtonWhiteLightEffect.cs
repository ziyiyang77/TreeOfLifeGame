using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonWhiteLightEffect : MonoBehaviour
{
    public Image whiteLightPlane; // 全屏白光效果的平面对象
    public Material whiteLightMaterial; // 白光效果的材质
    public float fadeInTime = 0.5f; // 渐变到全白的时间
    public float fadeOutTime = 0.5f; // 渐变回正常的时间

    private bool isAnimating = false;
    public Image paperImage;
    public GameObject gemstone;

    void Start()
    {
        // 确保白光效果初始状态为不可见
        whiteLightPlane.gameObject.SetActive(false);
    }

    public void OnButtonClick()
    {
        if (!isAnimating)
        {
            isAnimating = true;
            whiteLightPlane.gameObject.SetActive(true);
            StartCoroutine(FadeInOut());
        }
        paperImage.gameObject.SetActive(false);
        gemstone.SetActive(true);
       // audio.clip = paper_close;
       // audio.Play();
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
        isAnimating = false;
    }
}
