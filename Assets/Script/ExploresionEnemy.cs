using UnityEngine;

public class ExploresionEnemy : Enemy
{
    [SerializeField] private GameObject explosionPrefabs;//sinh ra vụ nổ 
    private void CreateExplosion()
    {
        if (explosionPrefabs != null)
        {
            Instantiate(explosionPrefabs, transform.position, Quaternion.identity);
            // location the boss has explore
        }
    }
    protected override void Die()
    {
        CreateExplosion(); // Gây nổ khi chết
        base.Die();        // Gọi phương thức chết của lớp cha (`Enemy`)
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CreateExplosion();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakeDamage(stayDamage);
            }
        }
    }
}
