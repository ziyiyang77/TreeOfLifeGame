using UnityEngine;

public class JoystickRotation : MonoBehaviour
{
  
    public float rotationSpeed = 1000f; // ������ת�ٶ�  
    private float rotationZ = 0f; // ��ʼ��ת�Ƕ�  

    void Update()
    {
        Debug.Log("xuanzhuan");
        if (Input.GetMouseButtonDown(0)) // ������������ʱ  
        {
            rotationZ = transform.eulerAngles.z; // ��¼��ʼ��ת�Ƕ�  
        }

        if (Input.GetMouseButton(0)) // ����������סʱ  
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad; // ��ȡ���X���ƶ�ֵ��ת��Ϊ����  
            rotationZ += mouseX; // �������X���ƶ�ֵ������ת�Ƕ�  

            // �����������ת��������Z��  
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, rotationZ);
            transform.rotation = targetRotation;
        }
    }
}

