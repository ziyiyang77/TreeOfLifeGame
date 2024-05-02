using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManage : MonoBehaviour
{
    // 指定文本组件
    public TextMeshProUGUI buttonText1;
    public TextMeshProUGUI buttonText2;
    public Button right2;
    public Button finalButton;
    public Image paperImage;
    public GameObject gemstone;

    // 当前状态：是否显示文本
    private bool isTextShown = false;
    private bool isfirstopen = true;

    void Start()
    {
        buttonText2.enabled = false;
        right2.enabled = false;
        right2.gameObject.SetActive(false);
        finalButton.gameObject.SetActive(false);
        gemstone.SetActive(false);
    }
    void Update()
    {
       if(PaperSpreadScript.Isread && isfirstopen)
        {
            buttonText1.enabled = true;
            isfirstopen = false;
        }     

    }

    public void ToggleText1()
    {
        buttonText1.enabled = true;
        buttonText2.enabled = false;
    }
    public void ToggleText2()
    {
        buttonText1.enabled = false;
        buttonText2.enabled = true;
        right2.gameObject.SetActive(true);
        right2.enabled = true;
        finalButton.gameObject.SetActive(true);
    }
    public void final()
    {
        paperImage.gameObject.SetActive(false);
        if (gemstone != null)
            gemstone.SetActive(true);
    }
}
