using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleController : MonoBehaviour
{
    [SerializeField] float speed;
    void Update()
    {
        Vector3 direction = Vector3.zero;
        if(Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;

        }

        if (Input.GetKey(KeyCode.Q))
        {
            direction += Vector3.up;

        }
        else if (Input.GetKey(KeyCode.E))
        {
            direction += Vector3.down;

        }

        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }

        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}
