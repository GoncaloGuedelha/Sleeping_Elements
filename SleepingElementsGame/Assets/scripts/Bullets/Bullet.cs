using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody2D rb;
    //private GameObject enemy;
    //public float dmg = 1f;
    private int hitsdone = 0;



    // Start is called before the first frame update
    void Start()
    {

        hitsdone = GameObject.FindWithTag("Gun").GetComponent<gunshoots>().hits;

        rb = GetComponent<Rigidbody2D>();
        //enemy = GameObject.Find("enemy");

    }

    // Update is called once per frame


    void Update()
    {


        rb.gravityScale = 0;

        if (Vector2.Distance(transform.position, Camera.main.transform.position) > 10)
            Destroy(gameObject);

    }

  
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

    
       
        /*if (collision.gameObject.tag == "Enemy")
        {

    meeleenemy eneHealth = enemy.GetComponent<meeleenemy>();
        Debug.Log(eneHealth.health);

            eneHealth.health = eneHealth.health - dmg;
            Destroy(gameObject);
            Debug.Log(eneHealth.health);
            if(eneHealth.health <= 0) { 

            Destroy(collision.gameObject);
            
            }
        }*/

        if (collision.gameObject.tag != "Gun" && collision.gameObject.tag != "Player" && collision.gameObject.tag != "Item" && collision.gameObject.tag != "Platform" && collision.gameObject.tag != "EnemyBullet") 
        {
            if(hitsdone == 0)
            {

                Destroy(gameObject);

            }
            else
            {

                hitsdone--;

            }
            
           /* if (collision.gameObject.tag != "Player") 
            {

                if (collision.gameObject.tag != "Pet")
                {
                    Destroy(gameObject);
                }
                    
            }*/
        }
        /*else if (collision.gameObject.tag != "Pet")
        {



        }*/
    }
}


