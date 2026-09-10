using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Tooltip("Tốc độ cuộn của nền")]
    [SerializeField] private float scrollSpeed = 2f;
    
    [Tooltip("Tổng chiều cao của toàn bộ khối nền (nhập thủ công)")]
    [SerializeField] private float backgroundHeight = 20f; 

    private Vector3 startPosition;

    void Start()
    {
        // Lưu lại vị trí ban đầu của nguyên khối nền
        startPosition = transform.position;
    }

    void Update()
    {
        // Kéo cả khối nền đi xuống
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);

        // Nếu khối nền trôi qua khỏi chiều cao đã thiết lập, vòng nó trở lại
        if (transform.position.y < startPosition.y - backgroundHeight)
        {
            transform.position = startPosition;
        }
    }
}