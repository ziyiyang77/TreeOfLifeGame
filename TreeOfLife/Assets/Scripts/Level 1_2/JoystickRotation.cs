using UnityEngine;

public class JoystickRotation : MonoBehaviour
{
  
    public float rotationSpeed = 1000f; // 设置旋转速度  
    private float rotationZ = 0f; // 初始旋转角度  

    void Update()
    {
        Debug.Log("xuanzhuan");
        if (Input.GetMouseButtonDown(0)) // 当鼠标左键按下时  
        {
            rotationZ = transform.eulerAngles.z; // 记录初始旋转角度  
        }

        if (Input.GetMouseButton(0)) // 当鼠标左键按住时  
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad; // 获取鼠标X轴移动值并转换为弧度  
            rotationZ += mouseX; // 根据鼠标X轴移动值更新旋转角度  

            // 更新物体的旋转，仅更新Z轴  
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, rotationZ);
            transform.rotation = targetRotation;
        }
    }
}

