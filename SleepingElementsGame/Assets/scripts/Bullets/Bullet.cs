using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody2D rb;
    public float dmg = 5f;
    private float dmgBoost = 0;
    private int hitsdone = 0;



    void Start()
    {

        hitsdone = GameObject.FindWithTag("Gun").GetComponent<gunshoots>().hits;

        rb = GetComponent<Rigidbody2D>();

        if(GameObject.Find("Pet") != null) 
        {
            
            dmgBoost = GameObject.Find("Pet").GetComponent<Peteffect>().dmgBoost;
            dmg = dmg + dmgBoost;

        }
    }



    void Update()
    {

        rb.gravityScale = 0;

        if (Vector2.Distance(transform.position, Camera.main.transform.position) > 10)
            Destroy(gameObject);

    }

  
    
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag != "Gun" && collision.gameObject.tag != "Player" && collision.gameObject.tag != "Item" && collision.gameObject.tag != "Platform" && collision.gameObject.tag != "EnemyBullet" && collision.gameObject.tag != "Trigger") 
        {
            if(hitsdone == 0)
            {

                Destroy(gameObject);

            }
            else
            {

                hitsdone--;

            }
            
        }

    }
}


