using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedMove = 3.0f;
    public float jumpPower = 8.0f;
    public KeyCode jumpButton = KeyCode.Space; // ������� ��� ������

    private float gravityForce;
    private Vector3 moveVector;

    public VectorValue pos;
    public CharacterController pl_controller;
    private Animator pl_animator;

    private Rigidbody playerRigidbody; 

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        pl_controller = GetComponent<CharacterController>();
        pl_animator = GetComponent<Animator>();
    }

        private void Start()
    {
        transform.position = pos.initialValue;
    }

    private void Update()
    {
        PlayerMove();
        GamingGravity();
        pos.SetNewPosition(transform.position);
        
    }

    // ������������ ������
    private void PlayerMove()
    {
        // ����������� �� �����������
        if (pl_controller.isGrounded)
        {
            pl_animator.ResetTrigger("Jump");
            pl_animator.SetBool("Falling", false);

            // �������� ����������� ���, ��������� ������� ������ ����, �������������� � ������������ ��������
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            // ���������� ������ � ������������ � �������������� � ������������ ������
            Move(h, v);

            // �������� ���������
            if (h != 0f || v != 0f)
            {
                Rotating(h, v);
            }

            Animating(h, v);
        }
        else
        {
            if (gravityForce < 0f) pl_animator.SetBool("Falling", true);
        }

        moveVector.y = gravityForce; //������ ����������
        pl_controller.Move(moveVector * Time.deltaTime);
    }


    void Move(float h, float v)
    {
        moveVector = new Vector3(h, 0, v);
        moveVector = moveVector.normalized * speedMove * Time.deltaTime;
        playerRigidbody.AddForce(moveVector);
        //moveVector = Camera.main.transform.TransformDirection(moveVector);
        //moveVector = new Vector3(moveVector.x, 0, moveVector.z);

    }

    void Animating(float h, float v)
    {
        bool walking = (h != 0f) || (v != 0f);
        pl_animator.SetBool("Move", walking);
    }

    void Rotating(float h, float v)
    {
       // Vector3 dir = new Vector3(h, 0, v);
        // ������������� ����������� � ����������
        //Quaternion quaDir = Quaternion.LookRotation(dir, Vector3.up);
        // �������� �������������� � ������� �����
       // Quaternion newRotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveVector), Time.deltaTime * 3.0f);
       // playerRigidbody.MoveRotation(newRotation);
    }
 


    // ����� �����
    private void GamingGravity()
    {
        if (!pl_controller.isGrounded) gravityForce -= 20f * Time.deltaTime;
        else gravityForce = -1f;

        // ������ ����� ��������� ��� ������ ����� ������ 
        if (((Input.mouseScrollDelta.y > 0.0f) || (Input.GetKeyDown(jumpButton))) && pl_controller.isGrounded)
        {
            gravityForce = jumpPower;
            pl_animator.SetTrigger("Jump");
        }
    }
}
