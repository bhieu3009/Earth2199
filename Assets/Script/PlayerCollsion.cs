using UnityEngine;

public class PlayerCollsion : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioManager audioManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            Player player = GetComponent<Player>();
            player.TakeDamage(10f);
        }//9
        else if (collision.CompareTag("Usb"))
        {
            gameManager.WinGame();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Energy"))
        {
            gameManager.AddEnergy();
            Destroy(collision.gameObject);
            audioManager.PlayEnergySound();
        }
    }
}
