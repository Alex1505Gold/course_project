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
            player.GetComponent<PlayerController>().health =
                player.GetComponent<PlayerController>().maxHealth * controller.GetComponent<GlobalController>().level;
            controller.GetComponent<GlobalController>().charsOnScreen++;
            controller.gameObject.GetComponent<GlobalController>().money -= price;
            text.SetActive(false);
            coin.SetActive(false);
            bg.GetComponent<Collider2D>().enabled = false;
            bg.GetComponent<UnityEngine.UI.Image>().enabled = false;
        }
    }

    private void Update()
    {
        if (player.GetComponent<PlayerController>().health <= 0f) ResetHire();
    }

    public void ResetHire()
    {
        text.SetActive(true);
        coin.SetActive(true);
        bg.GetComponent<Collider2D>().enabled = true;
        bg.GetComponent<UnityEngine.UI.Image>().enabled = true;
    }
}
