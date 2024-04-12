using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera firstCamera;

    public float minRange = 0.0f; // 允许的最小范围
    public float maxRange = 0.5f; // 允许的最大范围

    private Camera mainCamera; 
    private bool isInTriggerZone = false;
    private int count = 0;


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

    bool check( Transform objectToDetect)
    {
        float distance = Vector3.Distance(transform.position, objectToDetect.transform.position);
        if (distance >= minRange && distance <= maxRange)
        {
            return true;
        }
        return false;
    }
    void Update()
    {
        if (isInTriggerZone && Input.GetKeyDown(KeyCode.F))
        {

            firstCamera.enabled = true;
            
            mainCamera.enabled = false;
            Debug.Log("first view");

           GameObject[] gb = GameObject.FindGameObjectsWithTag("Pos");
            

                foreach (GameObject s in gb)
                {
                    CheckRange myScript = s.GetComponent<CheckRange>();
                if (myScript.flag)
                    count++;
                else
                    count = 0;
                }
                if(count==gb.Length)
               {
                firstCamera.enabled = false;

                mainCamera.enabled = true;
                Debug.Log("sucsess !");
            }
            
          
            
        }
        
       


    }
}
