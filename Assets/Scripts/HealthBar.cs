using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image bar;
    public GameObject player;

    void Update()
    {
        bar.fillAmount = player.GetComponent<PlayerController>().health / player.GetComponent<PlayerController>().maxHealth;
    }
}
