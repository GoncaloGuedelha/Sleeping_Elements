using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] door = new GameObject[1];
    [SerializeField] private GameObject room;
    [SerializeField] private GameObject bossHealth;
    private bool checkEnemies;

    // Start is called before the first frame update

    void Awake()
    {

        checkEnemies = false;

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        checkEnemies = room.GetComponent<Rooms>().allDefeated;

        if (checkEnemies == true)
        {

            bossHealth.SetActive(true);

            for (int i = 0; i < door.Length; i++)
            {

                door[i].SetActive(false);

            }


        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            room.SetActive(true);
            GameObject.FindWithTag("Boss").GetComponent<Boss>().triggered = true;
            bossHealth.SetActive(true);

            if (checkEnemies == false)
            {

                for (int i = 0; i < door.Length; i++)
                {

                    door[i].SetActive(true);

                }

            }

            

        }    

    }
}
