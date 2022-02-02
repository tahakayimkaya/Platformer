using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb0;
    private Rigidbody2D rb;
    private Rigidbody2D rb2;
    private Rigidbody2D rb3;
    private Rigidbody2D rb4;
    private Rigidbody2D rb5;
    private Rigidbody2D rb6;

    // Start is called before the first frame update
    void Start()
    {
        rb0 = GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        rb2 = GetComponent<Rigidbody2D>();
        rb3 = GetComponent<Rigidbody2D>();
        rb4 = GetComponent<Rigidbody2D>();
        rb5 = GetComponent<Rigidbody2D>();
        rb6 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >= -2.73f && gameObject.tag == "lvl1")
        {
            rb2.constraints = RigidbodyConstraints2D.None;
            rb2.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else if(player.transform.position.x>= 17.0f && gameObject.tag == "lvl2")
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else if(player.transform.position.x >= 33.6f && gameObject.tag == "lvl3")
        {
            rb2.constraints = RigidbodyConstraints2D.None;
            rb2.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else if (player.transform.position.x >= 40.49783f && gameObject.tag == "lvl4")
        {
            rb3.constraints = RigidbodyConstraints2D.None;
            rb3.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else if (player.transform.position.x >= 47.07f && gameObject.tag == "lvl5")
        {
            rb4.constraints = RigidbodyConstraints2D.None;
            rb4.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else if (player.transform.position.x >= 53.07f && gameObject.tag == "lvl6")
        {
            rb5.constraints = RigidbodyConstraints2D.None;
            rb5.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else if (player.transform.position.x >= 61.07f && gameObject.tag == "lvl7")
        {
            rb6.constraints = RigidbodyConstraints2D.None;
            rb6.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
