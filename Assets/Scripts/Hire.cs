using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hire : MonoBehaviour
{
    private GameObject controller;
    private int price;
    public GameObject player, text, bg, coin;

    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        price = player.GetComponent<PlayerController>().value;
    }

    private void OnMouseUp()
    {
        if(controller.gameObject.GetComponent<GlobalController>().money >= price)
        {
            player.GetComponent<PlayerController>().hired = true;
            controller.gameObject.GetComponent<GlobalController>().money -= price;
            text.SetActive(false);
            bg.SetActive(false);
            coin.SetActive(false);
        }
    }

    public void ResetHire()
    {
        text.SetActive(true);
        bg.SetActive(true);
        coin.SetActive(true);
    }
}
