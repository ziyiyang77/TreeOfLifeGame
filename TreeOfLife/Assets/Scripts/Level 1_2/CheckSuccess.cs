using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckSucess : MonoBehaviour
{
    public Camera firstCamera;
    private Camera mainCamera;

    public float tolerance = 0.01f; // �����ж�λ���Ƿ�ƥ����ݲ�  
    public List<GameObject> balls; // ���С��Transform���б�  
    public List<Transform> targetPositions; // ���С��Ŀ��λ�õ��б�  
    private  int count = 0;
    public static bool isfirstsuccess = true;

    public GameObject cue; //F sprite
    public GameObject Block;


   

    void Start()
    {
        mainCamera = Camera.main;
    //    CheckBallPositions();
    }
    void Update()
    {
        count = 0;
        if(isfirstsuccess)
        {
            CheckBallPositions();
        }   
    }
    void CheckBallPositions()
    {
        if (balls.Count != targetPositions.Count)
        {
            Debug.LogError("С��������Ŀ��λ��������ƥ�䣡");
            return;
        }

        for (int i = 0; i < balls.Count; i++)
        {
            Vector3 ballPosition = balls[i].transform.position;
            Vector3 targetPosition = targetPositions[i].position;

            // ���С���Ƿ���ָ��λ�ø���  
            if (Vector3.Distance(ballPosition, targetPosition) <= tolerance)
            {
             Debug.Log( balls[i].name + " ��ָ��λ�á�");
                count++;
            }
            else
            {
              Debug.Log(balls[i].name + " ����ָ��λ�á�");
                count--;
            }
        }
       // Debug.Log("count"+count);
        if (count== balls.Count)
        {
            cue.SetActive(false);

            Debug.Log("sucess!");
            if (isfirstsuccess)
            {
                isfirstsuccess = false;
                StartCoroutine(Delay());
                DoorController.Instance.OpenDoor();                
                Block.SetActive(false);
            }
           
        }
    }
     IEnumerator Delay()
      { 
        yield return new WaitForSeconds(10f);
       
        mainCamera.enabled = true;
        firstCamera.enabled = false;
          Debug.Log("delay10s");
      }
}
