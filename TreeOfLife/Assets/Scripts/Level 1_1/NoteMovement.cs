using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float oscillationMagnitude;
    private Vector3 startPosition;

    void Start()
    {
        float randomYOffset = Random.Range(-2f, 2f);
        startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        transform.position = startPosition;

        oscillationMagnitude = Random.Range(0.5f, 2f);
        Destroy(gameObject, 5f); 
    }

    void Update()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        // Oscillate up and down
        float newY = Mathf.Sin(Time.time * moveSpeed) * oscillationMagnitude;
        transform.position = new Vector3(transform.position.x, startPosition.y, transform.position.z);
    }
}
