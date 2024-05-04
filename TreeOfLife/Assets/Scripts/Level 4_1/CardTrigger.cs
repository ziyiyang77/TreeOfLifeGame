using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardTrigger : MonoBehaviour
{
    public bool isInTriggerZone = false;
    public GameObject cue;
    public Image card;
    void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Player"))
        {
            isInTriggerZone = true;
            cue.SetActive(true);
            Debug.Log("OnTriggerEnter2");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cue.SetActive(false);
            isInTriggerZone = false;
            Debug.Log("OnTriggerExit2");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        card.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isInTriggerZone && Input.GetKeyDown(KeyCode.F))
        {
            card.gameObject.SetActive(true);
        }
        else if(isInTriggerZone && Input.GetKeyDown(KeyCode.Escape))
        {
            card.gameObject.SetActive(false);
        }
    }
}
