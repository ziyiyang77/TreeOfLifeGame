using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera firstCamera;

    private Camera mainCamera; 
    private bool isInTriggerZone = false;

    public GameObject cue; 


    void Start()
    {
        mainCamera = Camera.main;
        firstCamera.enabled = false; 

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTriggerZone = true;
            Debug.Log("OnTriggerEnter");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTriggerZone = false;
            Debug.Log("OnTriggerExit");
        }
    }

    void Update()
    {
        if (isInTriggerZone && Input.GetKeyDown(KeyCode.F))
        {
            cue.SetActive(false);
            firstCamera.enabled = true;
            
            mainCamera.enabled = false;
            Debug.Log("first view");   
        }
        else
        {
            cue.SetActive(true);
        }
       


    }
}
