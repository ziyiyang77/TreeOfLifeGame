using UnityEngine;

public class SlideController : MonoBehaviour
{
    public Transform joystick; // 摇杆的Transform
    public Transform slider; // 滑块的Transform
    public float rotationSpeed = 50f; // 摇杆旋转速度
    public float slideSpeed = 2f; // 滑块滑动速度

    private bool rotatingA = false; // 是否正在执行A键旋转
    private bool rotatingD = false; // 是否正在执行F键旋转

   // private bool stopRotation = false;
    public float minAngle = -60f;
    public float maxAngle = 300f;

    public GameObject back;
    public GameObject A;
    public GameObject D;

    private void Start()
    {
        A.SetActive(false);
        D.SetActive(false);
    }
    void Update()
    {
        Debug.Log(joystick.rotation.eulerAngles.z);
        // 长按A键
        if (back.activeSelf&& Input.GetKey(KeyCode.A))
        {
            rotatingA = true;
            rotatingD = false;
        }
        // 长按D键
        else if (back.activeSelf && Input.GetKey(KeyCode.D))
        {
            rotatingA = false;
            rotatingD = true;
        }
        else
        {
            rotatingA = false;
            rotatingD = false;
        }

        // 根据按键状态执行操作
        if (rotatingA)
        {
            if (joystick.rotation.eulerAngles.z <= maxAngle)
            {
                joystick.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
                slider.Translate(Vector3.left * slideSpeed * Time.deltaTime);
            }
            
        }
        else if (rotatingD)
        {
            if (joystick.rotation.eulerAngles.z>=minAngle)
            {
                joystick.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
                slider.Translate(Vector3.right * slideSpeed * Time.deltaTime);
            }
        }
    }
}
