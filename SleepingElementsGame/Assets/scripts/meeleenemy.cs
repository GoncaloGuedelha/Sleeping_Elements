using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meeleenemy : MonoBehaviour
{

    public float health = 2f;
    public float  dmgTaken = 0f;

    // Start is called before the first frame update
    void Start()
    {

        

        //Debug.Log(dmgTaken);

    }

    // Update is called once per frame
    void Update()
    {       


        if (health <= 0)
        {

            Destroy(gameObject);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {   
            
            dmgTaken = GameObject.Find("gun").GetComponent<gunshoots>().dmg;

            health = health - dmgTaken;

        }
    }
}
