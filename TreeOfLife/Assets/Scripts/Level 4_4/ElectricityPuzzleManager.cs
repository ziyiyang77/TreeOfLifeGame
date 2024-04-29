using UnityEngine;

public class ElectricityPuzzleManager : MonoBehaviour
{
    public Node[] nodes; // Array of all nodes in the puzzle
    public int selectedTypeIndex = 0; // Index to track selected rotation type
    private Node.RotationType[] rotationTypes = { Node.RotationType.Arrow, Node.RotationType.Square, Node.RotationType.Triangle };
    private bool playerIsNearTrigger = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (true) // This should be your method to check if the player is near a trigger
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
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            selectedTypeIndex--;
            if (selectedTypeIndex < 0)
                selectedTypeIndex = 3; // Wrap around to Reset
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            selectedTypeIndex++;
            if (selectedTypeIndex > 3)
                selectedTypeIndex = 0; // Wrap around to Arrow
        }
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

    private void ResetAllNodes()
    {
        foreach (var node in nodes)
        {
            node.currentRotation = 0;
            node.UpdatePowerStatus();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNearTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNearTrigger = false;
        }
    }

    private bool PlayerIsNearTrigger()
    {
        return playerIsNearTrigger;
    }
}
