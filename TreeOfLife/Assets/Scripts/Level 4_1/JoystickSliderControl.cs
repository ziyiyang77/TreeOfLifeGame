using UnityEngine;

public class JoystickSliderControl : MonoBehaviour
{
    // 摇杆对象
    public Transform joystick;

    // 滑块对象
    public Transform slider;

    // 控制滑块移动的速度
    public float moveSpeed = 1f;

    // 摇杆旋转的最小角度
    public float minAngle = 0f;

    // 摇杆旋转的最大角度
    public float maxAngle = 180f;

    void Update()
    {
        // 获取摇杆旋转的角度
        float angle = Mathf.Clamp(joystick.localEulerAngles.z, minAngle, maxAngle);

        // 计算滑块移动的距离
        float moveDistance = (angle - minAngle) / (maxAngle - minAngle) * moveSpeed * Time.deltaTime;

        // 检测按键输入，并根据摇杆旋转方向移动滑块
        if (Input.GetKey(KeyCode.A))
        {
            slider.Translate(Vector3.left * moveDistance);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            slider.Translate(Vector3.right * moveDistance);
        }
    }
}
