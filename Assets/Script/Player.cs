using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; //Khởi tạo tốc độ chạy cho game 
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;//Lật nhân vật 
    private Animator animator;
    [SerializeField] private float maxHp = 100f;
    private float currentHp;
    [SerializeField] private Image hpBar;
    [SerializeField] private GameManager gameManager;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        currentHp = maxHp;
        UpdateHpbar();
    }


    void Update()
    {
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.PauseGameMenu();
        }
    }
    void MovePlayer()
    {
        Vector2 playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));// Tạo di chuyển theo trục ngang với dọc 
        rb.linearVelocity = playerInput.normalized * moveSpeed;

        if (playerInput.x < 0) //Nếu qua trái thì lật nhân vật hướng bên trái
        {
            spriteRenderer.flipX = true;
        }
        else if (playerInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        // So sánh player và tự động đổi trạng thái
        if (playerInput != Vector2.zero)
        {
            animator.SetBool("IsRun", true);
        }
        else
        {
            animator.SetBool("IsRun", false);
        }
    }
    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        currentHp = Mathf.Max(currentHp, 0);
        UpdateHpbar();
        if (currentHp <= 0)
        {
            Die();
        }
    }
    public void Heal(float healValue)
    {
        if (currentHp < maxHp)
        {
            currentHp += healValue;
            currentHp = Mathf.Min(currentHp, maxHp);
            UpdateHpbar();
        }
    }

    private void Die()
    {
        gameManager.GameOverMenu();
    }
    private void UpdateHpbar()
    {
        if (hpBar != null)
        {
            hpBar.fillAmount = currentHp / maxHp;
        }
    }
}
