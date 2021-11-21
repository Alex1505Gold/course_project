using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveForward : MonoBehaviour
{
    public GameObject health_bg, health;
    public Text attack;
    public float speed = 5f, checkpos = 0f;
    private RectTransform rec;
    private Collider2D coll;
    private Animator animator;
    private bool stop = false;

    void Start()
    {
        rec = GetComponent<RectTransform>();
        animator = GetComponent<Animator>();
        health_bg.gameObject.SetActive(false);
        health.gameObject.SetActive(false);
        coll = GetComponent<Collider2D>();
        coll.enabled = false;
    }

    void Update()
    {
        if (System.Math.Round(rec.offsetMin.x) <= checkpos && GetComponent<PlayerController>().hired)
        {
            rec.offsetMin += new Vector2(speed, 0);
            rec.offsetMax += new Vector2(speed, 0);
            stop = false;
        }
        else
        {
            stop = true;
        }
    }

    private void FixedUpdate()
    {
        if (!stop)
        {
            animator.Play("Hero_run");
        }
        else if (GetComponent<PlayerController>().hired)
        {
            if (!attack.gameObject.GetComponent<Attack>().attacking)
                animator.Play("Hero_Idle");
            health_bg.gameObject.SetActive(true);
            health.gameObject.SetActive(true);
            coll.enabled = true;
        }
    }
}
