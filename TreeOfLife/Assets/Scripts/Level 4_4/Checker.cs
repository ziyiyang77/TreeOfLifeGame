using UnityEngine;

public class Checker : MonoBehaviour
{
    // Adjacent lines
    public Line upLine;
    public Line downLine;
    public Line leftLine;
    public Line rightLine;

    // Number of adjacent lines that should be powered to satisfy the condition
    public int correctNumber;

    // Tracks the current number of powered adjacent lines
    public int currentPoweredCount;

    // Boolean to track if the checker's condition is met
    public bool isConditionMet;

    public bool hasPower;

    // Array of sprites to represent different power states
    public Sprite[] powerSprites;

    void Start()
    {
        UpdatePowerStatus();
    }

    void Update()
    {
        UpdatePowerStatus();
    }

    public void ClearPowerData()
    {
        hasPower = false;
    }

    public void UpdatePowerStatus()
    {
        currentPoweredCount = 0;

        if (CheckIfPowered(upLine)) currentPoweredCount++;
        if (CheckIfPowered(downLine)) currentPoweredCount++;
        if (CheckIfPowered(leftLine)) currentPoweredCount++;
        if (CheckIfPowered(rightLine)) currentPoweredCount++;

        isConditionMet = (currentPoweredCount == correctNumber);
        hasPower = (currentPoweredCount > 0);

        UpdateVisuals();
    }

    bool CheckIfPowered(Line line)
    {
        return line != null && line.hasPower;
    }

    void UpdateVisuals()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (powerSprites != null && powerSprites.Length == 4)
        {
            int spriteIndex = currentPoweredCount;
            if (spriteIndex > 3)
                spriteIndex = 3;
            // Change the sprite based on the number of powered lines
            spriteRenderer.sprite = powerSprites[spriteIndex];
        }

    }
}
