using UnityEngine;
using System.Collections;

public class TrunkController : MonoBehaviour
{
    public Transform pivot; // Assign this in the inspector
    public Collider blockingCollider; // Assign this in the inspector
    private bool isLayingDown = false;
    private float duration = 1.0f; // Duration of the animation in seconds
    private bool playerInArea = false;
    public GameObject cue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure your player GameObject has the tag "Player"
        {
            playerInArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInArea = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isLayingDown && playerInArea)
        {
            StartCoroutine(LayDownAnimation());
            isLayingDown = true;
        }

        if(playerInArea)
        {
            cue.SetActive(true);
        }
        else
        {
            cue.SetActive(false);
        }

    }

    IEnumerator LayDownAnimation()
    {
        Quaternion startRotation = pivot.rotation;
        Quaternion endRotation = Quaternion.Euler(pivot.eulerAngles.x, pivot.eulerAngles.y, pivot.eulerAngles.z - 90);

        float time = 0;
        while (time < duration)
        {
            pivot.rotation = Quaternion.Lerp(startRotation, endRotation, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        pivot.rotation = endRotation;
        blockingCollider.enabled = false; // Disable the blocking collider
    }
}

