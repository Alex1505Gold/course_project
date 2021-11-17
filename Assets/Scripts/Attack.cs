using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    private Animator animator;
    public Image character;
    bool attacking = false;

    private void Start()
    {
        animator = character.gameObject.GetComponent<Animator>();
    }

    private void OnMouseUp()
    {
        StartCoroutine(Slash());
    }
    
    public bool GetCondition()
    {
        return attacking;
    }

    IEnumerator Slash()
    {
        attacking = true;
        animator.Play("Hero_slash");
        yield return new WaitForSeconds(0.85f);
        attacking = false;
    }
}
