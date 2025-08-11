using UnityEngine;
using UnityEngine.UIElements; // Không cần thiết, có thể xóa nếu không dùng UIElements.

public class EnemyBullet : MonoBehaviour
{
    private Vector3 movementDirection; // Hướng di chuyển của viên đạn.

    // Start() được gọi một lần ngay khi đối tượng được tạo ra.
    void Start()
    {
        Destroy(gameObject, 5f); // Hủy viên đạn sau 5 giây để tránh rác bộ nhớ.
    }

    // Update() chạy mỗi frame để xử lý chuyển động của viên đạn.
    void Update()
    {
        if (movementDirection == Vector3.zero) // Nếu hướng di chuyển là (0,0,0), không làm gì.
            return; // Thoát khỏi hàm Update.

        transform.position += movementDirection * Time.deltaTime;
        // Di chuyển viên đạn theo hướng đã đặt, nhân với Time.deltaTime để đảm bảo tốc độ mượt mà.
    }

    // Hàm này được gọi từ bên ngoài để đặt hướng di chuyển của viên đạn.
    public void SetMovementDirection(Vector3 direction)
    {
        movementDirection = direction; // Gán hướng di chuyển cho viên đạn.
    }
}
