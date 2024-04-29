using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickYellowRotate : MonoBehaviour
{
    public Transform joystick; // 摇杆的Transform
    public Transform cube; // 长方体的Transform
    public float rotationSpeed = 50f; // 旋转速度

    private bool rotatingA = false; // 是否正在执行A键旋转
    private bool rotatingD = false; // 是否正在执行F键旋转

    public GameObject back;
    private AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();

    }
    void Update()
    {
        // 长按A键
        if (back.activeSelf && Input.GetKey(KeyCode.A))
        {
            rotatingA = true;
            rotatingD = false;
        }
        // 长按F键
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
            audio.Play();
            joystick.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            cube.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
           
        }
        else if (rotatingD)
        {
            audio.Play();
            joystick.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
            cube.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
        }
    }
}
