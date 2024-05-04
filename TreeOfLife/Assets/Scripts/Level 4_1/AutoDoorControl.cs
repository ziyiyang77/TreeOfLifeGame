using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoorControl : MonoBehaviour
{
    public PlayerController controller;

    private bool playerIsNearTrigger = false;
    private bool isOpening = false;

    // Update is called once per frame
    void Update()
    {
        if (CardTrigger.isread&&playerIsNearTrigger && !isOpening)
        {
            isOpening = true;
            StartCoroutine(AutoDoorOpen());
        }
    }

    IEnumerator AutoDoorOpen()
    {
        controller.StopMovementAndAnimation();
        controller.enabled = false;
        DoorController.Instance.OpenDoor();
        yield return new WaitForSeconds(2);
        controller.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNearTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNearTrigger = false;
        }
    }
}
