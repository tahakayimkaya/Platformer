using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{
    private float lifeVal = 100f;

    private float delaytime = 1f;

    public AudioClip heal, hero_hurt, hero_death;

    public Animator animator;

    public Text gameOverText;

    public Button mainMenuButton;

    public Image HealthBar;

    private float CurrentHealth;

    public GameObject chestObject, chestObject0, chestObject1, chestObject2, chestObject3,collectHeartObject, collectHeartObject0, collectHeartObject1, collectHeartObject2, collectHeartObject3;

    private bool isCollected=false, isCollected0 = false, isCollected1 = false, isCollected2 = false, isCollected3 = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
       // animatorChest = chestObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = lifeVal;
        HealthBar.fillAmount = CurrentHealth / 100f;
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(delaytime);
        collectHeartObject.SetActive(true);
    }

    IEnumerator delay1()
    {
        yield return new WaitForSeconds(delaytime);
        collectHeartObject0.SetActive(true);
    }

    IEnumerator delay2()
    {
        yield return new WaitForSeconds(delaytime);
        collectHeartObject1.SetActive(true);
    }

    IEnumerator delay3()
    {
        yield return new WaitForSeconds(delaytime);
        collectHeartObject2.SetActive(true);
    }

    IEnumerator delay4()
    {
        yield return new WaitForSeconds(delaytime);
        collectHeartObject3.SetActive(true);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "lvl1" || collision.gameObject.tag == "lvl2" || collision.gameObject.tag == "lvl3" || collision.gameObject.tag == "lvl4" || collision.gameObject.tag == "lvl5" || collision.gameObject.tag == "lvl6" || collision.gameObject.tag == "lvl7")
        {
            lifeVal -= 5;
            AudioSource.PlayClipAtPoint(hero_hurt, gameObject.transform.position, 1f);
            GetComponent<Animator>().SetBool("isTakingHit", true);
            if (lifeVal <= 0)
            {
                AudioSource.PlayClipAtPoint(hero_death, gameObject.transform.position, 1f);
                GetComponent<Animator>().SetBool("isDying", true);
                Time.timeScale = 0;
                gameOverText.gameObject.SetActive(true);
                mainMenuButton.gameObject.SetActive(true);
            }
        }
        else if (collision.gameObject.tag == "enemy")
        {
            lifeVal -= 3;
            AudioSource.PlayClipAtPoint(hero_hurt, gameObject.transform.position, 1f);
            GetComponent<Animator>().SetBool("isTakingHit", true);
            if (lifeVal <= 0)
            {
                AudioSource.PlayClipAtPoint(hero_death, gameObject.transform.position, 1f);
                GetComponent<Animator>().SetBool("isDying", true);
                Time.timeScale = 0;
                gameOverText.gameObject.SetActive(true);
                mainMenuButton.gameObject.SetActive(true);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "lvl1" || collision.gameObject.tag == "lvl2" || collision.gameObject.tag == "lvl3" || collision.gameObject.tag == "lvl4" || collision.gameObject.tag == "lvl5" || collision.gameObject.tag == "lvl6" || collision.gameObject.tag == "lvl7")
        {
            GetComponent<Animator>().SetBool("isTakingHit", false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Chest" && isCollected==false)
        {
            chestObject.GetComponent<Animator>().SetBool("isActive", true);
            //collectHeartObject.SetActive(true);
            StartCoroutine(delay());
            isCollected = true;
        }
        else if (collision.gameObject.tag == "Chest0" && isCollected0 == false)
        {
            chestObject0.GetComponent<Animator>().SetBool("isActive", true);
            //collectHeartObject0.SetActive(true);
            StartCoroutine(delay1());
            isCollected0 = true;
        }
        else if (collision.gameObject.tag == "Chest1" && isCollected1 == false)
        {
            chestObject1.GetComponent<Animator>().SetBool("isActive", true);
            //collectHeartObject1.SetActive(true);
            StartCoroutine(delay2());
            isCollected1 = true;
        }
        else if (collision.gameObject.tag == "Chest2" && isCollected2 == false)
        {
            chestObject2.GetComponent<Animator>().SetBool("isActive", true);
            //collectHeartObject2.SetActive(true);
            StartCoroutine(delay3());
            isCollected2 = true;
        }
        else if (collision.gameObject.tag == "Chest3" && isCollected3 == false)
        {
            chestObject3.GetComponent<Animator>().SetBool("isActive", true);
            //collectHeartObject3.SetActive(true);
            StartCoroutine(delay4());
            isCollected3 = true;
        }
        else if (collision.gameObject.tag == "heartCollect")
        {
            AudioSource.PlayClipAtPoint(heal, gameObject.transform.position, 1f);
            if (lifeVal + 20 <= 100)
            {
                lifeVal += 20;
                Destroy(collectHeartObject);
                print(lifeVal);

            }
            else if (lifeVal <= 100 && lifeVal >= 80)
            {
                lifeVal = 100;
                Destroy(collectHeartObject);
                print(lifeVal);
            }
        }
        else if (collision.gameObject.tag == "heartCollect0")
        {
            AudioSource.PlayClipAtPoint(heal, gameObject.transform.position, 1f);
            if (lifeVal + 20 <= 100)
            {
                lifeVal += 20;
                Destroy(collectHeartObject0);
                print(lifeVal);

            }
            else if (lifeVal <= 100 && lifeVal >= 80)
            {
                lifeVal = 100;
                Destroy(collectHeartObject0);
                print(lifeVal);
            }
        }
        else if (collision.gameObject.tag == "heartCollect1")
        {
            AudioSource.PlayClipAtPoint(heal, gameObject.transform.position, 1f);
            if (lifeVal + 20 <= 100)
            {
                lifeVal += 20;
                Destroy(collectHeartObject1);
                print(lifeVal);

            }
            else if (lifeVal <= 100 && lifeVal >= 80)
            {
                lifeVal = 100;
                Destroy(collectHeartObject1);
                print(lifeVal);
            }
        }
        else if (collision.gameObject.tag == "heartCollect2")
        {
            AudioSource.PlayClipAtPoint(heal, gameObject.transform.position, 1f);
            if (lifeVal + 20 <= 100)
            {
                lifeVal += 20;
                Destroy(collectHeartObject2);
                print(lifeVal);

            }
            else if (lifeVal <= 100 && lifeVal >= 80)
            {
                lifeVal = 100;
                Destroy(collectHeartObject2);
                print(lifeVal);
            }
        }
        else if (collision.gameObject.tag == "heartCollect3")
        {
            AudioSource.PlayClipAtPoint(heal, gameObject.transform.position, 1f);
            if (lifeVal + 20 <= 100)
            {
                lifeVal += 20;
                Destroy(collectHeartObject3);
                print(lifeVal);

            }
            else if (lifeVal <= 100 && lifeVal >= 80)
            {
                lifeVal = 100;
                Destroy(collectHeartObject3);
                print(lifeVal);
            }
        }
    }


    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }
}
