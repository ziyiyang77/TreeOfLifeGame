using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPuzzleController : MonoBehaviour
{
    private List<int> currentMerrybellsOrder = new List<int>();
    private int currentPuzzleIndex = 0;
    public AudioSource wrongSoundSource;
    public AudioSource bgmSource;           // AudioSource for the background music
    public AudioClip merybellClip;      // AudioClip for the special music when all puzzles are completed
    public AudioClip newBgmClip;            // AudioClip for the new background music

    private int[][] correctOrders = new int[][]
    {
        new int[] { 0, 4, 1 },
        new int[] { 2, 0, 4, 5 },
        new int[] { 2, 5, 6, 4, 1 },
        new int[] { 4, 2, 1, 0, 5, 2 }
    };
    public float lastInteractionTime = -1f;
    private CrawSinger crawSinger;
    public List<Light> pointLights; // Reference to the point lights
    private Color Green;


    void Start()
    {
        crawSinger = FindObjectOfType<CrawSinger>();
        Green = pointLights[0].color;
        UpdatePointLights();
    }

    public void HandleMerrybellActivated(int activatedMerrybellId)
    {
        if (lastInteractionTime == -1)
        {
            lastInteractionTime = Time.time;
        }
        else if (Time.time - lastInteractionTime > 30)
        {
            ResetPuzzle();
        }

        currentMerrybellsOrder.Add(activatedMerrybellId);
        Debug.Log("add " + activatedMerrybellId);
        CheckOrder();

        lastInteractionTime = Time.time;
    }


    void CheckOrder()
    {
        int[] currentCorrectOrder = correctOrders[currentPuzzleIndex];

        for (int i = 0; i < currentMerrybellsOrder.Count; i++)
        {
            if (i >= currentCorrectOrder.Length || currentMerrybellsOrder[i] != currentCorrectOrder[i])
            {
                wrongSoundSource.Play();
                StartCoroutine(FlashLights());
                ResetPuzzle();
                return;
            }
        }

        if (currentMerrybellsOrder.Count == currentCorrectOrder.Length)
        {
            Debug.Log("Puzzle Solved!");
            AdvanceToNextPuzzle();
            UpdatePointLights();
        }
    }

    void AdvanceToNextPuzzle()
    {
        if (currentPuzzleIndex < correctOrders.Length - 1)
        {
            currentPuzzleIndex++;
            ResetPuzzle();
            crawSinger.AdvanceToNextPuzzle();
        }
        else
        {
            currentPuzzleIndex++;
            Debug.Log("All puzzles completed.");
            crawSinger.enabled = false;

            StartCoroutine(SwitchBackgroundMusicAfterClipEnds());
        }
    }

    void ResetPuzzle()
    {
        currentMerrybellsOrder.Clear();
    }

    void UpdatePointLights()
    {
        foreach (var light in pointLights)
        {
            light.color = Green;
        }
        for (int i = 0; i < pointLights.Count; i++)
        {
            if (i < currentPuzzleIndex)
                pointLights[i].enabled = true;
            else
                pointLights[i].enabled = false;
        }
    }

    IEnumerator FlashLights()
    {
        Color originalColor = pointLights[0].color;

        foreach (var light in pointLights)
        {
            light.color = Color.red;
            light.enabled = true;
        }

        yield return new WaitForSeconds(2);

        foreach (var light in pointLights)
        {
            light.color = originalColor;
        }

        UpdatePointLights();
    }

    IEnumerator SwitchBackgroundMusicAfterClipEnds()
    {
        bgmSource.clip = merybellClip; // Change to special music clip
        yield return new WaitForSeconds(2);
        bgmSource.Play();
        yield return new WaitForSeconds(merybellClip.length-4);
        bgmSource.clip = newBgmClip; // Change back to the new BGM
        bgmSource.Play();

        DoorController.Instance.OpenDoor();
    }
}
