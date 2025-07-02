using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

public class BallMotor : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    public float speed = 5f;
    private Vector2 velocity;
    private AudioSource audioSource;
    private Collider2D ballCollider2D;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ballCollider2D = GetComponent<Collider2D>();
        velocity = new Vector2(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f,1f));
        velocity.Normalize();
        velocity *= speed;
    }

    // Update is called once per frame
    void Update()
    {
        Bounce();
        transform.position += (transform.up * velocity.y + transform.right * velocity.x) * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        BallMotor otherBallMotor = collision.GetComponent<BallMotor>();
        if(otherBallMotor != null) {otherBallMotor.Reflect();}
    }

    // bounce checks!
    private void Bounce() {
        Vector2 positionOnScreen = cam.WorldToScreenPoint(transform.position);
        if((positionOnScreen.x <= 0 && velocity.x < 0) || (positionOnScreen.x >= cam.pixelWidth && velocity.x > 0)) // x bounce
        {
            velocity.x *= -1;
            audioSource.Play();
        } 
        if((positionOnScreen.y <= 0 && velocity.y < 0) || (positionOnScreen.y >= cam.pixelHeight && velocity.y > 0)) // y bounce
        {
            velocity.y *= -1;
            audioSource.Play();
        } 
    }

    public void Reflect() { // reflect velocity on trigger enter
        audioSource.Play();
        velocity *= -1;
    }
}
