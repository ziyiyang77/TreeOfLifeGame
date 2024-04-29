using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickRotateController : MonoBehaviour
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
        if (back.activeSelf&&Input.GetKey(KeyCode.A))
        {
            rotatingA = true;
            rotatingD = false;
           
        }
        // ����F��
        else if (back.activeSelf&&Input.GetKey(KeyCode.D))
        {
            rotatingA = false;
            rotatingD = true;
           
        }
        else
        {
            rotatingA = false;
            rotatingD = false;
        }

        // ���ݰ���״ִ̬�в���
        if (rotatingA)
        {
            audio.Play();
            joystick.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            cube.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
        }
        else if (rotatingD)
        {
            audio.Play();
            joystick.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
            cube.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
        else
        {
           audio.Stop();
        }
    }
}
