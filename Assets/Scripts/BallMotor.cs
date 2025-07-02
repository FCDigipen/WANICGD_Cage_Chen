using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BallMotor : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    private Vector2 velocity;
    void Start()
    {
        velocity = new Vector2(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f,1f));
        velocity.Normalize();
        velocity *= speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (transform.up * velocity.y + transform.right * velocity.x) * Time.deltaTime;
    }
}
