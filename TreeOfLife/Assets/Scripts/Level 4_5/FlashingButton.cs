using System.Collections;
using UnityEngine;
using UnityEngine.UI; // ȷ��������UI�����ռ�  

public class FlashingButton : MonoBehaviour
{
    public Button myButton; // ������İ�ť  
    public Image buttonImage; // ���ð�ť��Image���  
    public Color flashColor = Color.yellow; // ��˸ʱ����ɫ  
    public float flashDuration = 0.5f; // ��˸�ĳ���ʱ��  
    private CanvasGroup canvasGroup; // CanvasGroup���  
    private Color originalColor; // ����ԭʼ��ɫ  
    private bool isFlashing = false; // �Ƿ�������˸  
    private bool isVisible = false; // ��ť�Ƿ�ɼ�  

    void Awake()
    {
        // ��ȡCanvasGroup��Image���  
        canvasGroup = GetComponent<CanvasGroup>();
        if (buttonImage == null)
        {
            buttonImage = myButton.GetComponentInChildren<Image>(); // ����Image��Button��ֱ���Ӷ���  
        }

        // ����ԭʼ��ɫ  
        originalColor = buttonImage.color;
    }

    // ����������������ð�ť�Ŀɼ��Բ���ʼ��˸�������Ҫ��  
    public void SetButtonVisibility(bool visible)
    {
        isVisible = visible;
        canvasGroup.alpha = visible ? 1f : 0f; // ���ð�ť��͸����  
        canvasGroup.interactable = visible; // ���ð�ť�Ƿ�ɽ���  
        canvasGroup.blocksRaycasts = visible; // ���ð�ť�Ƿ��赲����Ͷ�䣨���ڵ����⣩  

        if (visible && !isFlashing)
        {
            StartCoroutine(FlashButton()); // �����ť��Ϊ�ɼ�����ʼ��˸  
        }
        else if (!visible && isFlashing)
        {
            StopCoroutine(FlashButton()); // �����ť��Ϊ���ɼ�����ֹͣ��˸  
        }
    }

    // Э����ʵ�ְ�ť����˸Ч��  
    IEnumerator FlashButton()
    {
        isFlashing = true;
        while (isVisible && isFlashing)
        {
            // ���İ�ť��ɫΪ��˸��ɫ  
            buttonImage.color = flashColor;
            yield return new WaitForSeconds(flashDuration);

            // ���İ�ť��ɫ��ԭʼ��ɫ  
            buttonImage.color = originalColor;
            yield return new WaitForSeconds(flashDuration);
        }

        // �����ť���ٿɼ���ȷ����ɫ�ָ�Ϊԭʼ��ɫ  
        if (!isVisible)
        {
            buttonImage.color = originalColor;
        }

        isFlashing = false;
    }
}