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
    public float minAngle = -90f;
    public float maxAngle = 90f;
    private float stickz;
    private float laststickz;

    public GameObject back;
    private AudioSource audio;
    public AudioClip down;
    public AudioClip hold;
    public AudioClip up;
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
        if (back.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                audio.clip = down;
                audio.Play(); 
                rotatingA = true;
            }
            if (Input.GetKey(KeyCode.A) && rotatingA)
            {
                if (!audio.isPlaying)
                {
                    audio.clip = hold;
                    audio.Play();
                   
                }
                stickz += Time.deltaTime * rotationSpeed;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                rotatingD = true;
                audio.clip = down;
                audio.Play();

            }
            if (Input.GetKey(KeyCode.D) && rotatingD)
            {
                if (!audio.isPlaying)
                {
                    audio.clip = hold;
                    audio.Play();

                }
                stickz -= Time.deltaTime * rotationSpeed;
            }
            stickz = ClampAngle(stickz, minAngle, maxAngle);
            Quaternion quaternion = Quaternion.Euler(0, 0, stickz);
            joystick.localRotation = quaternion;

            //��������
            if (stickz != laststickz)
            {
                if (rotatingD)
                    slider.Translate(Vector3.right * slideSpeed * Time.deltaTime);
                else slider.Translate(Vector3.left * slideSpeed * Time.deltaTime);
                laststickz = stickz;
            }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                audio.clip = up;
                audio.Play();
                rotatingA = false;
                rotatingD = false;
            }
        }  
    }
}
