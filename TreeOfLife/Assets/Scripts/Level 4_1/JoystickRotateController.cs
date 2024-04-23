using UnityEngine;

public class JoystickRotateController : MonoBehaviour
{
    public Transform joystick; // ҡ�˵�Transform
    public Transform cube; // �������Transform
    public float rotationSpeed = 50f; // ��ת�ٶ�

    private bool rotatingA = false; // �Ƿ�����ִ��A����ת
    private bool rotatingF = false; // �Ƿ�����ִ��F����ת

    void Update()
    {
        // ����A��
        if (Input.GetKey(KeyCode.A))
        {
            rotatingA = true;
            rotatingF = false;
        }
        // ����F��
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

        // ���ݰ���״ִ̬�в���
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
