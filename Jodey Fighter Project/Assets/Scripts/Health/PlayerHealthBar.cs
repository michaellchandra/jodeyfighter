using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHealthBar : MonoBehaviour
{

    public PlayerHealthBar playerHealth;
    public Image fillImage;
    private Slider slider;


    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        
    }
}
