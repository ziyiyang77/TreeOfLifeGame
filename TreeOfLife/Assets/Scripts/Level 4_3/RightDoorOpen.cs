using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDoorOpen : MonoBehaviour
{
    public static RightDoorOpen Instance { get; private set; }

    public GameObject leftPanel;
    public AudioClip openSound;
    public float openDistance = 2f;
    public float openSpeed = 1f;

    private AudioSource audioSource;
    private Vector3 leftPanelClosedPosition;
    private Vector3 rightPanelClosedPosition;
    private bool isOpening = false;

   // public GameObject SceneSwitcher;
  //  public GameObject Block;
  //  public GameObject DoorLight;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            audioSource = GetComponent<AudioSource>();
            leftPanelClosedPosition = leftPanel.transform.position;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OpenDoor()
    {
        if (!isOpening)
        {
            isOpening = true;
            StartCoroutine(OpenDoorRoutine());
        }
        Debug.Log("door switcher ");
     //   SceneSwitcher.SetActive(true);
     //   Block.SetActive(false);
     //   DoorLight.SetActive(true);
    }

    private IEnumerator OpenDoorRoutine()
    {
        audioSource.PlayOneShot(openSound);
        float elapsedTime = 0;
        Vector3 leftTarget = leftPanelClosedPosition + new Vector3(0, 0, -openDistance);
        Vector3 rightTarget = rightPanelClosedPosition + new Vector3(0, 0, openDistance);

        while (elapsedTime < openSpeed)
        {
            leftPanel.transform.position = Vector3.Lerp(leftPanelClosedPosition, leftTarget, (elapsedTime / openSpeed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        leftPanel.transform.position = leftTarget;
        isOpening = false;
    }
}
