using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Image[] healthPointsImage;

    private void Update()
    {
        for (int i = 0; i < healthPointsImage.Length; i++)
            healthPointsImage[i].enabled = DisplayHealthPoints(playerHealth.CurrentHealth, i);
    }

    private bool DisplayHealthPoints(float currentHealth, int imageNum)
    {
        return (imageNum <= currentHealth -1);
    }


}
