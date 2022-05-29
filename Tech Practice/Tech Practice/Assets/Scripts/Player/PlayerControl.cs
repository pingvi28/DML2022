using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControl : MonoBehaviour
{
    public float speed = 1.5f; // ����. ��������
    public float acceleration = 100f; // ���������

    public Transform rotate; // ������ �������� (���������)

    public KeyCode jumpButton = KeyCode.Space; // ������� ��� ������
    public float jumpForce = 12; // ���� ������
    public float jumpDistance = 3.2f; // ���������� �� ������ �������, �� �����������
    private float gravityForce;

    public VectorValue pos;

    private Vector3 direction;
    private float h, v;
    private int layerMask;
    private Rigidbody body;
    private float rotationY;
    private float rotationX;
    private Animator pl_animator;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
        body.freezeRotation = true;
        gameObject.tag = "Player";

        // ������� ������ ���� �������� ��������� ����, ��� ������ ������
        layerMask = 1 << gameObject.layer | 1 << 2;
        layerMask = ~layerMask;

        pl_animator = GetComponent<Animator>();
    }

    private void Start()
    {
        transform.position = pos.initialValue;
    }
    void FixedUpdate()
    {
        body.AddForce(direction.normalized * acceleration * body.mass * speed);

        // ����������� ��������, ����� ������ ����� ��������� ����������
        if (Mathf.Abs(body.velocity.x) > speed)
        {
            body.velocity = new Vector3(Mathf.Sign(body.velocity.x) * speed, body.velocity.y, body.velocity.z);
        }
        if (Mathf.Abs(body.velocity.z) > speed)
        {
            body.velocity = new Vector3(body.velocity.x, body.velocity.y, Mathf.Sign(body.velocity.z) * speed);
        }
    }

    void Update()
    {
        PlayerMove();
        GamingGravity();
        //pos.SetNewPosition(transform.position);
    }

    bool GetJump() // ���������, ���� �� ��������� ��� ������
    {
        bool result = false;

        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out hit, jumpDistance, layerMask))
        {
            result = true;
        }

        return result;
    }

    private void PlayerMove()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        // ������ ����������� ��������
        direction = new Vector3(h, 0, v);
        direction = Camera.main.transform.TransformDirection(direction);
        direction = new Vector3(direction.x, 0, direction.z);


        if (Mathf.Abs(v) > 0 || Mathf.Abs(h) > 0) // �������� ���� �� ������� ��������
        {
            rotate.rotation = Quaternion.Lerp(rotate.rotation, Quaternion.LookRotation(direction), 10 * Time.deltaTime);
        }

        Debug.DrawRay(transform.position, Vector3.down * jumpDistance, Color.red); // ���������, ��� ���������� ��������� jumpDistance
        if (GetJump())
        {
            //pl_animator.ResetTrigger("Jump");
            //pl_animator.SetBool("Falling", false);
            Animating(h, v);
        }
        else
        {
            Animating(h, v);
            //if (gravityForce < 0f) pl_animator.SetBool("Falling", true);
        }
    }

    void Animating(float h, float v)
    {
        bool walking = (h != 0f) || (v != 0f);
        pl_animator.SetBool("Move", walking);
    }

    // ����� �����
    private void GamingGravity()
    {
        if (GetJump()) gravityForce -= 20f * Time.deltaTime;
        else gravityForce = -1f;

        // ������ ����� ��������� ��� ������ ����� ������ 
        if (((Input.mouseScrollDelta.y > 0.0f) || (Input.GetKeyDown(jumpButton))))
        {
            body.velocity = new Vector2(0, jumpForce);
            // gravityForce = jumpForce;
            //pl_animator.SetTrigger("Jump");
        }
    }
}