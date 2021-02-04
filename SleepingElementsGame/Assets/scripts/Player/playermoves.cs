using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playermoves : MonoBehaviour
{

    private Rigidbody2D rb;
    private float feetOffset = 0;
    private float sideOffset = 0;
    private int platformLayer = 0;
    public float moveforce = 6f;
    public float jumpforce = 7f;
    public float pHealth = 3f;
    public float jLimit = 6;
    public bool shield = false;
    private Vector3 scaleChange;

    private GameObject spikes;
    private GameObject healthBar;

    //private SpriteRenderer spriteRenderer;

    public bool dodge = false;
    public float dodgeTimer = 0f;
    public float dodgeSpeed = 5f;


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        CapsuleCollider2D collider = GetComponent<CapsuleCollider2D>();
        feetOffset = ((collider.size.y * transform.localScale.y) / 2) + 0.01f;
        sideOffset = ((collider.size.x * transform.localScale.x) / 2);

        platformLayer = LayerMask.GetMask("Platform");
        spikes = GameObject.FindGameObjectWithTag("Hazards");
        healthBar = GameObject.FindGameObjectWithTag("Playerhealth");
        scaleChange = new Vector3(-35f, -0, -0);

    }

    private bool IsOnGround()
    {

        Vector2 playerFeet = new Vector2(transform.position.x + sideOffset, transform.position.y - feetOffset);
        Vector2 playerFeet2 = new Vector2(transform.position.x - sideOffset, transform.position.y - feetOffset);
        RaycastHit2D hit = Physics2D.Raycast(playerFeet, Vector2.down, 1.5f, platformLayer);
        if (hit.collider != null)
        {
            float dist = Mathf.Abs(hit.point.y - playerFeet.y);
            if (dist < 0.1f)
            {

                return true;

            }

        }

        RaycastHit2D hit2 = Physics2D.Raycast(playerFeet2, Vector2.down, 2f, platformLayer);
        if (hit2.collider != null)
        {
            float dist = Mathf.Abs(hit2.point.y - playerFeet2.y);
            if (dist < 0.1f)
            {

                return true;

            }

        }

        return false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float jump = Input.GetAxis("Jump");

        if (jump > 0 && (IsOnGround()))
        {

            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);

            if(rb.velocity.y > jLimit)
            {

                rb.velocity = new Vector2(rb.velocity.x, jLimit);

            }

        }
        else if (rb.velocity.y < 0 && !IsOnGround())
        {

            rb.AddForce(Vector2.down / jumpforce, ForceMode2D.Impulse);

        }



        rb.velocity = new Vector2(horizontal * moveforce, rb.velocity.y);

        if(pHealth <= 0)
        {

            SceneManager.LoadScene(sceneBuildIndex: 2);

        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
      

        if (collision.gameObject.tag == "Hazards" || collision.gameObject.tag == "Enemy")
        {
            if(GameObject.Find("Shield Image") != null)
            {

            GameObject.Find("Shield Image").GetComponent<ShieldEffect>().run = true;

            }

            if(shield == true)
            {


            }
            else 
            {
                
            pHealth = pHealth - 0.5f;
            healthBar.transform.localScale += scaleChange;
            
            }
           

        }

    }

}
