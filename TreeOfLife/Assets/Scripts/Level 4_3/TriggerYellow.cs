using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerYellow : MonoBehaviour
{
    public static bool isInTriggerZone = false;

    public GameObject cue;
    public GameObject back;//±³Ó°

    public GameObject character;
    public GameObject A;
    public GameObject D;
    public GameObject ESC;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cue.SetActive(true);
            isInTriggerZone = true;
            Debug.Log("OnTriggerEnterYellow");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cue.SetActive(false);
            isInTriggerZone = false;
            Debug.Log("OnTriggerExitYellow");
        }
    }
    void Start()
    {
        cue.SetActive(false);
        back.SetActive(false);
        A.SetActive(false);
        D.SetActive(false);
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
            ESC.SetActive(true);
        }
        else if (isInTriggerZone && Input.GetKeyDown(KeyCode.Escape))
        {
            character.SetActive(true);
            back.SetActive(false);
            A.SetActive(false);
            D.SetActive(false);
            ESC.SetActive(false);
        }

    }
}
