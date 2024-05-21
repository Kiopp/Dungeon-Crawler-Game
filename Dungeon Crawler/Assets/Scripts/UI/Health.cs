// Programmer: Joel Majava

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour {

    public GameObject player;

    // Decides the current amount of hearts.
    public int iHealth;

    // Decides how many hearts are potentially available for the player
    public int numberOfHearts;

    // Array of the objects which make up the health bar
    public Image[] hearts;

    public Sprite emptyHeart;
    public Sprite fullHeart;

    private int iCurrentHealth;

    void Update() {
      
        iCurrentHealth = player.GetComponent<Player>().currentHealth/10; // Gets the current health of the player 
      
        for(int i = 0; i < hearts.Length; i++) {

            // Failsafe which makes it impossible for health to go higher than the amount of available hearts.
            /*if (iCurrentHealth > numberOfHearts) {
                iCurrentHealth = numberOfHearts;
            }*/

            // Fills or removes health
            if(i < iCurrentHealth) {
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