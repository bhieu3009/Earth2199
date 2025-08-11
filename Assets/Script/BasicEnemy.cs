using UnityEngine;

public class BasicEnemy : Enemy
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Kiểm tra va chạm với Player
        {
            if (player != null)
            {
                player.TakeDamage(enterDamage); // Gây sát thương khi chạm lần đầu
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Kiểm tra Player còn trong vùng Trigger
        {
            if (player != null)
            {
                player.TakeDamage(stayDamage); // Gây sát thương liên tục khi đứng trong vùng Trigger
            }
        }
    }

}
