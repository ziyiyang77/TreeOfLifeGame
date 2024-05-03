using System.Collections;
using UnityEngine;

public class CrawSinger : MonoBehaviour
{
    public GameObject notePrefab;
    public AudioClip[] noteSounds;
    public AudioSource noteAudioSource;
    private int[][] noteSequences = new int[][]
    {
        new int[] { 0, 4, 1 },
        new int[] { 2, 0, 4, 5 },
        new int[] { 2, 5, 6, 4, 1 },
        new int[] { 4, 2, 1, 0, 5, 2 }
    };
    private int currentPuzzleIndex = 0;

    void Start()
    {
        StartCoroutine(SingNotes());
    }

    private void OnDisable()
    {
        StopAllCoroutines();  // This will stop all coroutines when the script is disabled
    }

    IEnumerator SingNotes()
    {
        while (currentPuzzleIndex < noteSequences.Length)
        {
            yield return new WaitForSeconds(2);
            int[] currentSequence = noteSequences[currentPuzzleIndex];
            float startTime = Time.time;

            for (int i = 0; i < currentSequence.Length; i++)
            {
                Vector3 notePosition = transform.position + new Vector3(0, GetVerticalPosition(currentSequence[i]), 0);
                GameObject noteInstance = Instantiate(notePrefab, notePosition, Quaternion.identity);

                if (noteAudioSource != null && currentSequence[i] < noteSounds.Length)
                {
                    noteAudioSource.clip = noteSounds[currentSequence[i]];
                    noteAudioSource.Play();
                }
                else
                {
                    Debug.LogError("AudioSource component missing on note prefab, or note index out of range.");
                }

                yield return new WaitForSeconds(1);
            }

            yield return new WaitForSeconds(10);
        }
    }

    private float GetVerticalPosition(int pitchIndex)
    {
        // Modify this formula as needed to adjust the pitch representation
        return (pitchIndex - 3) * 0.5f; // Centralizes middle C and spreads other notes
    }

    public void AdvanceToNextPuzzle()
    {
        if (currentPuzzleIndex < noteSequences.Length - 1)
        {
            currentPuzzleIndex++;
            StopAllCoroutines();
            StartCoroutine(SingNotes());
        }
        else
        {
            Debug.Log("All puzzles completed.");
        }
    }
}
