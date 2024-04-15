using UnityEngine;

public class Merrybell : MonoBehaviour
{
    public AudioSource soundSource;
    public int merrybellId;
    private bool isPlayerInRange = false;
    public MusicPuzzleController puzzleController;

    void Awake()
    {
        puzzleController = FindObjectOfType<MusicPuzzleController>();
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            soundSource.Play();
            puzzleController.HandleMerrybellActivated(merrybellId);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
