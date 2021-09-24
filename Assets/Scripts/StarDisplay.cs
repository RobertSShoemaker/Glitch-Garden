using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text starText;

    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    //update the display with the current number of stars
    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }

    //determine if the player has enough star currency to place a defender
    public bool HaveEnoughStars(int amount)
    {
        if (stars >= amount)
        {
            return true;
        }
        else
        {
            return false;
        }

        //could also be written as 
        //return stars >= amount;

    }


    //add an amount of stars to the display
    //currently the only way to gain stars is through the trophy, set the amount in the trophy's animation event
    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    //subtract stars spent from the current amount displayed
    public void SpendStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
        }
    }

}
