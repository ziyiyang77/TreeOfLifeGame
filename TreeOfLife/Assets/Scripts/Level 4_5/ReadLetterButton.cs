using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadLetterButton : MonoBehaviour
{
    public Button leftButton;
    public Button rightButton;
    public Button finalButton;
    public Image paperImage;
    public GameObject gemstone;
 //   public Image Imagestone;//��ʯ
    public TMPro.TextMeshProUGUI[] texts; // �洢���е�Text���
    private int currentIndex = 0; // ��ǰ��ʾ��Text����
    private AudioSource audio;
    public AudioClip paper;
    public AudioClip paper_close;
    public Button gemButton;//��ť


    void Start()
    {
        audio = GetComponent<AudioSource>();

        gemstone.SetActive(false);
        gemButton.gameObject.SetActive(false);
        //    Imagestone.gameObject.SetActive(false);
        rightButton.gameObject.SetActive(false);
        leftButton.gameObject.SetActive(true);
        finalButton.gameObject.SetActive(false);
        for (int i = 1; i < texts.Length; i++)
        {
            HideText(i);
        }
    }
    void Update()
    {
        

    }
    // �������ͷ��ťʱ����
    public void ShowNextText()
    {

        HideText(currentIndex);
        currentIndex = (currentIndex + 1) % texts.Length;
        ShowText(currentIndex);
        UpdateButtonState();
        audio.clip = paper;
        audio.Play();

    }

    // �����Ҽ�ͷ��ťʱ����
    public void ShowPreviousText()
    {

        HideText(currentIndex);
        currentIndex = (currentIndex - 1 + texts.Length) % texts.Length;
        ShowText(currentIndex);
        UpdateButtonState();
        audio.clip = paper;
        audio.Play();
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
        // ����ǵ�һ��text���������Ҽ�ͷ��ť
        if (currentIndex == 0)
        {
            rightButton.gameObject.SetActive(false);
            leftButton.gameObject.SetActive(true);
        }
        else
        {
            rightButton.gameObject.SetActive(true);
        }

        // ��������һ��text
        if (currentIndex == texts.Length - 1)
        {
            leftButton.enabled = false;
            gemButton.gameObject.SetActive(true);
            //  Imagestone.gameObject.SetActive(true);
            finalButton.gameObject.SetActive(true);
        }
        else
        {
            leftButton.enabled = true ;
            gemButton.gameObject.SetActive(false);
        }

    }
    public void final()
    {
        paperImage.gameObject.SetActive(false);
        gemstone.SetActive(true);
        audio.clip = paper_close;
        audio.Play();
    }
}
