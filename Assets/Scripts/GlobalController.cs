using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GlobalController : MonoBehaviour
{
    public Text coins, potionAmount, levelText, diffText;
    [HideInInspector] public int enemiesKilled = 0;
    [HideInInspector] public int charsOnScreen = 1;
    [HideInInspector] public int enemiesOnScreen = 0;
    [HideInInspector] public int score = 0, money = 100, potions = 1;
    [HideInInspector] public int difficulty = 1;
    [HideInInspector] public int level = 1;
    [HideInInspector] public int turn = 0;
    [HideInInspector] public string stage;
    [HideInInspector] public float curDamage;
    [HideInInspector] public float curHeal;
    private UnityEngine.Object skeletonWeak, skeletonStrong, zombie, orc, bleed;
    //private List<UnityEngine.Object> enemyPref;
    private UnityEngine.Object[] enemyPref = new UnityEngine.Object[2];
    [HideInInspector] public List<GameObject> characters;
    private List<GameObject> enemies;
    private const float minXenemyPos = 0.558f, maxXenemyPos = 0.676f;
    //stages:
    //planning - выбор персонажа, покупка улучшений
    //attacking - выбор врага для атаки
    //healing - выбор союзника для лечения
    //enemyTurn - ход врага, игрок ничего не делает
    //enemyAttack - процесс атаки врага

    private void Start()
    {
        stage = "planning";
        curDamage = 0f;
        money = 100;
        enemiesOnScreen = 0;
        skeletonWeak = Resources.Load("Skeleton_weak");
        skeletonStrong = Resources.Load("Skeleton_strong");
        enemyPref[0] = skeletonWeak;
        enemyPref[1] = skeletonStrong;
        bleed = Resources.Load("Effect_blood");
        characters = new List<GameObject>();
        enemies = new List<GameObject>();
        characters.Add(GameObject.FindGameObjectWithTag("Player"));
        characters.Add(GameObject.FindGameObjectWithTag("Knight"));
        characters.Add(GameObject.FindGameObjectWithTag("Magician"));
    }

    private void Update()
    {
        potionAmount.gameObject.GetComponent<Text>().text = potions.ToString();
        coins.gameObject.GetComponent<Text>().text = money.ToString();
        levelText.gameObject.GetComponent<Text>().text = level.ToString();
        difficulty = enemiesKilled / 5 + 1;
        diffText.gameObject.GetComponent<Text>().text = difficulty.ToString();
        print(stage);
        print(turn);
        if (turn == charsOnScreen && stage == "planning")
        {
            stage = "enemyTurn";
            turn = 1;
        }
        if (stage == "enemyTurn" && gameObject.activeSelf)
        {
            int queue = 0;
            foreach(GameObject obj in enemies)
            {
                if(obj != null && obj.activeSelf)
                {
                    print(obj.activeSelf);
                    StartCoroutine(EnemyAttack(obj, queue));
                    queue++;
                }
            }
            turn = 0;
            stage = "planning";
        }
        if (enemiesOnScreen == 0)
        {
            var rand = new System.Random();
            stage = "planning";
            turn = 0;
            List<GameObject> enemiesDelete = new List<GameObject>(enemies);
            enemies.Clear();
            int maxEnemiesCount = 3;
            if (enemiesKilled == 0) maxEnemiesCount = 1;
            for (; enemiesOnScreen < maxEnemiesCount; enemiesOnScreen++)
            {
                GameObject enemyRef = (GameObject)Instantiate(enemyPref[rand.Next(0, 2)]); 
                
                enemyRef.transform.SetParent(gameObject.transform);
                enemyRef.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                RectTransform rec;
                rec = enemyRef.gameObject.GetComponent<RectTransform>();
                rec.anchorMin = new Vector2(minXenemyPos, 0.698f - 0.301f * ((enemiesOnScreen + 1) % 3));
                rec.anchorMax = new Vector2(maxXenemyPos, 0.904f - 0.301f * ((enemiesOnScreen + 1) % 3));
                rec.offsetMin = new Vector3(0f, 0f);
                rec.offsetMax = new Vector3(0f, 0f);
                enemies.Add(enemyRef);
                enemyRef.GetComponent<EnemyController>().turn = (enemiesOnScreen + 1);
            }
            foreach(GameObject obj in enemiesDelete)
            {
                StartCoroutine(DestroyEnemy(obj));
            }
        }
    }

    IEnumerator DestroyEnemy(GameObject obj)
    {
        yield return new WaitForSeconds(5f);
        Destroy(obj.GetComponent<EnemyController>().barBgRef);
        Destroy(obj.GetComponent<EnemyController>().barRef);
        Destroy(obj);
    }

    IEnumerator EnemyAttack(GameObject obj, int queue)
    {
        yield return new WaitForSeconds(1.5f * queue);
        if (obj.activeSelf)
        {
            curDamage = obj.GetComponent<EnemyController>().damage + 5 * (difficulty - 1);
            obj.GetComponent<EnemyController>().Slash();
            var rand = new System.Random();
            int index = rand.Next(0, charsOnScreen);
            if (!characters[index].GetComponent<PlayerController>().hired)
            {
                if (index == 2) index = 1;
                else index = 2;
            }
            GameObject bleedRef = (GameObject)Instantiate(bleed);
            bleedRef.transform.position =
                new Vector3(characters[index].transform.position.x,
                characters[index].transform.position.y,
                characters[index].transform.position.z);
            characters[index].GetComponent<PlayerController>().health -= curDamage;
        }
    }
}
