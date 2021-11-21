using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    private Animator animator;
    public Image character;
    private GameObject controller;
    [HideInInspector] public bool attacking = false;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        animator = character.gameObject.GetComponent<Animator>();
    }

    private void OnMouseUp()
    {
        controller.gameObject.GetComponent<GlobalController>().stage = "attacking";
        controller.gameObject.GetComponent<GlobalController>().curDamage = character.gameObject.GetComponent<PlayerController>().damage;
        StartCoroutine(Slash());
    }

    IEnumerator Slash()
    {
        attacking = true;
        animator.Play("Hero_slash");
        yield return new WaitForSeconds(0.85f);
        attacking = false;
    }
}
