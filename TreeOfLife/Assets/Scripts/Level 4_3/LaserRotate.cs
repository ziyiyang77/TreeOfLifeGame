using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserRotate : MonoBehaviour
{
    [Header("Settings")]
    public LayerMask layerMask;
    private float defaultLength = 100f;
    public int numOfReflections = 3;

    private LineRenderer _lineRenderer;
    private Camera _mycam;
    private RaycastHit hit;

    private Ray ray;
    private Vector3 direction;

    public Light pointlight;
    public GameObject endpoint;
    private bool isLastObjectHit = false;

    public GameObject doortrigger;
    private bool isopening = false;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _mycam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {    
       ReflectLaser();
      
    }
    void ReflectLaser()
    {
        ray = new Ray(transform.position, transform.forward);
        _lineRenderer.positionCount = 1;
        _lineRenderer.SetPosition(0, transform.position);

        float remainLength = defaultLength;

        int i;
        for (i = 0; i < numOfReflections; i++)
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit, remainLength, layerMask))
            {
                _lineRenderer.positionCount += 1;
                _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, hit.point);

                remainLength -= Vector3.Distance(ray.origin, hit.point);

                ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
                if (hit.collider.transform == endpoint.transform)
                {
                    //    Debug.Log("succss!");
                    doortrigger.SetActive(false);
                    if (isopening == false)
                    {
                        Debug.Log("open!");
                        isopening = true;
                        animator.SetBool("doorclose", false);
                        animator.SetBool("dooropen", true);
                       

                    }

                    isLastObjectHit = true;
                    pointlight.color = Color.green;
                    break;
                }
            }
            else
            {
                if (isopening)
                {
                    Debug.Log("close!");
                    isopening = false;
                    animator.SetBool("dooropen", false);
                    animator.SetBool("doorclose", true);
                }
               // isfirstopen = true;
                doortrigger.SetActive(true);
                _lineRenderer.positionCount += 1;
                _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, ray.origin + (ray.direction * remainLength));
                isLastObjectHit = false;
                pointlight.color = Color.red;
            }
        }

    }
    void NormalLaser()
    {
        _lineRenderer.SetPosition(0, transform.position);
        if (Physics.Raycast(transform.position, transform.forward, out hit, defaultLength, layerMask))
        {
            _lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            _lineRenderer.SetPosition(1, transform.position + (transform.forward * defaultLength));
        }
    }
}
