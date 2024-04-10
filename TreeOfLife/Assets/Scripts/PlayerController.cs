using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float groudDist;

    public LayerMask terrainLayer;
    public Rigidbody rb;
    public SpriteRenderer sr;
    private Animator animator; // Reference to the Animator component

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (DialogueManager.GetInstance() && DialogueManager.GetInstance().dialogueIsPlaying)
        {
            Vector3 vec = Vector3.zero;
            rb.velocity = vec * speed;
            animator.SetBool("isWalking", false); // Ensure the walking animation stops during dialogue
            return;
        }

        RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1;
        if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
        {
            if (hit.collider != null)
            {
                Vector3 movPos = transform.position;
                movPos.y = hit.point.y + groudDist;
                transform.position = movPos;
            }
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(x, 0, y);
        rb.velocity = moveDir * speed;

        // Determine if the player is walking based on movement input
        bool isWalking = moveDir.magnitude > 0;
        animator.SetBool("isWalking", isWalking); // Update the Animator's isWalking parameter

        if (x != 0 && x < 0)
        {
            sr.flipX = true;
        }
        else if (x != 0 && x > 0)
        {
            sr.flipX = false;
        }

    }
}
