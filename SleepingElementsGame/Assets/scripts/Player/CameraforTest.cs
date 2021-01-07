using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraforTest : MonoBehaviour
{
    private SpriteRenderer player;
    private Vector3 targetPosition;
    public float targetOffset = 0f;
    public float cameraSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (player.flipX)
        {

            targetPosition = new Vector3(player.transform.position.x - targetOffset, player.transform.position.y - targetOffset, transform.position.z);

        }
        else
        {

            targetPosition = new Vector3(player.transform.position.x + targetOffset, player.transform.position.y + targetOffset, transform.position.z);

        }

        Vector3 clampPos = new Vector3(Mathf.Clamp(targetPosition.x, -100, 300), Mathf.Clamp(targetPosition.y, -50, 30), transform.position.z);

        transform.position = Vector3.Lerp(transform.position, clampPos, cameraSpeed * Time.deltaTime);


    }



}