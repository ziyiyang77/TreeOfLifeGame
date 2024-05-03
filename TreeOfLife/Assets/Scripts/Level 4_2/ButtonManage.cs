using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManage : MonoBehaviour
{
    public Button leftButton;
    public Button rightButton;
    public Button finalButton;
    public Image paperImage;
    public GameObject gemstone;
    public Image logo;
    public Image Imagestone;//宝石
    public TextMeshProUGUI[] texts; // 存储所有的Text组件
    public int currentIndex = 0; // 当前显示的Text索引


    void Start()
    {
        /*buttonText2.enabled = false;
        right2.enabled = false;
        right2.gameObject.SetActive(false);
        finalButton.gameObject.SetActive(false);*/
        if (gemstone != null && Imagestone != null && logo != null)
        {
            gemstone.SetActive(false);
            Imagestone.gameObject.SetActive(false);
            logo.gameObject.SetActive(false);
        }
        rightButton.gameObject.SetActive(false);
        leftButton.gameObject.SetActive(true);
        finalButton.gameObject.SetActive(false);
        for (int i=1;i<texts.Length;i++)
        {
            HideText(i);
        }
    }
    void Update()
    {
      /* if(PaperSpreadScript.Isread && isfirstopen)
        {
            buttonText1.enabled = true;
            isfirstopen = false;
        }   */  

    }
    // 按下左箭头按钮时调用
    public void ShowNextText()
    {
       
            HideText(currentIndex);
            currentIndex = (currentIndex + 1) % texts.Length;
            if (logo != null)
            {            
                if (currentIndex == 1)
                    logo.gameObject.SetActive(true);
                else logo.gameObject.SetActive(false);
            }
            ShowText(currentIndex);
            UpdateButtonState();

    }

    // 按下右箭头按钮时调用
    public void ShowPreviousText()
    {
      
        HideText(currentIndex);
        currentIndex = (currentIndex - 1 + texts.Length) % texts.Length;
        ShowText(currentIndex);
        UpdateButtonState();
    }

    private void ShowText(int index)
    {
        texts[index].gameObject.SetActive(true);
    }

    private void HideText(int index)
    {
        texts[index].gameObject.SetActive(false);
    }

    private void UpdateButtonState()
    {
        // 如果是第一个text，则隐藏左箭头按钮
        if (currentIndex == 0)
        {
            rightButton.gameObject.SetActive(false);
        }
        else
        {
            rightButton.gameObject.SetActive(true);
        }

        // 如果是最后一个text
        if (currentIndex == texts.Length - 1)
        {
            leftButton.enabled = false;
            if (Imagestone != null)
            Imagestone.gameObject.SetActive(true);
            finalButton.gameObject.SetActive(true);
        }
        
    }
    public void final()
    {
      
        paperImage.gameObject.SetActive(false);
        if (gemstone != null)
            gemstone.SetActive(true);

    }
}
