using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthBar playerHealthBar;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    private void Start()
    {
        totalHealthBar.fillAmount = playerHealthBar.currentHealthBar / 10;
    }
    
    private void Update()
    {
        currentHealthBar.fillAmount = playerHealthBar.currentHealthBar / 10;
    }
}
