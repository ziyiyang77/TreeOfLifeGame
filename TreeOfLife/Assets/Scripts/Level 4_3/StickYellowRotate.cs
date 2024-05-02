using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickYellowRotate : MonoBehaviour
{
    public Transform joystick; // ҡ�˵�Transform
    public Transform cube; // �������Transform
    public float rotationSpeed = 50f; // ��ת�ٶ�

    private bool rotatingA = false; // �Ƿ�����ִ��A����ת
    private bool rotatingD = false; // �Ƿ�����ִ��F����ת

    public GameObject back;
    private AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();

    }
    void Update()
    {
        // ����A��
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
