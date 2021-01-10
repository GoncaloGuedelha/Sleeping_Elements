using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

            GameObject.FindWithTag("Boss").GetComponent<Boss>().triggered = true;

        }    

    }
}
