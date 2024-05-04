using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera firstCamera;

    private Camera mainCamera; 
    private bool isInTriggerZone = false;

    public GameObject cue;
    public GameObject player;

    void Start()
    {
        mainCamera = Camera.main;
        firstCamera.enabled = false;
        cue.SetActive(true);
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
        if (CheckSucess.isfirstsuccess&&isInTriggerZone && Input.GetKeyDown(KeyCode.F))
        {
            cue.SetActive(false);
            firstCamera.enabled = true;
            mainCamera.enabled = false;
            Debug.Log("first view");   
        }
        if (mainCamera.enabled)
        {
            player.SetActive(true);
         //   cue.SetActive(true);
        }
        else
        {
            player.SetActive(false);
            cue.SetActive(false);
        }
       


    }
}
