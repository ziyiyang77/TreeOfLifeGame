using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextShow : MonoBehaviour
{
   // public Collider trigger;//如果报纸区域的collider失效则显示text
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
        // 隐藏文本
        texts.gameObject.SetActive(false);
    }
}
