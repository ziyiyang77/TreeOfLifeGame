using UnityEngine;

public class CheckRange: MonoBehaviour
{
    public GameObject objectToDetect; // 要检测的物体
    public float minRange = 0.0f; // 允许的最小范围
    public float maxRange = 0.5f; // 允许的最大范围
    public bool flag = false;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, objectToDetect.transform.position);

        //Debug.Log("the distance is" + distance);
        if (distance >= minRange && distance <= maxRange)
        {
            // 物体在正确的范围内
           // Debug.Log("Object is in the correct range."+ distance);
            flag = true;
        }
        else
        {
            flag = false;
            // 物体不在正确的范围内
          //  Debug.Log("Object is not in the correct range.");
        }
    }
}