using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBossBullets : MonoBehaviour
{
    public float speed = 5f;

    private Transform player;
    private Vector3 target;
    public float dmg = 0.5f;
    private float pCurrentHealth = 0f;
    private bool hasShield;

    private GameObject healthBar;
    private Vector3 scaleChange;




    private void Start()
        {

            player = GameObject.FindGameObjectWithTag("Player").transform;


            target = new Vector3(Random.Range(240.8989f, 267.6654f), Random.Range(-27.64096f, -25.26324f), 0);

            healthBar = GameObject.FindGameObjectWithTag("Playerhealth");
            scaleChange = new Vector3(-35f, -0, -0);
            

    }

    private void Update()
    {

        hasShield = GameObject.FindWithTag("Player").GetComponent<playermoves>().shield;
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

    }



        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.gameObject.tag == "Player")
            {
                if (GameObject.Find("Shield Image") != null)
                {

                    GameObject.Find("Shield Image").GetComponent<ShieldEffect>().run = true;

                }

                if (hasShield == true)
                {

                    Destroy(gameObject);

                }
                else
                {

                    pCurrentHealth = GameObject.FindWithTag("Player").GetComponent<playermoves>().pHealth;
                    GameObject.FindWithTag("Player").GetComponent<playermoves>().pHealth = pCurrentHealth - dmg;
                    healthBar.transform.localScale += scaleChange;
                    Destroy(gameObject);

                }
                

            }
            else if (collision.gameObject.tag != "Platform" && collision.gameObject.tag != "Boss" && collision.gameObject.tag != "EnemyBullet" && collision.gameObject.tag != "Item" && collision.gameObject.tag != "Gun")
            {

                Destroy(gameObject);

            }

        }

}

