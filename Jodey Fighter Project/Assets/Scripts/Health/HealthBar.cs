using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealthBar;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;
    



    private void Start()
    {
        totalHealthBar.fillAmount = playerHealthBar.currentHealth / 10;
    }

    private void Update()
    {
        currentHealthBar.fillAmount = playerHealthBar.currentHealth/ 10;
    }
}
