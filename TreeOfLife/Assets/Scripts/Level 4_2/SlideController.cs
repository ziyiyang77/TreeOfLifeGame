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
    public float minAngle = -90f;
    public float maxAngle = 90f;
    private float stickz;
    private float laststickz;

    public GameObject back;
    AudioSource audio;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        stickz = joystick.localEulerAngles.z;
        laststickz = stickz;
    }
    public float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }

        if (angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }

    void Update()
    {
        if (back.activeSelf&& Input.GetKey(KeyCode.A))
        {
            rotatingA = true;
            rotatingD = false;
        }
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
        //长按
        if (rotatingD)
        {
            stickz -= Time.deltaTime * rotationSpeed;
            audio.Play();
        }
        else if (rotatingA)
        {
            stickz += Time.deltaTime * rotationSpeed;
            audio.Play();
        }
        stickz = ClampAngle(stickz, minAngle, maxAngle);
        Quaternion quaternion = Quaternion.Euler(0,0,stickz);
        joystick.localRotation = quaternion;
       
        //设置联动
        if (stickz != laststickz)
        {
            if(rotatingD)
              slider.Translate(Vector3.right * slideSpeed * Time.deltaTime);
            else slider.Translate(Vector3.left * slideSpeed * Time.deltaTime);
            laststickz = stickz;
        }
        
    }
}
