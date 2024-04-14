using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GemController : MonoBehaviour
{
    public GameObject gem; // The GameObject to manipulate
    public Vector3 positionOffset; // Offset from the player's position
    public float moveSpeed = 1f; // Speed of the movement
    public string nextSceneName; // The name of the next scene to load
    public Transform playerTransform; // Reference to the player's Transform

    void Start()
    {
        if (gem == null)
        {
            gem = gameObject; // Use this GameObject if none is specified
        }
    }

    // Method to start the sequence
    public void StartSequence()
    {
        StartCoroutine(Sequence());
    }

    private IEnumerator Sequence()
    {
        // Calculate new position based on the player's position plus the offset
        Vector3 newPosition = playerTransform.position + positionOffset;

        gem.SetActive(true); // Activate the GameObject

        // Move to the new position smoothly
        while (Vector3.Distance(gem.transform.position, newPosition) > 0.01f)
        {
            gem.transform.position = Vector3.MoveTowards(
                gem.transform.position,
                newPosition,
                moveSpeed * Time.deltaTime
            );
            yield return null;
        }

        yield return new WaitForSeconds(3); // Wait for 3 seconds

        gem.SetActive(false); // Deactivate the GameObject

        yield return new WaitForSeconds(1); // Wait for 1 second

        SceneTransitionManager.Instance.LoadScene(nextSceneName);  // Load the next scene
    }
}
