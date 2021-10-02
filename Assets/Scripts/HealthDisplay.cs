using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] int health = 5;
    [SerializeField] int damage = 1;
    Text healthText;

    void Start()
    {
        healthText = GetComponent<Text>();
        UpdateDisplay();
    }

    //update the display with the current health
    private void UpdateDisplay()
    {
        healthText.text = health.ToString();
    }

    //subtract health from the current amount displayed
    //if the player's health reaches 0 then load the game over scene
    public void SubtractHealth()
    {
        health -= damage;
        UpdateDisplay();
        if (health <= 0)
        {
            FindObjectOfType<LevelLoader>().LoadGameOver();
        }
    }
}
