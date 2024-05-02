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
    public Image Imagestone;//��ʯ
    public TextMeshProUGUI[] texts; // �洢���е�Text���
    private int currentIndex = 0; // ��ǰ��ʾ��Text����


    void Start()
    {
        /*buttonText2.enabled = false;
        right2.enabled = false;
        right2.gameObject.SetActive(false);
        finalButton.gameObject.SetActive(false);*/
        gemstone.SetActive(false);
        Imagestone.gameObject.SetActive(false);
        logo.gameObject.SetActive(false);
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
    // �������ͷ��ťʱ����
    public void ShowNextText()
    {
       
            HideText(currentIndex);
            currentIndex = (currentIndex + 1) % texts.Length;
            if (currentIndex == 1)
                logo.gameObject.SetActive(true);
            else logo.gameObject.SetActive(false);
            ShowText(currentIndex);
            UpdateButtonState();

    }

    // �����Ҽ�ͷ��ťʱ����
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
        // ����ǵ�һ��text�����������ͷ��ť
        if (currentIndex == 0)
        {
            rightButton.gameObject.SetActive(false);
        }
        else
        {
            rightButton.gameObject.SetActive(true);
        }

        // ��������һ��text
        if (currentIndex == texts.Length - 1)
        {
            leftButton.enabled = false;
            Imagestone.gameObject.SetActive(true);
            finalButton.gameObject.SetActive(true);
        }
        
    }
    public void final()
    {
      
        paperImage.gameObject.SetActive(false);
<<<<<<< Updated upstream
        if (gemstone != null)
            gemstone.SetActive(true);
=======

    //    gemstone.SetActive(true);
>>>>>>> Stashed changes
    }
}
