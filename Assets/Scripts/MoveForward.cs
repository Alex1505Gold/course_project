using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveForward : MonoBehaviour
{
    public GameObject health_bg, health;
    public Text attack;
    public Text attackTxt;
    public Text healTxt;
    public Image bg1;
    public Image bg2;
    public float speed = 5f, checkpos = 0f;
    private RectTransform rec;
    private Collider2D coll;
    private Animator animator;
    private bool stop = false;

    void Start()
    {
        bool flag = false;
        rec = GetComponent<RectTransform>();
        animator = GetComponent<Animator>();
        health_bg.gameObject.SetActive(false);
        health.gameObject.SetActive(false);
        coll = GetComponent<Collider2D>();
        coll.enabled = false;
        attackTxt.gameObject.SetActive(flag);
        healTxt.gameObject.SetActive(flag);
        bg1.gameObject.SetActive(flag);
        bg2.gameObject.SetActive(flag);
        attackTxt.gameObject.GetComponent<Collider2D>().enabled = flag;
        healTxt.gameObject.GetComponent<Collider2D>().enabled = flag;
    }

    void Update()
    {
        if (System.Math.Round(rec.offsetMin.x) <= checkpos && GetComponent<PlayerController>().hired)
        {
            rec.offsetMin += new Vector2(speed, 0);
            rec.offsetMax += new Vector2(speed, 0);
            stop = false;
            if (gameObject.tag == "Player") animator.Play("Hero_run");
            else if (gameObject.tag == "Knight") animator.Play("Knight_run");
            else if (gameObject.tag == "Magician") animator.Play("Magician_run");
        }
        else if (GetComponent<PlayerController>().hired)
        {
            stop = true;
            bool flag = true;
            if (!attack.gameObject.GetComponent<Attack>().attacking)
                if (gameObject.tag == "Player") animator.Play("Hero_Idle");
                else if (gameObject.tag == "Knight") animator.Play("Knight_Idle");
                else if (gameObject.tag == "Magician") animator.Play("Magician_Idle");
            health_bg.gameObject.SetActive(true);
            health.gameObject.SetActive(true);
            coll.enabled = true;
            attackTxt.gameObject.SetActive(flag);
            healTxt.gameObject.SetActive(flag);
            bg1.gameObject.SetActive(flag);
            bg2.gameObject.SetActive(flag);
            attackTxt.gameObject.GetComponent<Collider2D>().enabled = flag;
            healTxt.gameObject.GetComponent<Collider2D>().enabled = flag;
        }
        else
        {
            bool flag = false;
            health_bg.gameObject.SetActive(false);
            health.gameObject.SetActive(false);
            coll.enabled = false;
            attackTxt.gameObject.SetActive(flag);
            healTxt.gameObject.SetActive(flag);
            bg1.gameObject.SetActive(flag);
            bg2.gameObject.SetActive(flag);
            attackTxt.gameObject.GetComponent<Collider2D>().enabled = flag;
            healTxt.gameObject.GetComponent<Collider2D>().enabled = flag;
        }
    }
    /*
    private void FixedUpdate()
    {
        if (!stop)
        {
            if (gameObject.tag == "Player") animator.Play("Hero_run");
            else if (gameObject.tag == "Knight") animator.Play("Knight_run");
            else if (gameObject.tag == "Magician") animator.Play("Magician_run");
        }
        else if (GetComponent<PlayerController>().hired)
        {
            if (!attack.gameObject.GetComponent<Attack>().attacking)
                if (gameObject.tag == "Player") animator.Play("Hero_Idle");
                else if (gameObject.tag == "Knight") animator.Play("Knight_Idle");
                else if (gameObject.tag == "Magician") animator.Play("Magician_Idle");
            health_bg.gameObject.SetActive(true);
            health.gameObject.SetActive(true);
            coll.enabled = true;
        }
    }
    */
}
