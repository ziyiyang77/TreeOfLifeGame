using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    public Camera myCam;
    private Vector3 screenPos;
    private float angleOffset;

    BoxCollider boxCollider;
 //   private Collider2D circleCollider2D;
    private bool isDragging=false;

    void Start()
    {
       boxCollider = GetComponent<BoxCollider>();
      //  circleCollider2D = GetComponent<Collider2D>();
      
    }
    private void OnMouseDown()
    {
            if (isDragging )
            {
                screenPos = myCam.WorldToScreenPoint(transform.position);
                Vector3 vec3 = Input.mousePosition - screenPos;
                angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;
               // isDragging = true;
            }
           
    }

    private void OnMouseDrag()
    {
            if (isDragging )
            {
                Vector3 vec3 = Input.mousePosition - screenPos;
                float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, 0, angle + angleOffset);
            }
            
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void Update()
    {
        Ray ray = myCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider == boxCollider)
            {
                isDragging = true;
            }                      
        }
       

    }
}
