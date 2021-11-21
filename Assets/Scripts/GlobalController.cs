using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalController : MonoBehaviour
{
    public Text coins, potionAmount;
    [HideInInspector] public int enemiesKilled = 0;
    [HideInInspector] public int charsOnScreen = 1;
    [HideInInspector] public int cenemiesOnScreen = 1;
    [HideInInspector] public int score = 0, money = 100, potions = 1;
    [HideInInspector] public int difficulty = 1;
    [HideInInspector] public int level = 1;
    [HideInInspector] public int turn = 0;
    [HideInInspector] public string stage;
    [HideInInspector] public float curDamage;
    //stages:
    //planning - выбор персонажа, покупка улучшений
    //attacking - выбор врага для атаки
    //healing - выбор союзника для лечения
    //enemyTurn - ход врага, игрок ничего не делает

    private void Start()
    {
        stage = "planning";
        curDamage = 0f;
        money = 100;
    }

    private void Update()
    {
        potionAmount.gameObject.GetComponent<Text>().text = potions.ToString();
        coins.gameObject.GetComponent<Text>().text = money.ToString();
    }
}
