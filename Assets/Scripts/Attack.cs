using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public GameObject player;
    public Animator animator;
    public Damage damage;

    void Update()
    {
        if (1.8f > Mathf.Abs(gameObject.transform.position.x - player.transform.position.x))
        {
            animator.SetBool("isAttacking", true);
        }

        else
        {
            animator.SetBool("isAttacking", false);
        }
            
    }

}
