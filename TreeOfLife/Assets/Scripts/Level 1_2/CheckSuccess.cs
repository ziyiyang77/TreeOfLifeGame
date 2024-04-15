using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckSucess : MonoBehaviour
{
    public Camera firstCamera;
    private Camera mainCamera;

    public float tolerance = 0.3f; // 用于判断位置是否匹配的容差  
    public List<GameObject> balls; // 存放小球Transform的列表  
    public List<Transform> targetPositions; // 存放小球目标位置的列表  
    private  int count = 0;
    public static bool isfirstsuccess = true;

    public GameObject cue; //F sprite
    public GameObject Block;
    public GameObject SceneSwitcher;

    private CircleCollider2D circleCollider2D;
    private List<GameObject> gameObjects;

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
            //   Debug.Log("小球 " + i + " 在指定位置。"+ Vector3.Distance(ballPosition, targetPosition));
                count++;
            }
            else
            {
             //  Debug.Log("小球 " + i + " 不在指定位置。"+ Vector3.Distance(ballPosition, targetPosition));
                count--;
            }
        }
        Debug.Log("count"+count);
        if (count== balls.Count)
        {
            cue.SetActive(false);

            Debug.Log("sucess!");
            if (isfirstsuccess)
            {
                isfirstsuccess = false;
              
                Debug.Log("jinyong");
                StartCoroutine(Delay());

                DoorController.Instance.OpenDoor();
                SceneSwitcher.SetActive(true);
                SceneTransitionManager.Instance.LoadScene("forest1.4");
              //  SceneManager.LoadScene("forest1.4");
                Block.SetActive(false);
            }
           
        }
    }
     IEnumerator Delay()
      { 
        yield return new WaitForSeconds(10f);
       
        mainCamera.enabled = true;
        firstCamera.enabled = false;
        // 这里是延时一帧后执行的代码
          Debug.Log("delay10s");
      }
}
