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
    private string type;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        animator = character.gameObject.GetComponent<Animator>();
        type = character.gameObject.tag;
    }

    private void OnMouseUp()
    {
        if (controller.GetComponent<GlobalController>().stage == "planning")
        {
            controller.gameObject.GetComponent<GlobalController>().stage = "attacking";
            controller.gameObject.GetComponent<GlobalController>().curDamage = 
                character.gameObject.GetComponent<PlayerController>().damage + 5 * (controller.GetComponent<GlobalController>().level - 1);
            StartCoroutine(Slash());
        }
        else if (controller.GetComponent<GlobalController>().stage == "attacking")
        {
            controller.GetComponent<GlobalController>().stage = "planning";
        }
    }

    IEnumerator Slash()
    {
        attacking = true;
        if (type == "Player") animator.Play("Hero_slash");
        else if (type == "Knight") animator.Play("Knight_slash");
        else if (type == "Magician") animator.Play("Magician_slash");
        yield return new WaitForSeconds(0.85f);
        attacking = false;
    }
}
