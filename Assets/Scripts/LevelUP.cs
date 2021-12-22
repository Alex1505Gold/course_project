using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUP : MonoBehaviour
{
    [SerializeField] private Text levelInfo;
    private GameObject controller;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
    }

    private void OnMouseUp()
    {
        if (controller.GetComponent<GlobalController>().money >= 25 * controller.GetComponent<GlobalController>().level)
        {
            controller.GetComponent<GlobalController>().money -= 25 * controller.GetComponent<GlobalController>().level;
            controller.GetComponent<GlobalController>().level++;
            foreach(GameObject obj in controller.GetComponent<GlobalController>().characters)
            {
                obj.GetComponent<PlayerController>().maxHealth += 5;
                obj.GetComponent<PlayerController>().health = obj.GetComponent<PlayerController>().maxHealth;
                obj.GetComponent<PlayerController>().damage += 5;
                obj.GetComponent<PlayerController>().healPower += 5;
            }
            levelInfo.GetComponent<Text>().text = controller.GetComponent<GlobalController>().level.ToString();
        }
    }
}

