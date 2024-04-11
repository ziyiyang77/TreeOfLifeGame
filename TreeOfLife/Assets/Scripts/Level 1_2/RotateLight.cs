using UnityEngine;

public class RotateLight : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    public Transform rodTransform;
    public float radius=2.53f;//The plate radius is 2.53f
   

    private void Start()
    {
        
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
            
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)) + offset;
          
            newPosition = LimitToRod(newPosition);
            
            transform.position = newPosition;
        }
    }

    private Vector3 LimitToRod(Vector3 newPosition)
    {
        
        Vector3 direction = newPosition - rodTransform.position;
     
        direction = direction.normalized * radius; 
        
        newPosition = rodTransform.position + direction;
        return newPosition;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }
}
