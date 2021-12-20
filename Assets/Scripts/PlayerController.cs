using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float damage;
    public float healPower;
    public int value;

    private GameObject controller;
    private Vector2 beginPosMax, beginPosMin;
    private UnityEngine.Object splash;
    [HideInInspector] public bool hired = false;
    [HideInInspector] public bool done = false;

    private void Start()
    {
        if (gameObject.tag == "Player") hired = true;
        controller = GameObject.FindGameObjectWithTag("GameController");
        beginPosMax = GetComponent<RectTransform>().offsetMax;
        beginPosMin = GetComponent<RectTransform>().offsetMin;
        splash = Resources.Load("Effect_heal");
    }

    private void Update()
    {
        if (health <= 0f && hired)
        {
            if (gameObject.tag != "Player")
            {
                gameObject.GetComponent<RectTransform>().offsetMin = beginPosMin;
                gameObject.GetComponent<RectTransform>().offsetMax = beginPosMax;
                hired = false;
                controller.GetComponent<GlobalController>().charsOnScreen--;
            }
            else
            {
                controller.GetComponent<GlobalController>().stage = "gameOver";
                StartCoroutine(Death());
            }
        }
        if (controller.GetComponent<GlobalController>().stage == "planning" || controller.GetComponent<GlobalController>().stage == "healing")
            gameObject.GetComponent<Collider2D>().enabled = true;
        else gameObject.GetComponent<Collider2D>().enabled = false;
    }

    IEnumerator Death()
    {
        gameObject.GetComponent<Animator>().Play("Hero_death");
        yield return new WaitForSeconds(1f);
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        gameObject.GetComponent<Animator>().Play("Hero_dead");
        yield return new WaitForSeconds(0.01f);
        SceneManager.LoadScene(0);
    }

    private void OnMouseUp()
    {
        if (controller.GetComponent<GlobalController>().stage == "healing")
        {
            if (health < maxHealth)
            {
                health += controller.GetComponent<GlobalController>().curHeal;
                if (health > maxHealth) health = maxHealth;
                GameObject splashRef = (GameObject)Instantiate(splash);
                splashRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
                StartCoroutine(StopEffect(splashRef));
                controller.GetComponent<GlobalController>().potions--;
                controller.GetComponent<GlobalController>().stage = "planning";
                controller.GetComponent<GlobalController>().turn++;
            }
        }
    }

    IEnumerator StopEffect(GameObject splashRef)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(splashRef);
    }
}
