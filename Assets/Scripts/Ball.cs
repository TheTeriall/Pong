using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 movementDirection;
    private Rigidbody2D rb;
    public event EventHandler OnPlayerGoalEntered;
    public event EventHandler OnAIGoalEntered;
    private AudioSource audioSource;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        // Create random Movement in one of the four directions
        movementDirection = GetRandomVector();
        rb.velocity = movementDirection * speed;
    }

    Vector2 GetRandomVector()
    {
        Vector2[] possibleVectors = new Vector2[]
        {
            new Vector2(1, 1),
            new Vector2(1, -1),
            new Vector2(-1, 1),
            new Vector2(-1, -1)
        };

        int randomIndex = UnityEngine.Random.Range(0, possibleVectors.Length);

        return possibleVectors[randomIndex];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerGoal"))
        {
            OnPlayerGoalEntered?.Invoke(this, EventArgs.Empty);
        } else if (collision.gameObject.CompareTag("AIGoal"))
        {
            OnAIGoalEntered?.Invoke(this, EventArgs.Empty);
        }}
    }



