using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public float health;
    [SerializeField] public float maxHealth;
    [SerializeField] public float damage;
    [SerializeField] public int value;
    [SerializeField] public string enemyType;

    private UnityEngine.Object splash, barBg, bar;
    private Animator animator;
    private Collider2D coll;
    private GameObject controller;
    private GameObject barRef, barBgRef;

    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        coll = GetComponent<Collider2D>();
        coll.enabled = false;
        barBg = Resources.Load("Health_back");
        bar = Resources.Load("Bar");
        
        
        animator = GetComponent<Animator>();
        if (enemyType == "sk_w")
            splash = Resources.Load("Effect_bone");
        else
            splash = Resources.Load("Effect_slime");
        switch(enemyType)
        {
            case "sk_w":
                StartCoroutine(AwakeAnim("Skeleton_weak"));
                break;
        }
    }

    IEnumerator AwakeAnim(string type)
    {
        string type_anim = type + "_awake";
        animator.Play(type_anim);
        yield return new WaitForSeconds(0.85f);
        StartCoroutine(IdleAnim(type));
    }

    IEnumerator IdleAnim(string type)
    {
        string type_anim = type + "_Idle"; ;
        animator.Play(type_anim);
        barBgRef = (GameObject)Instantiate(barBg);
        barBgRef.transform.SetParent(controller.transform);
        barBgRef.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        RectTransform rec;
        rec = barBgRef.gameObject.GetComponent<RectTransform>();
        rec.anchorMin = new Vector2(0.558f, 0.603f);
        rec.anchorMax = new Vector2(0.676f, 0.644f);
        rec.offsetMin = new Vector2(0f, 0f);
        rec.offsetMax = new Vector2(0f, 0f);
        barRef = (GameObject)Instantiate(bar);

        barRef.transform.SetParent(controller.transform);
        rec = barRef.gameObject.GetComponent<RectTransform>();
        rec.anchorMin = new Vector2(0.558f, 0.603f);
        rec.anchorMax = new Vector2(0.676f, 0.644f);
        rec.offsetMin = new Vector2(0f, 0f);
        rec.offsetMax = new Vector2(0f, 0f);
        barRef.gameObject.transform.localScale = new Vector3(0.95f, 0.8f, 1f);
        yield return new WaitForSeconds(0f);
    }

    private void OnMouseUp()
    {
        GameObject splashRef = (GameObject)Instantiate(splash);
        splashRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        health -= controller.gameObject.GetComponent<GlobalController>().curDamage;
        StartCoroutine(StopEffect(splashRef));

    }

    IEnumerator StopEffect(GameObject splashRef)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(splashRef);
    }

    private void Update()
    {
        if (controller.gameObject.GetComponent<GlobalController>().stage == "attacking")
            coll.enabled = true;
        else
            coll.enabled = false;
        try
        {
            barRef.GetComponent<Image>().fillAmount = health / maxHealth;
        }
        catch { }
        if (health <= 0f) Death();
    }

    private void Death()
    {
        var rand = new System.Random();
        controller.gameObject.GetComponent<GlobalController>().money += 
            (value + rand.Next(-5, 6)) * controller.gameObject.GetComponent<GlobalController>().difficulty;
        controller.gameObject.GetComponent<GlobalController>().score += value;
        controller.gameObject.GetComponent<GlobalController>().enemiesKilled++;
        controller.gameObject.GetComponent<GlobalController>().cenemiesOnScreen--;
        if (rand.Next(0, 5) == 1) controller.gameObject.GetComponent<GlobalController>().potions++;
        //Destroy(gameObject);
        gameObject.SetActive(false);
        barRef.SetActive(false);
        barBgRef.SetActive(false);
    }
}
