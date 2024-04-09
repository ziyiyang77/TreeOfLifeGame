using System.Collections;
using UnityEngine;

public class CrawSinger : MonoBehaviour
{
    public GameObject notePrefab; 
    public AudioClip[] noteSounds;
    public AudioSource noteAudioSource;
    private int[][] noteSequences = new int[][]
    {
        new int[] { 0, 1, 2, 3, 4 }, 
        new int[] { 1, 4, 4, 2, 3 }, 
        
    };
    private int currentPuzzleIndex = 0;

    void Start()
    {
        StartCoroutine(SingNotes());
    }

    IEnumerator SingNotes()
    {
        while (currentPuzzleIndex < noteSequences.Length)
        {
            yield return new WaitForSeconds(5);
            int[] currentSequence = noteSequences[currentPuzzleIndex];
            float startTime = Time.time;

            for (int i = 0; i < currentSequence.Length; i++)
            {
                GameObject noteInstance = Instantiate(notePrefab, transform.position, Quaternion.identity);

                if (noteAudioSource != null && currentSequence[i] <= noteSounds.Length)
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

                yield return new WaitForSeconds(15);
            
        }
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
