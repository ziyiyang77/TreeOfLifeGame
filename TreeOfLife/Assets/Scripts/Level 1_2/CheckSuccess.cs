using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckSucess : MonoBehaviour
{
  

    public Camera firstCamera;

    private Camera mainCamera;

    public float tolerance = 1f; // �����ж�λ���Ƿ�ƥ����ݲ�  
    public List<Transform> ballTransforms; // ���С��Transform���б�  
    public List<Transform> targetPositions; // ���С��Ŀ��λ�õ��б�  
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
            Debug.LogError("С��������Ŀ��λ��������ƥ�䣡");
            return;
        }

        for (int i = 0; i < ballTransforms.Count; i++)
        {
            Vector3 ballPosition = ballTransforms[i].position;
            Vector3 targetPosition = targetPositions[i].position;

            // ���С���Ƿ���ָ��λ�ø���  
            if (Vector3.Distance(ballPosition, targetPosition) <= tolerance)
            {
                Debug.Log("С�� " + i + " ��ָ��λ�á�"+ Vector3.Distance(ballPosition, targetPosition));
                count++;
            }
            else
            {
                Debug.Log("С�� " + i + " ����ָ��λ�á�"+ Vector3.Distance(ballPosition, targetPosition));
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
