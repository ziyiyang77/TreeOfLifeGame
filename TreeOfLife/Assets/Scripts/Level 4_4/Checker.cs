using UnityEngine;

public class Checker : MonoBehaviour
{
    // Adjacent nodes
    public Node upNode;
    public Node downNode;
    public Node leftNode;
    public Node rightNode;

    // Number of adjacent nodes that should be powered to satisfy the condition
    public int correctNumber;

    // Tracks the current number of powered adjacent nodes
    private int currentPoweredCount;

    // Boolean to track if the checker's condition is met
    public bool isConditionMet;

    public bool hasPower;

    void Start()
    {
        UpdatePowerStatus();
    }

    void Update()
    {
        // Continually check the power status of adjacent nodes
        UpdatePowerStatus();
    }

    void UpdatePowerStatus()
    {
        currentPoweredCount = 0;

        // Check each connected node and count how many are powered
        if (CheckIfPowered(upNode)) currentPoweredCount++;
        if (CheckIfPowered(downNode)) currentPoweredCount++;
        if (CheckIfPowered(leftNode)) currentPoweredCount++;
        if (CheckIfPowered(rightNode)) currentPoweredCount++;

        // Compare the count of powered nodes to the correct number
        isConditionMet = (currentPoweredCount == correctNumber);

        if(currentPoweredCount > 0)
            hasPower = true;

        // Update visual indicator here if needed
        UpdateVisuals();
    }

    bool CheckIfPowered(Node node)
    {
        // Return true if the node exists and is powered
        return node != null && node.hasPower;
    }

    void UpdateVisuals()
    {
        // Change the visual representation based on whether the condition is met
        if (isConditionMet)
        {
            // Logic to set the sprite color to green or an equivalent visual effect
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            // Logic to set the sprite color to red or an equivalent visual effect
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
