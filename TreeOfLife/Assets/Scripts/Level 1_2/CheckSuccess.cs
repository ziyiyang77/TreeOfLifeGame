using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckSucess : MonoBehaviour
{
    public Camera firstCamera;
    private Camera mainCamera;

    public float tolerance = 0.01f; // 用于判断位置是否匹配的容差  
    public List<GameObject> balls; // 存放小球Transform的列表  
    public List<Transform> targetPositions; // 存放小球目标位置的列表  
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
            Debug.LogError("小球数量和目标位置数量不匹配！");
            return;
        }

        for (int i = 0; i < balls.Count; i++)
        {
            Vector3 ballPosition = balls[i].transform.position;
            Vector3 targetPosition = targetPositions[i].position;

            // 检查小球是否在指定位置附近  
            if (Vector3.Distance(ballPosition, targetPosition) <= tolerance)
            {
             Debug.Log( balls[i].name + " 在指定位置。");
                count++;
            }
            else
            {
              Debug.Log(balls[i].name + " 不在指定位置。");
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
