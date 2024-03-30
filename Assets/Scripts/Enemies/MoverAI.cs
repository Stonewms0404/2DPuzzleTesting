using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoverAI : MonoBehaviour
{
    [Header("Mover Objects")]
    [SerializeField]
    [Tooltip("The Visuals for the Mover")]
    GameObject visuals;
    [SerializeField]
    [Tooltip("The Rigidbody to move the Mover")]
    Rigidbody2D rb;
    [SerializeField]
    [Tooltip("The Script that checks if there is a wall in the way")]
    WallChecker wc;
    [SerializeField]
    [Tooltip("The Script that checks if there is floor below")]
    IsFloor fl;
    [SerializeField]
    [Tooltip("The direction the enemy will move")]
    float direction = 1;

    [Space]
    [Header("Mover Attributes")]
    [SerializeField]
    [Tooltip("Enemy Script with applied methods")]
    Enemy enemyScript;

    bool isMoving, wallForTooLong, canJump;
    //float moveTimer, pauseTimer, wallTimer, wallTimerToReach = 2.0f;


    void Start()
    {
        enemyScript = GetComponentInChildren<Enemy>();
        wc = GetComponentInChildren<WallChecker>();
    }

    void FixedUpdate()
    {
        ApplyGravity();
        if (isMoving)
            Move();
        else
            PauseMovement();
    }

    private void Move()
    {
        //if ()
    }

    private void ApplyGravity()
    {
        rb.velocityY -= enemyScript.GetGravity();
    }

    private void ResetTimers()
    {
        //moveTimer = 0.0f;
        //pauseTimer = 0.0f;
    }

    private void PauseMovement()
    {
        rb.velocityX = 0;
       // if (pauseTimer < enemyScript.GetPauseTimer())
       // {
            //pauseTimer += Time.deltaTime;
       //     isMoving = false;
       // }
        //else
        //{
        //    isMoving = true;
        //    ResetTimers();
       // }
    }

    private void Flip()
    {
        direction = -direction;
        this.transform.localScale = new(
            direction * this.transform.localScale.x,
            this.transform.localScale.y);
    }
}
