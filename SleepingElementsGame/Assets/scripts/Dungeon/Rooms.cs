using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour
{

    [SerializeField] private List<GameObject> enemies = new List<GameObject>();
    public bool allDefeated;
    // Start is called before the first frame update

    void Awake()
    {
        allDefeated = false;
        //enemyCount = -1;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = enemies.Count - 1; i >= 0; i--)
        {

            //Debug.Log(enemies[i]);

            /*if (enemyCount == enemies.Length)
            {

                isOpen = true;

            }*/

            if (enemies[i] == null)
            {

                enemies.RemoveAt(i);
                
                //Debug.Log(allDefeated);
                //enemyCount++;
                //Debug.Log(isOpen);

                //Debug.Log(enemyCount);

            }

            if(enemies.Count == 0)
            {

                allDefeated = true;

            }


        }

    }
}
