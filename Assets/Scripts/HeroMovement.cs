using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HeroMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator,animatorFlag;
    public GameObject hero, enemy;

    public SFX_Manager stop_music;

    public AudioClip level_complete;

    public UnityEngine.UI.Button leftButton, rightButton,jumpButton;
    
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;

    public Transform attackPoint;
    public float attackRange = 0.8f;
    public LayerMask enemyLayers;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    private float delaytime = 1.5f;

    public Text levelCompletedText;

    public Button mainMenuButton;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Jump()
    {
        jump = true;
        jumpAnimation();
    }
    public void pointerDownLeft()
    {
        horizontalMove = -runSpeed;
        runningAnimation();
    }
    public void pointerDownRight()
    {
        horizontalMove = runSpeed;
        runningAnimation();
    }
    public void pointerUpLeft()
    {
        horizontalMove = 0f;
        idleAnimation();
    }
    public void pointerUpRight()
    {
        horizontalMove = 0f;
        idleAnimation();
    }



    private void FixedUpdate()
    {
        jumpButton.onClick.AddListener(Jump);
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        notJumpAnimation();
    }

    public void runningAnimation()
    {
        GetComponent<Animator>().SetBool("isRunning", true);
    }

    public void idleAnimation()
    {
        GetComponent<Animator>().SetBool("isRunning", false);
        GetComponent<Animator>().SetBool("isTakingHit", false);
    }

    public void jumpAnimation()
    {
        GetComponent<Animator>().SetBool("isJumping", true);
        GetComponent<Animator>().SetBool("isTakingHit", false);
    }

    public void notJumpAnimation()
    {
        GetComponent<Animator>().SetBool("isJumping", false);
        GetComponent<Animator>().SetBool("isTakingHit", false);
    }

    public void attackingAnimation()
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }
        
    }

    void Attack()
    {
        Collider2D[] hitEnemies =Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(50);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void notAttackingAnimation()
    {
        GetComponent<Animator>().SetBool("isAttacking", false);
    }


    IEnumerator delayComplete()
    {
        yield return new WaitForSeconds(delaytime);
        Time.timeScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "flag")
        {
            stop_music.background_music.Stop();
            AudioSource.PlayClipAtPoint(level_complete, gameObject.transform.position, 1f);
            animatorFlag.SetBool("collisionEnter", true);
            levelCompletedText.gameObject.SetActive(true);
            mainMenuButton.gameObject.SetActive(true);
            StartCoroutine(delayComplete());
        }
    }
}
