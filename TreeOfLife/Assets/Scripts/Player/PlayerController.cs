using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10; // This can be set to 0 initially or by other scripts
    public float groundDist;


    public LayerMask terrainLayer;
    public Rigidbody rb;
    public SpriteRenderer sr;
    private Animator animator; // Reference to the Animator component
    private PlayerSound playerSound; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        playerSound = GetComponentInChildren<PlayerSound>();
    }

    void Update()
    {
        if (DialogueManager.GetInstance() && DialogueManager.GetInstance().dialogueIsPlaying)
        {
            StopMovementAndAnimation();
            return;
        }

        GroundPositionAdjustment();
        HandleMovement();
        FlipSpriteBasedOnDirection();
    }

    public void StopMovementAndAnimation()
    {
        rb.velocity = Vector3.zero;
        animator.SetBool("isWalking", false);
    }

    private void GroundPositionAdjustment()
    {
        RaycastHit hit;
        Vector3 castPos = transform.position + Vector3.up; // Simplified adjustment
        if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
        {
            if (hit.collider != null)
            {
                transform.position = new Vector3(transform.position.x, hit.point.y + groundDist, transform.position.z);
            }
        }
    }

    private void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(x, 0, y);
        rb.velocity = moveDir * speed;

        if(x != 0)
        {
            playerSound.PlayFootstep();
        }

        // Update walking animation state
        animator.SetBool("isWalking", moveDir.magnitude > 0 && speed > 0);
    }

    private void FlipSpriteBasedOnDirection()
    {
        float x = Input.GetAxis("Horizontal");
        if (x < 0)
        {
            sr.flipX = true;
        }
        else if (x > 0)
        {
            sr.flipX = false;
        }
    }
}
