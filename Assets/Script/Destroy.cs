using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra xem object mà đạn vừa chạm vào có tag là "Enemy" hay không
        if (collision.CompareTag("Enemy"))
        {
            // (Tùy chọn) Tại đây bạn có thể gọi hàm trừ máu của Enemy
            // Ví dụ: collision.GetComponent<Health>().TakeDamage(1);

            // Hủy (biến mất) object viên đạn ngay lập tức
            Destroy(gameObject);
        }
    }
}