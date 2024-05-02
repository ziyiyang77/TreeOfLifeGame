using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Include this to work with UI elements

public class ElectricityPuzzleManager : MonoBehaviour
{
    public Node[] nodes; // Array of all nodes in the puzzle
    public int selectedTypeIndex = 0; // Index to track selected rotation type
    private Node.RotationType[] rotationTypes = { Node.RotationType.Arrow, Node.RotationType.Square, Node.RotationType.Triangle };
    private bool playerIsNearTrigger = false;
    public Line[] lines;
    public Checker[] checkers;
    public List<MonoBehaviour> dynamicObj;

    // UI and Camera management
    public GameObject[] selectionButtons;
    public Camera puzzleCamera; // Camera dedicated to the puzzle
    public PlayerController playerController; // Player controller script
    public GameObject puzzle;
    public AudioSource puzzleSolvedSound;

    // Colors for unselected and selected buttons
    public Color unselectedColor = Color.white;
    public Color selectedColor = Color.red;

    private bool allowUpdates = true;  // Control flag for updates
    private bool inputEnabled = true;


    private void Start()
    {
        puzzleCamera.gameObject.SetActive(false); // Start with the puzzle camera deactivated
        puzzle.SetActive(false); // Start with the puzzle itself deactivated
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerIsNearTrigger && (!puzzle.activeSelf))
        {
            TogglePuzzle();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && puzzle.activeSelf)
        {
            DeactivatePuzzle();
        }
        else if (puzzle.activeSelf && allowUpdates && inputEnabled)
        {
            HandlePuzzleInput();
        }
        if (puzzle.activeSelf && CheckAllConditionsMet())
        {
            StartCoroutine(SolvePuzzle());
        }
    }

    private void HandlePuzzleInput()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (selectedTypeIndex < 3) // Less than 3 to rotate Arrow, Square, or Triangle
            {
                RotateNodes(rotationTypes[selectedTypeIndex]);
            }
            else
            {
                ResetAllNodes();
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            selectedTypeIndex--;
            if (selectedTypeIndex < 0)
                selectedTypeIndex = 3; // Wrap around to Reset
            UpdateButtonColors();  // Update colors when selection changes
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            selectedTypeIndex++;
            if (selectedTypeIndex > 3)
                selectedTypeIndex = 0; // Wrap around to Arrow
            UpdateButtonColors();  // Update colors when selection changes
        }

        UpdateAll();
    }

    void UpdateAll()
    {
        if (!allowUpdates) return; // Skip update if not allowed

        foreach (var line in lines)
        {
            line.UpdatePowerStatus();
        }

        foreach (var node in nodes)
        {
            node.UpdatePowerStatus();
        }

        foreach (var checker in checkers)
        {
            checker.UpdatePowerStatus();
        }
    }

    private void ResetAllNodes()
    {
        allowUpdates = false; // Stop updates

        foreach (var node in nodes)
        {
            node.transform.rotation = Quaternion.Euler(0, 0, 0);
            node.currentRotation = 0;
            node.ClearPowerData();
        }

        foreach (var line in lines)
        {
            line.ClearPowerData();
        }

        foreach (var checker in checkers)
        {
            checker.ClearPowerData();
        }

        allowUpdates = true; // Resume updates
        UpdateAll();
    }

    private bool CheckAllConditionsMet()
    {
        foreach (var checker in checkers)
        {
            if (!checker.isConditionMet) return false;
        }
        return true;
    }

    IEnumerator SolvePuzzle()
    {
        inputEnabled = false; // Disable input to prevent changes during the solve sequence
        yield return new WaitForSeconds(2); // Wait for 2 seconds before proceeding

        //puzzleSolvedSound.Play(); // Play the sound effect for puzzle solved

        // Future actions such as opening a door or updating game state
        // OpenDoor(); // Placeholder for future method calls
        // UpdateGameState(); // Placeholder for other game state updates

        //yield return new WaitForSeconds(puzzleSolvedSound.clip.length); // Wait for the sound to finish playing

        DeactivatePuzzle();
        inputEnabled = true; // Re-enable input after deactivating the puzzle
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNearTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNearTrigger = false;
        }
    }

    private void UpdateButtonColors()
    {
        for (int i = 0; i < selectionButtons.Length; i++)
        {
            if (selectionButtons[i].GetComponent<SpriteRenderer>())
            {
                selectionButtons[i].GetComponent<SpriteRenderer>().color = i == selectedTypeIndex ? selectedColor : unselectedColor;
            }
        }
    }

    private void TogglePuzzle()
    {
        if (!puzzle.activeSelf) // If puzzle is not active, activate it
        {
            puzzleCamera.gameObject.SetActive(true);
            puzzle.SetActive(true);

            playerController.StopMovementAndAnimation();
            playerController.enabled = false;

            UpdateButtonColors(); // Initial update to button colors
            UpdateAll();
        }
        else
        {
            DeactivatePuzzle();
        }
    }

    private void DeactivatePuzzle()
    {
        puzzleCamera.gameObject.SetActive(false);
        puzzle.SetActive(false);

        playerController.enabled = true;
    }

    private void RotateNodes(Node.RotationType type)
    {
        foreach (var node in nodes)
        {
            if (node.HasRotationType(type))
            {
                node.RotateNode();
            }
        }
    }

}
