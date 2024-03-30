using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Objects")]
    [SerializeField]
    [Tooltip("The object for player visuals")]
    GameObject playerVisuals;
    [SerializeField]
    [Tooltip("The Rigidbody to control the character")]
    Rigidbody2D rb;
    [SerializeField]
    [Tooltip("The FloorChecker Object")]
    IsFloor fc;
    [SerializeField]
    AudioSource jumpSound, landSound;

    [Space]
    [Header("Player Stats")]
    [SerializeField]
    [Tooltip("Player Specific attributes as readonly")]
    PlayerScriptableObject playerSO;

    float direction, jump, xScale, threshold = 0.3f;
    private bool isJumping;
    private bool hasLanded;

    private void Start()
    {
        xScale = transform.localScale.x;
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void OnHorizontal(InputValue value)
    {
        direction = value.Get<float>();
    }

    private void OnJump(InputValue value)
    {
        jump = value.Get<float>();
    }

    private void Move()
    {
        if (direction < -0.1f)
            rb.velocityX = direction * playerSO.Speed;
        else if (direction > 0.1f)
            rb.velocityX = direction * playerSO.Speed;
        else
        {
            if (rb.velocityX < -threshold)
                rb.velocityX += playerSO.Friction;
            else if (rb.velocityX > threshold)
                rb.velocityX -= playerSO.Friction;
            else
                rb.velocityX = 0;
        }


        if (rb.velocityX > 0)
            transform.localScale = new(xScale, transform.localScale.y);
        else if (rb.velocityX < 0)
            transform.localScale = new(-xScale, transform.localScale.y);
    }

    private void Jump()
    {
        if (jump != 0 && fc._grounded && !isJumping)
        {
            rb.velocityY += playerSO.JumpForce;
            if (jumpSound) jumpSound.Play();
            isJumping = true;
        }

        if (jump == 0)
            isJumping = false;

        if (!fc._grounded) hasLanded = false;

        if (fc._grounded && !hasLanded)
        {
            hasLanded = true;
            if (landSound) landSound.Play();
        }
    }
}
