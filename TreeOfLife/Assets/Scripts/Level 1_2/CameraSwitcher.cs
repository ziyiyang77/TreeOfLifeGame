using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera firstCamera;

    private Camera mainCamera; 
    private bool isInTriggerZone = false;
  


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

            firstCamera.enabled = true;
            
            mainCamera.enabled = false;
            Debug.Log("first view");   
        }
        
       


    }
}
