using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageBlinkEffect : MonoBehaviour
{
    public Image flashImage; // ������������Ҫ�ڱ༭����ָ��Image���  
    public Color flashColor = Color.white; // ��˸ʱ��Ҫ����ɫ  
    public float flashDuration = 0.5f; // ÿ����˸�ĳ���ʱ��  
    public float flashInterval = 0.5f; // ��˸���  
    private bool isFlashing = true; // �Ƿ�������˸  
    private Coroutine flashCoroutine; // ��˸Э�̵�����  

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
    // ��ʼ��˸  
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
        Color originalColor = flashImage.color; // ����ԭʼ��ɫ  
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
