using UnityEngine;

public class Line : MonoBehaviour
{
    public bool hasPower;

    public MonoBehaviour upObject;
    public MonoBehaviour downObject;
    public MonoBehaviour leftObject;
    public MonoBehaviour rightObject;  // Added a fourth object

    private ElectricityPuzzleManager puzzleManager;

    private void Awake()
    {
        puzzleManager = FindObjectOfType<ElectricityPuzzleManager>();
    }

    void Start()
    {
        hasPower = false;  // Initially, the line does not have power
    }

    public void AddNodeToPuzzle(Line line)
    {
        if (!puzzleManager.dynamicObj.Contains(line))
        {
            puzzleManager.dynamicObj.Add(line);
        }
    }

    // This method will be called to update the power status based on adjacent objects
    public void UpdatePowerStatus()
    {
        hasPower = false;
        if (CheckPower(upObject, "up") || CheckPower(downObject, "down") ||
            CheckPower(leftObject, "left") || CheckPower(rightObject, "right"))
        {
            hasPower = true;
        }
        else
        {
            hasPower = false;
        }
        UpdateVisuals();  // Update visuals based on power status
        if (hasPower) { AddNodeToPuzzle(this); }
    }

    public void ClearPowerData()
    {
        hasPower = false;
    }

    // Helper method to check if an adjacent object has power
    private bool CheckPower(MonoBehaviour obj, string direction)
    {
        Node node = obj as Node;
        if (node != null && node.hasPower)
        {
            return CheckNodePower(node, direction);
        }

        Checker checker = obj as Checker;
        if (checker != null)
        {
            return false;
        }

        PowerSource power = obj as PowerSource;
        if (power != null)
        {
            return true;
        }

        Line line = obj as Line;
        if (line != null)
        {
            return line.hasPower;
        }

        // Return false if no conditions are met
        return false;
    }

    private bool CheckNodePower(Node node, string direction)
    {
        if (node.wiringType == Node.WiringType.L)
        {
            switch (direction)
            {
                case "up": return node.currentRotation == 90 || node.currentRotation == 180;
                case "down": return node.currentRotation == 0 || node.currentRotation == 270;
                case "left": return node.currentRotation == 180 || node.currentRotation == 270;
                case "right": return node.currentRotation == 0 || node.currentRotation == 90;
                default: return false;
            }
        }
        else if (node.wiringType == Node.WiringType.T)
        {
            switch (direction)
            {
                case "up": return node.currentRotation == 90 || node.currentRotation == 180 || node.currentRotation == 270;
                case "down": return node.currentRotation == 0 || node.currentRotation == 90 || node.currentRotation == 270;
                case "left": return node.currentRotation == 0 || node.currentRotation == 270 || node.currentRotation == 180;
                case "right": return node.currentRotation == 0 || node.currentRotation == 180 || node.currentRotation == 90;
                default: return false;
            }
        }

        return false;
    }

    // Update visual elements based on power status
    private void UpdateVisuals()
    {
        // Example: Change color based on power state
        GetComponent<SpriteRenderer>().color = hasPower ? Color.yellow : Color.grey;
    }
}
