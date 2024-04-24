using UnityEngine;

public class JoystickRotateController : MonoBehaviour
{
    public Transform joystick; // 摇杆的Transform
    public Transform cube; // 长方体的Transform
    public float rotationSpeed = 50f; // 旋转速度

    private bool rotatingA = false; // 是否正在执行A键旋转
    private bool rotatingF = false; // 是否正在执行F键旋转

    void Update()
    {
        // 长按A键
        if (Input.GetKey(KeyCode.A))
        {
            rotatingA = true;
            rotatingF = false;
        }
        // 长按F键
        else if (Input.GetKey(KeyCode.D))
        {
            rotatingA = false;
            rotatingF = true;
        }
        else
        {
            rotatingA = false;
            rotatingF = false;
        }

        // 根据按键状态执行操作
        if (rotatingA)
        {
            joystick.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            cube.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
        }
        else if (rotatingF)
        {
            joystick.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
            cube.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
}
