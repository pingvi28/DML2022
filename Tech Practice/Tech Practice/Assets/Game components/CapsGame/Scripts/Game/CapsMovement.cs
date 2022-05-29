using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsMovement : MonoBehaviour
{
    public float speedMove = 5.0f; //скорость перса
    public float jumpPower = 8.0f; // сила прыжка
    public float distance = 1f;   // отвечает за то, в какой кубик мы перейдем 

    private float gravityForce, dirZ; // гравитация перса
    private bool NeedToGo = true;
    private Vector3 moveVector; // направление движения

    public CharacterController pl_controller;
    public Rigidbody rb;

    private void Start()
    {
        pl_controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
       PlayerMove();
       GamingGravity();
    }

    private void FixedUpdate() {
        // начал падать
        if (rb.position.y < -2f)
        {
            FindObjectOfType<GameManager>().AnimEndGame();
        }
        // завершаем игру
        if (rb.position.y < -4f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    public void Move()   // метод: нужно ли двигаться
    {
        if (!NeedToGo)   // если мы не перемещаемся в данный момент
        {
            NeedToGo = true;   
        }
    }

    private void PlayerMove()
    {
        Move();

        if (NeedToGo)
        {
            if (Input.GetMouseButtonDown(0))   // двигаемся влево
            {
                dirZ = speedMove;
            }
            else if (Input.GetMouseButtonDown(1))   // двигаемся вправо
            {
                dirZ = - speedMove;
            }

            NeedToGo = false;
        }

        moveVector.x =  distance;
        moveVector.z = dirZ * 0.5f;
        moveVector.y = gravityForce; //расчет гравитации (прыжок)
        pl_controller.Move(moveVector * Time.deltaTime);
    }

    // чтобы падал
    private void GamingGravity()
    {
        if (!pl_controller.isGrounded) gravityForce -= 20f * Time.deltaTime;
        else gravityForce = -1f;

        // прыжок через прокрутку
        if (Input.mouseScrollDelta.y > 0.0f && pl_controller.isGrounded)
        {
            gravityForce = jumpPower;
        }
    }
}