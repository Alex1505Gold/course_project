using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Heal : MonoBehaviour
{
    public Image bar;
    public float fill;
    public GameObject player;
    private GameObject controller;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
    }

    private void OnMouseUp()
    {
        controller.gameObject.GetComponent<GlobalController>().stage = "healing";
        float maxHealth = player.GetComponent<PlayerController>().maxHealth;
        int level = player.GetComponent<PlayerController>().level;
        if (controller.gameObject.GetComponent<GlobalController>().potions > 0
            && player.GetComponent<PlayerController>().health < maxHealth)
        {
            if (player.GetComponent<PlayerController>().health + 10f * level <= maxHealth)
                player.GetComponent<PlayerController>().health += 10f * level;
            else player.GetComponent<PlayerController>().health = maxHealth;
            controller.gameObject.GetComponent<GlobalController>().potions--;
        }
    }
}
