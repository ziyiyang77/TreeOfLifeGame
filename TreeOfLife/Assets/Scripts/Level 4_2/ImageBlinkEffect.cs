using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageBlinkEffect : MonoBehaviour
{
    public Image flashImage; // 公开变量，需要在编辑器中指定Image组件  
    public Color flashColor = Color.white; // 闪烁时想要的颜色  
    public float flashDuration = 0.5f; // 每次闪烁的持续时间  
    public float flashInterval = 0.5f; // 闪烁间隔  
    private bool isFlashing = true; // 是否正在闪烁  
    private Coroutine flashCoroutine; // 闪烁协程的引用  

   /* void Start()
    {
        StartFlashing();
    }*/
    void Update()
    {
       
        if (flashImage.gameObject.activeInHierarchy)
        {
            StartFlashing();
            Debug.Log("qidong");
        }
    }
    // 开始闪烁  
    private void StartFlashing()
    {
        Debug.Log("startblink");
        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
        }

        flashCoroutine = StartCoroutine(FlashImage());
    }

   
    IEnumerator FlashImage()
    {
        Color originalColor = flashImage.color; // 保存原始颜色  
        float lerpT = 0f;

        Debug.Log("blink");
        while (isFlashing)
        {
           
            flashImage.color = Color.Lerp(originalColor, flashColor, lerpT);
            lerpT += Time.deltaTime / flashDuration;

     
            if (lerpT >= 1f)
            {
                lerpT = 1f; 
                yield return new WaitForSeconds(flashInterval); 
                lerpT = 0f; 
            }

            yield return null; 
        }

        flashImage.color = originalColor;
    }

    public void OnMouseClick()
    {
        Debug.Log("stopblink");

    //    StopFlashing();
    }
}
