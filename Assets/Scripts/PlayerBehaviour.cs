using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Physics")]
    public float jumpForce;
    public Rigidbody rb;
    private float axis;
    private float speed;
    public float speedWalk;
    public float speedRun;
    private bool jump;
    private bool doubleJump;
    [Header("Graphics")]
    public bool facingRight;
    public Transform PLAYER_ROBOT;
    [Header("GroundChecker")]
    public Transform groundChecker;
    public Vector3 halfSize;
    public LayerMask groundMask;



    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        facingRight = true;
        speed = speedWalk;
    }

    // Update is called once per frame
    void Update()
    {
        axis = Input.GetAxis("Horizontal") * speed;


        if (Input.GetKeyDown(KeyCode.LeftShift)) speed = speedRun;
        else if (Input.GetKeyUp(KeyCode.LeftShift)) speed = speedWalk;

        if (axis > 0 && !facingRight) Flip();
        else if (axis < 0 && facingRight) Flip();

        //Animation
        //anim.SetBool("isGrounded", isGrounded);
        //anim.SetFloat("speed", Mathf.Abs(axis));
    }

    void FixedUpdate()
    {




        rb.velocity = new Vector3(axis, rb.velocity.y, 0);
    }

    void Flip()
    {
        Vector3 newScale = PLAYER_ROBOT.localScale;
        newScale.x *= -1;
        PLAYER_ROBOT.localScale = newScale;

        facingRight = !facingRight;
    }

}
