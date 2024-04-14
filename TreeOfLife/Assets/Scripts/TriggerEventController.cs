using System.Collections;
using UnityEngine;

public class TriggerEventController : MonoBehaviour
{
    public PlayerController playerController;  // Assign player's movement script in the inspector
    public RectTransform topBlackSprite;     // Assign the RectTransform of the top black sprite
    public RectTransform bottomBlackSprite;  // Assign the RectTransform of the bottom black sprite
    public CrawSinger crawSingerScript;      // The special script to activate

    public float moveDistance = 100f;        // Distance the sprites will move (adjust based on your UI layout)
    public float moveDuration = 1.0f;        // Duration of the move in seconds

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && this.enabled)  // Check if it's the player and the script is enabled
        {
            StartCoroutine(EventSequence());
        }
    }


    private IEnumerator EventSequence()
    {
        // Disable player movement
        playerController.StopMovementAndAnimation();
        playerController.enabled = false;
        
        // Move black sprites into view
        StartCoroutine(MoveSprite(topBlackSprite, topBlackSprite.anchoredPosition + new Vector2(0, -moveDistance), moveDuration));
        StartCoroutine(MoveSprite(bottomBlackSprite, bottomBlackSprite.anchoredPosition + new Vector2(0, moveDistance), moveDuration));

        crawSingerScript.enabled = true;

        yield return new WaitForSeconds(6);

        // Move black sprites out of view
        StartCoroutine(MoveSprite(topBlackSprite, topBlackSprite.anchoredPosition + new Vector2(0, moveDistance), moveDuration));
        StartCoroutine(MoveSprite(bottomBlackSprite, bottomBlackSprite.anchoredPosition + new Vector2(0, -moveDistance), moveDuration));

        // Ensure the sprites have moved out before re-enabling player movement
        yield return new WaitForSeconds(moveDuration);
        playerController.enabled = true;

        this.enabled = false;
    }

    private IEnumerator MoveSprite(RectTransform sprite, Vector2 targetPosition, float duration)
    {
        float time = 0;
        Vector2 startPosition = sprite.anchoredPosition;

        while (time < duration)
        {
            sprite.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        sprite.anchoredPosition = targetPosition; // Ensure the sprite reaches the target position
    }
}
