using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    public static bool isInTriggerZone = false;

    public GameObject cue;
    public GameObject back;//±³Ó°
  //  public GameObject back2;
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
            Debug.Log("OnTriggerEnter1");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTriggerZone = false;
            Debug.Log("OnTriggerExit1");
        }
    }
    void Start()
    {
        back.SetActive(false);
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
        else if(isInTriggerZone && Input.GetKeyDown(KeyCode.Escape))
        {
            cue.SetActive(true);
            character.SetActive(true);
            back.SetActive(false);
            A.SetActive(false);
            D.SetActive(false);
            ESC.SetActive(false);
        }

    }
}
