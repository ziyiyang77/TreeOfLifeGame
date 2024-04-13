using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPuzzleController : MonoBehaviour
{
    private List<int> currentMerrybellsOrder = new List<int>();
    private int currentPuzzleIndex = 0;
    public AudioSource wrongSoundSource;
    private int[][] correctOrders = new int[][]
    {
        new int[] { 1 },
        new int[] { 1, 2 },
    };
    private float lastInteractionTime = 0f;
    private CrawSinger crawSinger;
    public List<Light> pointLights; // Reference to the point lights

    void Start()
    {
        crawSinger = FindObjectOfType<CrawSinger>();
        UpdatePointLights();
    }

    public void HandleMerrybellActivated(int activatedMerrybellId)
    {
        if (Time.time - lastInteractionTime > 30)
        {
            ResetPuzzle();
        }
        else
        {
            currentMerrybellsOrder.Add(activatedMerrybellId);
            CheckOrder();
        }

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
        }
    }

    void ResetPuzzle()
    {
        currentMerrybellsOrder.Clear();
    }

    void UpdatePointLights()
    {
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
        Color originalColor = pointLights[0].color; // Assuming all lights start with the same color

        foreach (var light in pointLights)
        {
            light.color = Color.red;
            light.enabled = true;
        }

        yield return new WaitForSeconds(2); // Wait for 2 seconds

        foreach (var light in pointLights)
        {
            light.color = originalColor;
        }

        UpdatePointLights(); // Restore the lighting state based on puzzle progress
    }
}
