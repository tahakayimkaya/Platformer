using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject go;
    public Animator animator,animatorHero;
    public AudioClip fly_death;

    public void TakeDamage(int damage)
    {
        health -= damage;

        animator.SetTrigger("hit");

        if (health <= 0)
        {
            Die();
            AudioSource.PlayClipAtPoint(fly_death, gameObject.transform.position, 1f);
        }
    }

    void Die()
    {
        animator.SetBool("isDead",true);

        animatorHero.SetBool("isTakingHit", false);

        print(animatorHero.GetBool("isTakingHit"));

        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;

        Destroy(go,1f);
    }
}
