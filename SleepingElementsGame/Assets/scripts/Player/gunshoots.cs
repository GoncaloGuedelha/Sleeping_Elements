using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunshoots : MonoBehaviour
{

    private Rigidbody2D rb;
    public float minMouseDistance = 40f;
    public GameObject bulletPrefab;
    private GameObject player;
    private GameObject gunPoint;
    private GameObject weaponGet;

    private SpriteRenderer spriteRenderer;

    public float bulletSpeed = 13f;
    public float bulletStartOffSet = 0.75f;
    public float cooldownTime = 0.5f;
    public float dmg = 1f;
    public int hits = 0;
    public bool inGun = false;
    private float offSet = .2f;
    private float shootTimer = 0f;


    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindWithTag("Player");
        gunPoint = GameObject.Find("pivotPoint");
        weaponGet = GameObject.Find("Weapons/Items");

        spriteRenderer = GetComponent<SpriteRenderer>(); 
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

    }

    private void Update()
    {


        if (gameObject.transform.parent == gunPoint.transform) 
        {
            

            float fireInput = Input.GetAxis("Fire1");
            if ((fireInput > 0) && (shootTimer <= 0))
            {

                Vector3 mouseDirection = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
                GameObject bullet = Instantiate(bulletPrefab, transform.position + (mouseDirection.normalized * bulletStartOffSet), gameObject.transform.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = mouseDirection.normalized * bulletSpeed;
                shootTimer = cooldownTime;

            }


            if (shootTimer >= 0)
            {

                shootTimer -= Time.deltaTime;

            }

        }

        if(inGun == true && Input.GetKeyDown(KeyCode.E))
        {

            //Debug.Log("Seven Rings");
            gameObject.transform.parent = gunPoint.transform;
            gameObject.tag = "Gun";
            inGun = false;

            Transform oldWeapon = GameObject.Find("pivotPoint").transform.GetChild(0);
            //Debug.Log(firstChild);

            oldWeapon.transform.parent = weaponGet.transform;
            oldWeapon.tag = "DroppedGun";

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (gameObject.transform.parent == gunPoint.transform) 
        { 
            Vector3 fixedScale = new Vector3(Mathf.Clamp(transform.localScale.x, 1f, 1f),
                                            Mathf.Clamp(transform.localScale.y, .3f, .3f),
                                            Mathf.Clamp(transform.localScale.z, 0f, 0f));

            float angle = 0f;

            Vector2 mouseDirection = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            if (mouseDirection.magnitude > minMouseDistance)
            {

                angle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;


                rb.rotation = angle;
            
            

            

            }

            if(mouseDirection.x < player.transform.position.x)
            {
                spriteRenderer.flipX = true;
                player.GetComponent<SpriteRenderer>().flipX = true;

                if (offSet > 0)
                    offSet = offSet * -1;

            } 

            else if (mouseDirection.x > player.transform.position.x)
            {

                spriteRenderer.flipX = false;
                player.GetComponent<SpriteRenderer>().flipX = false;

            

             if (offSet < 0)
                offSet = offSet * -1;

            }

            transform.position = new Vector2(player.transform.position.x + offSet, player.transform.position.y);

            transform.localScale = fixedScale;
        }
    }

    /* private void OnTriggerEnter2D(Collider2D collision)
     {
         //Debug.Log("Speed through nights");

         if (gameObject.transform.parent == weaponGet.transform && collision.gameObject.tag == "Player")
         {
             //Debug.Log("Seven Rings");
             gameObject.transform.parent = gunPoint.transform;

             Transform oldWeapon = GameObject.Find("pivotPoint").transform.GetChild(0);
             //Debug.Log(firstChild);

             oldWeapon.transform.parent = weaponGet.transform;

         }


     }*/

    /* private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Speed through nights");

        if (gameObject.transform.parent == weaponGet.transform && collision.gameObject.tag == "Player")
        {
            //Debug.Log("Seven Rings");
            gameObject.transform.parent = gunPoint.transform;

            Transform oldWeapon = GameObject.Find("pivotPoint").transform.GetChild(0);
            //Debug.Log(firstChild);

            oldWeapon.transform.parent = weaponGet.transform;

        }


    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Speed through nights");

        if (gameObject.transform.parent == weaponGet.transform && collision.gameObject.tag == "Player")
        {

            inGun = true;

        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Speed through nights");

        if (gameObject.transform.parent == weaponGet.transform && collision.gameObject.tag == "Player")
        {

            inGun = false;

        }


    }

}
