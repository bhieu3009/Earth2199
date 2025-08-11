using UnityEngine;

public class BossEnemy : Enemy
{
    [SerializeField] private GameObject bulletPrefabs; //Viên đạn bắn ra
    [SerializeField] private Transform firePoint; //viên đạn bay ra 
    [SerializeField] private float speedBossBullet = 20f;
    [SerializeField] private float speedBossCircleBullet = 10f;
    [SerializeField] private float hpValue = 100f;
    [SerializeField] private GameObject miniEnemy;
    [SerializeField] private float skillCooldown = 3f;
    private float nextSkillTime = 0f;
    [SerializeField] private GameObject usbPrefabs;//Sử dụng khi mà thắng rơi usb xuống 
    protected override void Update()
    {
        base.Update();
        if (Time.time > nextSkillTime)
        {
            BossUseSkill();
        }
    }
    protected override void Die()
    {
        Instantiate(usbPrefabs,transform.position, Quaternion.identity);    //rơi usb ở vị trí bosss 
        base.Die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.TakeDamage(enterDamage);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.TakeDamage(stayDamage);
        }
    }
    private void BanDanThuong()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = player.transform.position - firePoint.position;
            directionToPlayer.Normalize();

            GameObject bullet = Instantiate(bulletPrefabs, firePoint.position, Quaternion.identity);

            EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();


            enemyBullet.SetMovementDirection(directionToPlayer * speedBossBullet);
        }
    }
    private void BanDanVongTron()
    {
        const int bulletCount = 12;
        float angleStep = 360f / bulletCount;// Góc giữa hai viên đạn liên tiếp.
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * angleStep;
            Vector3 bulletDirection = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle), 0);
            GameObject bullet = Instantiate(bulletPrefabs, transform.position, Quaternion.identity);
            EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
            enemyBullet.SetMovementDirection(bulletDirection * speedBossCircleBullet);
        }
    }
    private void HoiMau(float hpAmount)
    {
        currentHp = Mathf.Min(currentHp + hpAmount, maxHp);
        UpdateHpBar();
    }
    private void SinhMiniEnemy()
    {
        Instantiate(miniEnemy, transform.position, Quaternion.identity);//sinh vị trí ở boss 
    }
    private void DichChuyen()
    {
        if (player != null)
        {
            transform.position = player.transform.position;
        }
    }

    private void BossSkillAutoRandom()
    {
        int randomSkill = Random.Range(0, 5);
        switch (randomSkill)
        {
            case 0:
                BanDanThuong();
                break;
            case 1:
                BanDanVongTron();
                break;
            case 2:
                HoiMau(hpValue);
                break;
            case 3:
                SinhMiniEnemy();
                break;
            case 4:
                DichChuyen();
                break;
        }
    }
    private void BossUseSkill()
    {
        nextSkillTime = Time.time + skillCooldown;
        BossSkillAutoRandom();
    }
}
