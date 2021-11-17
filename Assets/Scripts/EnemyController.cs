using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public float health;
    [SerializeField] public float maxHealth;
    [SerializeField] public float damage;
    [SerializeField] public string enemyType;

    private Object splash;
    private Animator animator;

    void Start()
    {
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
        yield return new WaitForSeconds(0f);
    }

    private void OnMouseUp()
    {
        GameObject splashRef = (GameObject)Instantiate(splash);
        splashRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        StartCoroutine(StopEffect(splashRef));

    }

    IEnumerator StopEffect(GameObject splashRef)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(splashRef);
    }
}
