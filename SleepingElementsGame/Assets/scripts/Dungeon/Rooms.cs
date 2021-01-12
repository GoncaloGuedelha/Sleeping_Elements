using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour
{

    [SerializeField] private List<GameObject> enemies = new List<GameObject>();
    public bool allDefeated;

    void Awake()
    {

        allDefeated = false;

    }

    void Start()
    {
        
    }

    void Update()
    {

        for (int i = enemies.Count - 1; i >= 0; i--)
        {

            if (enemies[i] == null)
            {

                enemies.RemoveAt(i);

            }

            if(enemies.Count == 0)
            {

                allDefeated = true;

            }


        }

    }
}
