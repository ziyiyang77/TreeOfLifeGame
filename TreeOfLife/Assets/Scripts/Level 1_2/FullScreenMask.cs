using UnityEngine;

public class FullScreenMask : MonoBehaviour
{
    // 引用屏幕遮罩Sprite
    public SpriteRenderer screenMask;

    void Update()
    {
        // 检测鼠标点击事件
        if (Input.GetMouseButtonDown(0))
        {
            // 获取鼠标点击位置
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0; // 保持z轴位置不变

            // 检测点击是否在画墙上（这里可以根据你的需求修改判断条件）
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Painting"))
            {
                // 将屏幕遮罩放大到整个屏幕大小
                screenMask.transform.localScale = new Vector3(1, 1, 1);

                // 将屏幕遮罩的alpha值设置为1，使其变得可见
                Color maskColor = screenMask.color;
                maskColor.a = 1;
                screenMask.color = maskColor;
            }
        }
    }
}
