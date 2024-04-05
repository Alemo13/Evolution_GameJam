using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float smoothTime = 0.1f;
    private float smoothVelocity;
    float horizontalInput;
    float verticalInput;
    public float speedMultiplier = 1f;

    [Header("Jump Movement")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool canJump = true;
    public float jumpMultiplier = 1f;
    private bool isJumping;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;
    public float groundDrag;

    [Header("References")]
    Rigidbody rb;
    public Transform cam;
    Animator anim;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.01f, groundLayer);
        Inputs();
        SpeedController();

        if (isGrounded)
        {
            rb.drag = groundDrag;
            
        }
        else
            rb.drag = 0;
    }
    private void FixedUpdate()
    {
        MovePlayer();
        anim.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("yVelocity", rb.velocity.y);
    }
    private void Inputs()
    {
        //Movement
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical"); 
        //Jump
        if (Input.GetKey(jumpKey) && isGrounded && canJump)
        {
            anim.SetBool("IsJumping", true);
            canJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // In Ground
            if (isGrounded)
            {
                rb.AddForce(moveDir.normalized * moveSpeed * speedMultiplier * 10f, ForceMode.Force);             
            }
            // In Air
            else if (!isGrounded)
            {
                rb.AddForce(moveDir.normalized * moveSpeed * speedMultiplier * 10f * airMultiplier, ForceMode.Force);
            }
        }   
    }

    private void SpeedController()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
    private void Jump()
    {
        AudioManager.Instance.Play("SFX_Jump");
        // Reset Y Velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce * jumpMultiplier, ForceMode.Impulse);

    }

    private void ResetJump()
    {
        canJump = true;
        if (rb.velocity.y <= 0f && isGrounded)
        {
            anim.SetBool("IsJumping", false);
        }
    }

    public void SetSpeedMultiplier (float newSpeedMultiplier)
    {
        speedMultiplier = newSpeedMultiplier;
    }
    public void SetJumpMultiplier(float newJumpMultiplier)
    {
        jumpMultiplier = newJumpMultiplier;
    }
}
