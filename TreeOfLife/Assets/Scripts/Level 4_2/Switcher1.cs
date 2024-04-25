using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher1 : MonoBehaviour
{
    public static bool isInTriggerZone = false;

    public GameObject cue;
    public GameObject back;//��Ӱ
    public GameObject character;
    public GameObject A;
    public GameObject D;
    public GameObject ESC;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTriggerZone = true;
            Debug.Log("OnTriggerEnter2");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTriggerZone = false;
            Debug.Log("OnTriggerExit2");
        }
    }
    void Start()
    {
        back.SetActive(false);
        ESC.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInTriggerZone && Input.GetKeyDown(KeyCode.F))
        {
            cue.SetActive(false);
            character.SetActive(false);
            back.SetActive(true);
            A.SetActive(true);
            D.SetActive(true);
        }
        else if(isInTriggerZone && Input.GetKeyDown(KeyCode.Escape))
        {
            cue.SetActive(true);
            character.SetActive(true);
            back.SetActive(false);
            A.SetActive(false);
            D.SetActive(false);
        }

    }
}
