using System.Collections.Generic;
using UnityEngine;

public class MusicPuzzleController : MonoBehaviour
{
    private List<int> currentMerrybellsOrder = new List<int>();
    private int currentPuzzleIndex = 0;
    public AudioSource wrongSoundSource;
    private int[][] correctOrders = new int[][]
    {
        new int[] { 0, 1, 2, 3, 4 },
        new int[] { 1, 4, 4, 2, 3 },
    };
    private float lastInteractionTime = 0f;
    private CrawSinger crawSinger;

    void Start()
    {
        crawSinger = FindObjectOfType<CrawSinger>();
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
                ResetPuzzle();
                return;
            }
        }

        if (currentMerrybellsOrder.Count == currentCorrectOrder.Length)
        {
            Debug.Log("Puzzle Solved!");
            AdvanceToNextPuzzle();
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
            Debug.Log("All puzzles completed.");
        }
    }

    void ResetPuzzle()
    {
        currentMerrybellsOrder.Clear();
    }
}
