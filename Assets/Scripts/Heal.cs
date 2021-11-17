using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Heal : MonoBehaviour
{
    public Image bar;
    public float fill;
    public Text potionAmount;
    private int potions;
    public GameObject player;

    private void OnMouseUp()
    {
        potions = Int32.Parse(potionAmount.gameObject.GetComponent<Text>().text);
        print(potions);
        float maxHealth = player.GetComponent<PlayerController>().maxHealth;
        int level = player.GetComponent<PlayerController>().level;
        if (potions > 0)
        {
            if (player.GetComponent<PlayerController>().health + 10f * level <= maxHealth)
                player.GetComponent<PlayerController>().health += 10f * level;
            else player.GetComponent<PlayerController>().health = maxHealth;
            potions--;
            potionAmount.gameObject.GetComponent<Text>().text = potions.ToString();
            print("heal");
        }
    }
}
