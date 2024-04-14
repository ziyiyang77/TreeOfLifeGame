using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckSucess : MonoBehaviour
{
  

    public Camera firstCamera;

    private Camera mainCamera;

    public float tolerance = 1f; // 用于判断位置是否匹配的容差  
    public List<Transform> ballTransforms; // 存放小球Transform的列表  
    public List<Transform> targetPositions; // 存放小球目标位置的列表  
    private int count = 0;
    private bool isfirstsuccess = true;

    void Start()
    {
        mainCamera = Camera.main;
        CheckBallPositions();
    }
    void Update()
    {
        count = 0;
        CheckBallPositions();
        
    }
    void CheckBallPositions()
    {
        if (ballTransforms.Count != targetPositions.Count)
        {
            Debug.LogError("小球数量和目标位置数量不匹配！");
            return;
        }

        for (int i = 0; i < ballTransforms.Count; i++)
        {
            Vector3 ballPosition = ballTransforms[i].position;
            Vector3 targetPosition = targetPositions[i].position;

            // 检查小球是否在指定位置附近  
            if (Vector3.Distance(ballPosition, targetPosition) <= tolerance)
            {
                Debug.Log("小球 " + i + " 在指定位置。"+ Vector3.Distance(ballPosition, targetPosition));
                count++;
            }
            else
            {
                Debug.Log("小球 " + i + " 不在指定位置。"+ Vector3.Distance(ballPosition, targetPosition));
                count--;
            }
        }
        Debug.Log("count"+count);
        if (count== ballTransforms.Count)
        { 
            mainCamera.enabled = true;
            firstCamera.enabled = false;
            Debug.Log("sucess!");
            if (isfirstsuccess)
            {
                isfirstsuccess = false;
                DoorController.Instance.OpenDoor();
            }
            //   SceneManager.LoadScene("Level 1_3");
        }
    }
}
