using System.Collections;
using UnityEngine;
using UnityEngine.UI; // 确保引用了UI命名空间  

public class FlashingButton : MonoBehaviour
{
    public Button myButton; // 引用你的按钮  
    public Image buttonImage; // 引用按钮的Image组件  
    public Color flashColor = Color.yellow; // 闪烁时的颜色  
    public float flashDuration = 0.5f; // 闪烁的持续时间  
    private CanvasGroup canvasGroup; // CanvasGroup组件  
    private Color originalColor; // 保存原始颜色  
    private bool isFlashing = false; // 是否正在闪烁  
    private bool isVisible = false; // 按钮是否可见  

    void Awake()
    {
        // 获取CanvasGroup和Image组件  
        canvasGroup = GetComponent<CanvasGroup>();
        if (buttonImage == null)
        {
            buttonImage = myButton.GetComponentInChildren<Image>(); // 假设Image是Button的直接子对象  
        }

        // 保存原始颜色  
        originalColor = buttonImage.color;
    }

    // 调用这个函数来设置按钮的可见性并开始闪烁（如果需要）  
    public void SetButtonVisibility(bool visible)
    {
        isVisible = visible;
        canvasGroup.alpha = visible ? 1f : 0f; // 设置按钮的透明度  
        canvasGroup.interactable = visible; // 设置按钮是否可交互  
        canvasGroup.blocksRaycasts = visible; // 设置按钮是否阻挡射线投射（用于点击检测）  

        if (visible && !isFlashing)
        {
            StartCoroutine(FlashButton()); // 如果按钮变为可见，则开始闪烁  
        }
        else if (!visible && isFlashing)
        {
            StopCoroutine(FlashButton()); // 如果按钮变为不可见，则停止闪烁  
        }
    }

    // 协程来实现按钮的闪烁效果  
    IEnumerator FlashButton()
    {
        isFlashing = true;
        while (isVisible && isFlashing)
        {
            // 更改按钮颜色为闪烁颜色  
            buttonImage.color = flashColor;
            yield return new WaitForSeconds(flashDuration);

            // 更改按钮颜色回原始颜色  
            buttonImage.color = originalColor;
            yield return new WaitForSeconds(flashDuration);
        }

        // 如果按钮不再可见，确保颜色恢复为原始颜色  
        if (!isVisible)
        {
            buttonImage.color = originalColor;
        }

        isFlashing = false;
    }
}