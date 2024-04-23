using UnityEngine;

public class SlideController : MonoBehaviour
{
    public Transform joystick; // ҡ�˵�Transform
    public Transform slider; // �����Transform
    public float rotationSpeed = 50f; // ҡ����ת�ٶ�
    public float slideSpeed = 2f; // ���黬���ٶ�

    private bool rotatingA = false; // �Ƿ�����ִ��A����ת
    private bool rotatingD = false; // �Ƿ�����ִ��F����ת

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
        // ����A��
        if (back.activeSelf&& Input.GetKey(KeyCode.A))
        {
            rotatingA = true;
            rotatingD = false;
        }
        // ����D��
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

        // ���ݰ���״ִ̬�в���
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
