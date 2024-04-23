using UnityEngine;

public class JoystickSliderControl : MonoBehaviour
{
    // ҡ�˶���
    public Transform joystick;

    // �������
    public Transform slider;

    // ���ƻ����ƶ����ٶ�
    public float moveSpeed = 1f;

    // ҡ����ת����С�Ƕ�
    public float minAngle = 0f;

    // ҡ����ת�����Ƕ�
    public float maxAngle = 180f;

    void Update()
    {
        // ��ȡҡ����ת�ĽǶ�
        float angle = Mathf.Clamp(joystick.localEulerAngles.z, minAngle, maxAngle);

        // ���㻬���ƶ��ľ���
        float moveDistance = (angle - minAngle) / (maxAngle - minAngle) * moveSpeed * Time.deltaTime;

        // ��ⰴ�����룬������ҡ����ת�����ƶ�����
        if (Input.GetKey(KeyCode.A))
        {
            slider.Translate(Vector3.left * moveDistance);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            slider.Translate(Vector3.right * moveDistance);
        }
    }
}
