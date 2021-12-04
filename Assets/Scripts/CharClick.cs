using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharClick : MonoBehaviour
{
    public Text attack;
    public Text heal;
    public Image bg1;
    public Image bg2;
    private bool clicked;
    private GameObject controller;

    void setButtons(bool flag)
    {
        attack.gameObject.SetActive(flag);
        heal.gameObject.SetActive(flag);
        bg1.gameObject.SetActive(flag);
        bg2.gameObject.SetActive(flag);
        attack.gameObject.GetComponent<Collider2D>().enabled = flag;
        heal.gameObject.GetComponent<Collider2D>().enabled = flag;
    }

    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        setButtons(false);
        clicked = false;
    }

    private void OnMouseUp()
    {
        if (controller.GetComponent<GlobalController>().stage == "planning")
        {
            if (!clicked)
            {
                setButtons(true);
                clicked = true;
            }
            else
            {
                setButtons(false);
                clicked = false;
            }
        }
    }
}
