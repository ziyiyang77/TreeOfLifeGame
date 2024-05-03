using System.Collections;
using UnityEngine;

public class PuzzlesManager : MonoBehaviour
{
    public ElectricityPuzzleManager[] puzzles; // Array of puzzle managers
    public GameObject[] indicators; // Array of indicator GameObjects
    public Sprite sprite1; // Default sprite
    public Sprite sprite2; // Sprite to show when the puzzle is solved

    private bool[] puzzlesSolved; // Track if each puzzle is solved

    void Start()
    {
        puzzlesSolved = new bool[puzzles.Length];
        for (int i = 0; i < puzzles.Length; i++)
        {
            puzzles[i].gameObject.SetActive(i == 0); // Activate only the first puzzle initially
        }
    }

    void Update()
    {
        for (int i = 0; i < puzzles.Length; i++)
        {
            if (!puzzlesSolved[i] && puzzles[i].isSolved)
            {
                Debug.Log("solve");
                puzzlesSolved[i] = true;
                UpdateIndicator(i);
                puzzles[i].inputEnabled = false;
                if (i < puzzles.Length - 1)
                {
                    StartCoroutine(ActivateNextPuzzleAfterDelay(i + 1)); // Start coroutine to activate the next puzzle after a delay
                }
            }
        }

        if (AllPuzzlesSolved())
        {
            puzzles[1].isLastPuzzles = true;
        }
    }

    private void UpdateIndicator(int index)
    {
        if (indicators.Length > index)
        {
            var indicator = indicators[index];
            if (indicator.GetComponent<SpriteRenderer>())
            {
                indicator.GetComponent<SpriteRenderer>().sprite = sprite2;
            }
        }
    }

    IEnumerator ActivateNextPuzzleAfterDelay(int puzzleIndex)
    {
        yield return new WaitForSeconds(2); // Wait for 2 seconds
        puzzles[puzzleIndex - 1].puzzle.SetActive(false);
        puzzles[puzzleIndex - 1].gameObject.SetActive(false);
        puzzles[puzzleIndex].gameObject.SetActive(true); // Activate the next puzzle
        puzzles[puzzleIndex].puzzle.SetActive(true);
    }

    private bool AllPuzzlesSolved()
    {
        foreach (bool solved in puzzlesSolved)
        {
            if (!solved) return false;
        }
        return true;
    }
}
