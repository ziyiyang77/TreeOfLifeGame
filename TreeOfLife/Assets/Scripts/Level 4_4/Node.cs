using System.Collections;
using UnityEngine;

public class Node : MonoBehaviour
{
    // Enum to represent wiring types inside the node
    public enum WiringType { L, T, I}
    // Enum for different rotation types a node can have
    public enum RotationType { Arrow, Square, Triangle }

    // Wiring configuration of the node
    public WiringType wiringType;

    // Array of rotation types this node can respond to
    public RotationType[] rotationTypes;

    // Current rotation of the node in degrees
    public int currentRotation;

    // Whether this node is currently powered
    public bool hasPower;

    // Adjacent nodes
    public MonoBehaviour upObject; // Change the type to MonoBehaviour
    public MonoBehaviour downObject; // Change the type to MonoBehaviour
    public MonoBehaviour leftObject; // Change the type to MonoBehaviour
    public MonoBehaviour rightObject; // Change the type to MonoBehaviour

    public float rotationSpeed = 100f; // Speed of rotation animation
    private bool isRotating = false; // Flag to prevent multiple rotations at once

    private ElectricityPuzzleManager puzzleManager;

    public int defaltRotation;

    private void Awake()
    {
        puzzleManager = FindObjectOfType<ElectricityPuzzleManager>();
    }

    void Start()
    {
        // Initialize the node
        hasPower = false;
        //currentRotation = 0; // Initial rotation
    }
    public void AddNodeToPuzzle(Node node)
    {
        if (!puzzleManager.dynamicObj.Contains(node))
        {
            puzzleManager.dynamicObj.Add(node);
        }
    }

    public void RotateNode()
    {

        if (!isRotating)
        {
            StartCoroutine(RotateNodeOverTime(90));
        }

        // Update the node's power status based on new orientation
        UpdatePowerStatus();
    }

    public void ClearPowerData()
    {
        hasPower = false;
    }

    public bool HasRotationType(RotationType type)
    {
        // Check if the node can rotate based on the provided type
        foreach (var rotationType in rotationTypes)
        {
            if (rotationType == type)
                return true;
        }
        return false;
    }

    public void UpdatePowerStatus()
    {
        // Reset power status
        hasPower = false;

        // Determine the active edges based on the current rotation and wiring type
        switch (wiringType)
        {
            case WiringType.L:
                CheckLPower();
                break;
            case WiringType.T:
                CheckTPower();
                break;
            case WiringType.I:
                CheckIPower();
                break;
        }

        if (hasPower) { AddNodeToPuzzle(this); }

        UpdateVisuals();
    }

    void CheckLPower()
    {
        // Check connections based on L-shape and current rotation
        if (currentRotation == 0 && (CheckPower(upObject) || CheckPower(leftObject)))
            hasPower = true;
        else if (currentRotation == 90 && (CheckPower(leftObject) || CheckPower(downObject)))
            hasPower = true;
        else if (currentRotation == 180 && (CheckPower(downObject) || CheckPower(rightObject)))
            hasPower = true;
        else if (currentRotation == 270 && (CheckPower(rightObject) || CheckPower(upObject)))
            hasPower = true;
    }

    void CheckTPower()
    {
        // Check connections based on T-shape and current rotation
        if (currentRotation == 0 && (CheckPower(upObject) || CheckPower(leftObject) || CheckPower(rightObject)))
            hasPower = true;
        else if (currentRotation == 90 && (CheckPower(upObject) || CheckPower(leftObject) || CheckPower(downObject)))
            hasPower = true;
        else if (currentRotation == 180 && (CheckPower(downObject) || CheckPower(leftObject) || CheckPower(rightObject)))
            hasPower = true;
        else if (currentRotation == 270 && (CheckPower(upObject) || CheckPower(rightObject) || CheckPower(downObject)))
            hasPower = true;
    }

    void CheckIPower()
    {
        // Check connections based on I-shape and current rotation
        if (currentRotation == 0 && (CheckPower(rightObject) || CheckPower(leftObject)))
            hasPower = true;
        else if (currentRotation == 90 && (CheckPower(upObject) || CheckPower(downObject)))
            hasPower = true;
        else if (currentRotation == 180 && (CheckPower(leftObject) || CheckPower(rightObject)))
            hasPower = true;
        else if (currentRotation == 270 && (CheckPower(downObject) || CheckPower(upObject)))
            hasPower = true;
    }

    bool CheckPower(MonoBehaviour obj)
    {
        // Check if the connected object has power
        if (obj == null) return false; // If the object is null, return false
        // If the object is a Node, check its hasPower property
        if (obj is Node)
        {
            return (obj as Node).hasPower;
        }
        // If the object is a Checker, check its power property
        else if (obj is Checker)
        {
            return (obj as Checker).hasPower;
        }
        else if (obj is Line)
        {
            return (obj as Line).hasPower;
        }
        // If the object is a PowerSource, assume it always has power
        else if (obj is PowerSource)
        {
            return true;
        }
        // Default case, return false
        return false;
    }

    IEnumerator RotateNodeOverTime(float angle)
    {
        isRotating = true;
        Quaternion initialRotation = transform.rotation;
        Quaternion targetRotation = initialRotation * Quaternion.Euler(0, 0, angle);
        float step = 0.0f;

        while (step < 1.0f)
        {
            step += Time.deltaTime * rotationSpeed / angle;
            transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, step);
            yield return null;
        }

        transform.rotation = targetRotation;
        currentRotation = (currentRotation + 90) % 360;
        UpdatePowerStatus();
        isRotating = false;
    }

    void UpdateVisuals()
    {
        // Change the visual representation based on whether the condition is met
        if (hasPower)
        {
            // Logic to set the sprite color to green or an equivalent visual effect
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else
        {
            // Logic to set the sprite color to red or an equivalent visual effect
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
