using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 100f;

    void Update()
    {
        float moveDirection = Input.GetAxis("Vertical");
        float turnDirection = -Input.GetAxis("Horizontal");

        Vector3 move = transform.right * moveDirection * moveSpeed * Time.deltaTime;
        transform.position += move;

        transform.Rotate(Vector3.forward, turnDirection * turnSpeed * Time.deltaTime);

    }
}
