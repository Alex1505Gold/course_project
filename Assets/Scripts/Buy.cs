using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy : MonoBehaviour
{
    private GameObject controller;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
    }

    private void OnMouseUp()
    {
        if (controller.GetComponent<GlobalController>().money >= 5)
        {
            controller.GetComponent<GlobalController>().money -= 5;
            controller.GetComponent<GlobalController>().potions++;
        }
    }
}
