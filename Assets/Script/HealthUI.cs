using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image[] healthIcons;

    private int lastHealth = -1;

    private void Start()
    {
        RefreshHealthIcons();
    }

    private void Update()
    {
        // Khi Player bị phá hủy (playerHealth trở thành null)
        if (playerHealth == null)
        {
            // Nếu trước đó UI vẫn đang hiện máu (lastHealth > 0), ta sẽ tắt hết đi
            if (lastHealth > 0)
            {
                lastHealth = 0; // Đặt về 0 để không lặp lại việc tắt
                for (int i = 0; i < healthIcons.Length; i++)
                {
                    if (healthIcons[i] != null)
                    {
                        healthIcons[i].gameObject.SetActive(false);
                    }
                }
            }
            return; // Thoát khỏi Update, không chạy tiếp các dòng dưới nữa
        }

        if (lastHealth != playerHealth.currentHealth)
        {
            RefreshHealthIcons();
        }
    }

    private void RefreshHealthIcons()
    {
        Debug.Log(
            $"HealthUI Debug | Object: {gameObject.name} | Scene: {gameObject.scene.name} | " +
            $"playerHealth null: {playerHealth == null} | " +
            $"healthIcons null: {healthIcons == null} | " +
            $"icons length: {(healthIcons == null ? -1 : healthIcons.Length)}"
        );

        if (healthIcons != null)
        {
            for (int i = 0; i < healthIcons.Length; i++)
            {
                Debug.Log($"Health icon {i} null: {healthIcons[i] == null}");
            }
        }

        int currentHealth = Mathf.Clamp(playerHealth.currentHealth, 0, healthIcons.Length);
        lastHealth = currentHealth;

        for (int i = 0; i < healthIcons.Length; i++)
        {
            if (healthIcons[i] != null)
            {
                healthIcons[i].gameObject.SetActive(i < currentHealth);
            }
        }
    }
}