using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextShow : MonoBehaviour
{
   // public Collider trigger;//�����ֽ�����colliderʧЧ����ʾtext
    public TextMeshProUGUI texts;
    private bool isshow = false;
    // Start is called before the first frame update
    void Start()
    {
        texts.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isshow&&whitefade.fadoutOver)
        {
            Debug.Log("trigger false");
            texts.gameObject.SetActive(true);
            isshow = true;
            Invoke("HideText", 5f);
        }

    }
    void HideText()
    {
        // �����ı�
        texts.gameObject.SetActive(false);
    }
}
