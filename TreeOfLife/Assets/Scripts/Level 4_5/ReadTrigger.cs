using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadTrigger : MonoBehaviour
{
    public GameObject paperImage; // 引用信纸UI元素  
    private bool isFullScreen = false; // 标记信纸是否铺满屏幕  
    public GameObject cue; //F
    public static bool Isread = false;
    private AudioSource audio;
    public AudioClip paperGet;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        paperImage.SetActive(false);
        cue.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Isread = true;
            cue.SetActive(true);

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
        if (Isread && Input.GetKeyDown(KeyCode.F))
        {
            audio.clip = paperGet;
            audio.Play();
            paperImage.SetActive(true);
        }
    }

}
