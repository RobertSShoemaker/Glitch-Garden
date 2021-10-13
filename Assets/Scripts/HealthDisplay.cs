using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] float baseHealth = 3;
    [SerializeField] int damage = 1;
    float health;
    Text healthText;

    void Start()
    {
        health = baseHealth - PlayerPrefsController.GetDifficulty();
        healthText = GetComponent<Text>();
        UpdateDisplay();
        Debug.Log("difficulty setting currently is " + PlayerPrefsController.GetDifficulty());
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
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
