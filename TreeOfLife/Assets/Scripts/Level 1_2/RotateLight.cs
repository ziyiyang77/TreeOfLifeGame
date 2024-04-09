using UnityEngine;

public class RotateLight : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Transform rodTransform;

    private void Start()
    {
        // 获取圆形杆的Transform组件
        rodTransform = GameObject.Find("guidao").transform;
    }

    private void OnMouseDown()
    {
        // 计算鼠标点击位置和小球中心的偏移量
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            // 计算拖动后的位置
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)) + offset;
            // 将位置限制在圆形杆的表面上
            newPosition = LimitToRod(newPosition);
            // 更新小球的位置
            transform.position = newPosition;
        }
    }

    private Vector3 LimitToRod(Vector3 newPosition)
    {
        // 计算新位置相对于圆形杆中心的向量
        Vector3 direction = newPosition - rodTransform.position;
        // 将方向向量限制在圆形杆半径上 2.8f是圆的半径长度
        direction = direction.normalized * 2.5f;
        // 限制小球位置在圆形杆的表面上
        newPosition = rodTransform.position + direction;
        return newPosition;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }
}
