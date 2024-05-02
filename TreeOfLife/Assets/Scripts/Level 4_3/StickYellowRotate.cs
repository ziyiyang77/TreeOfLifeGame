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
        if (back.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                audio.Play();
                rotatingA = true;        
            }
            if (Input.GetKey(KeyCode.A) && rotatingA)
            {
                if (!audio.isPlaying)
                {
                    audio.Play();
                }
                joystick.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
                cube.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                rotatingD = true;
                audio.Play();
               
            }
            if (Input.GetKey(KeyCode.D) && rotatingD)
            {
                if (!audio.isPlaying)
                {
                    audio.Play();
                }
                joystick.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
                cube.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
            }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                audio.Stop();
                rotatingA = false;
                rotatingD = false;
            }
        }
       
    }
}
