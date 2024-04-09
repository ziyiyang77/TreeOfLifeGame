using UnityEngine;

public class CheckRange: MonoBehaviour
{
    public GameObject objectToDetect; // 要检测的物体
    public float minRange = 0.0f; // 允许的最小范围
    public float maxRange = 6.0f; // 允许的最大范围

    void Update()
    {
        float distance = Vector3.Distance(transform.position, objectToDetect.transform.position);

        if (distance >= minRange && distance <= maxRange)
        {
            // 物体在正确的范围内
            Debug.Log("Object is in the correct range."+ distance);
        }
        else
        {
            // 物体不在正确的范围内
            Debug.Log("Object is not in the correct range.");
        }
    }
}