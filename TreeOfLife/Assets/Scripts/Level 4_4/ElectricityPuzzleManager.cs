using System.Collections.Generic;
using UnityEngine;

public class ElectricityPuzzleManager : MonoBehaviour
{
    public Node[] nodes; // Array of all nodes in the puzzle
    public int selectedTypeIndex = 0; // Index to track selected rotation type
    private Node.RotationType[] rotationTypes = { Node.RotationType.Arrow, Node.RotationType.Square, Node.RotationType.Triangle };
    private bool playerIsNearTrigger = false;
    public Line[] lines;
    public Checker[] checkers;

    public List<MonoBehaviour> dynamicObj;

    private void Start()
    {
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
                    //ResetAllNodes();
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

        UpdateAll();
    }

    private void RotateNodes(Node.RotationType type)
    {
/*        foreach (var node in nodes)
        {
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
*/
        foreach (var node in nodes)
        {
            if (node.HasRotationType(type))
            {
                node.RotateNode();
            }
        }
    }
    
    void UpdateAll()
    {
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
