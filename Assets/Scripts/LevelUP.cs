using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUP : MonoBehaviour
{
    private GameObject controller;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
    }

    private void OnMouseUp()
    {
        if (controller.GetComponent<GlobalController>().money >= 25)
        {
            controller.GetComponent<GlobalController>().money -= 25;
            controller.GetComponent<GlobalController>().level++;
            foreach(GameObject obj in controller.GetComponent<GlobalController>().characters)
            {
                obj.GetComponent<PlayerController>().maxHealth += 5;
                obj.GetComponent<PlayerController>().health = obj.GetComponent<PlayerController>().maxHealth;
            }
        }
    }
}

