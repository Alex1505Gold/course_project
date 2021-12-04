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
        if (controller.gameObject.GetComponent<GlobalController>().potions > 0 &&
            controller.gameObject.GetComponent<GlobalController>().stage == "planning")
        {
            controller.gameObject.GetComponent<GlobalController>().stage = "healing";
            controller.gameObject.GetComponent<GlobalController>().curHeal =
                player.GetComponent<PlayerController>().healPower + 5 * (controller.GetComponent<GlobalController>().level - 1);
            //controller.gameObject.GetComponent<GlobalController>().potions--;
        }
        else if (controller.gameObject.GetComponent<GlobalController>().stage == "healing")
            controller.gameObject.GetComponent<GlobalController>().stage = "planning";
    }
}

/*
    private void OnMouseUp()
    {
        controller.gameObject.GetComponent<GlobalController>().stage = "healing";
        float maxHealth = player.GetComponent<PlayerController>().maxHealth;
        int level = controller.GetComponent<GlobalController>().level;
        if (controller.gameObject.GetComponent<GlobalController>().potions > 0
            && player.GetComponent<PlayerController>().health < maxHealth)
        {
            if (player.GetComponent<PlayerController>().health + 10f * level <= maxHealth)
                player.GetComponent<PlayerController>().health += 10f * level;
            else player.GetComponent<PlayerController>().health = maxHealth;
            controller.gameObject.GetComponent<GlobalController>().potions--;
        }
    }
*/
