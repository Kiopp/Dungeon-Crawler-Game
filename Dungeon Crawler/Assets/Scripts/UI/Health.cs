// Programmer: Joel Majava

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Decides the current amount of hearts.
    public int iHealth;

    // Decides how many hearts are potentially available for the player
    public int numberOfHearts;

    // Array of the objects which make up the health bar
    public Image[] hearts;

    public Sprite emptyHeart;
    public Sprite fullHeart;

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // Failsafe which makes it impossible for health to go higher than the amount of available hearts.
            if (iHealth > numberOfHearts)
            {
                iHealth = numberOfHearts;
            }

            // Fills or removes health
            if (i < iHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            // Sets the amount of available hearts to the decided value numberOfHearts
            if (i < numberOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}