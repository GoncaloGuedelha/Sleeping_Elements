using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{

    private Transform player;
    public float dmg = 0.5f;
    private float pCurrentHealth = 0f;

    private GameObject healthBar;
    private Vector3 scaleChange;
    private bool hasShield;


    //[SerializeField] private GameObject items;


    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;


        healthBar = GameObject.FindGameObjectWithTag("Playerhealth");
        scaleChange = new Vector3(-35f, -0, -0);
        

        //items = GameObject.FindGameObjectWithTag("Itembar");

    }

    private void Update()
    {

        hasShield = GameObject.FindWithTag("Player").GetComponent<playermoves>().shield;

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.gameObject.tag != "Enemy")
        {
            //Destroy(gameObject);
             /*if (collision.CompareTag("Player")) {
                //Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        } */
        if (collision.gameObject.tag == "Player")
        {

            if (hasShield == true)
            {

                GameObject.Find("Shield Image").GetComponent<ShieldEffect>().maximumStack--;
                Destroy(gameObject);
            }
            else
            {

                pCurrentHealth = GameObject.FindWithTag("Player").GetComponent<playermoves>().pHealth;
                //Debug.Log("ahahahahah");
                //Debug.Log(pCurrentHealth);
                GameObject.FindWithTag("Player").GetComponent<playermoves>().pHealth = pCurrentHealth - dmg;
                healthBar.transform.localScale += scaleChange;
                Destroy(gameObject);

            }

            

        }
        else if (collision.gameObject.tag != "Platform" && collision.gameObject.tag != "Boss" && collision.gameObject.tag != "EnemyBullet" && collision.gameObject.tag != "Item" && collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Gun")
        {

            Destroy(gameObject);

        }

    }

}
