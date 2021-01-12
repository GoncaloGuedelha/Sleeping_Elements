using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{

    public Transform target;
    private float maxScreenPoint = 0.3f;
    private Vector3 velocity = Vector3.zero;
    private float dampTime = 0.3f;

    void FixedUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        Vector3 mousePos = Input.mousePosition * maxScreenPoint + new Vector3(Screen.width, Screen.height, 0f) * ((1f - maxScreenPoint) * 0.5f);

        Vector3 position = (target.position + GetComponent<Camera>().ScreenToWorldPoint(mousePos)) / 2f;

        Vector3 destination = new Vector3(position.x, position.y, -10);

        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);

        Cursor.lockState = CursorLockMode.Confined;

    }
}



