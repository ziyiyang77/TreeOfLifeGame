using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PaperSpreadScript : MonoBehaviour
{
    public GameObject paperImage; // ������ֽUIԪ��  
    private bool isFullScreen = false; // �����ֽ�Ƿ�������Ļ  
    public GameObject cue; //F
    public static bool Isread=false;


    void Start()
    {
        paperImage.SetActive(false);
        cue.SetActive(false);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cue.SetActive(true);
            Isread = true;
            Debug.Log("Enterletter");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cue.SetActive(false);
            Isread = false;
            Debug.Log("Exitletter");
        }
    }

     void Update()
    {
       if(Isread&&Input.GetKeyDown(KeyCode.F))
        {
            paperImage.SetActive(true);
            Isread = false;
           
        }
    }


}
