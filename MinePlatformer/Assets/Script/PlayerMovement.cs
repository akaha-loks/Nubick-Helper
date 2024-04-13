using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 3f;

    [Header("Jump Settings")]
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private int jumpCount = 0;
    [SerializeField] private int maxJumpValue = 2;
    private bool onGround;
    [SerializeField] LayerMask Ground;
    [SerializeField] Transform GroundCheck;

    [Header("Dash Settings")]
    [SerializeField] private TrailRenderer tr;
    [SerializeField] private float dashingPower = 24f;
    private bool canDash = true;
    private bool isDashing;
    [SerializeField]private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown = 1f;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip sound;

    private float movement;
    private bool _lookRight;
    [Header("Player Settings")]
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Animator anim;

    private void Update()
    {
        if (isDashing)
        {
            return;
        }
        Move();
        Jump();
        CheckFlip();
        Dash();
        CheckingGround();
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
    }
    private void Move()
    {
        movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * speed * Time.deltaTime;
        if(movement == 0 )
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
    }
    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (onGround)
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
            else if(++jumpCount < maxJumpValue)
            {
                rb.velocity = new Vector2(0, 10);
            }
        }
        if (onGround) { jumpCount = 0; }
    }
    private void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, 0.3f, Ground);
    }
    
    private void CheckFlip()
    {
        if (movement < 0 && !_lookRight)
        {
            Flip();
        }
        else if (movement > 0 && _lookRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);

        _lookRight = !_lookRight;
    }
    
    private void Dash()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            rb.velocity = new Vector2(0, 0);
            audioSource.PlayOneShot(sound, 1f);
            StartCoroutine(DashCoolDown());
        }
    }
    private IEnumerator DashCoolDown()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        rb.velocity = new Vector2(0, 0);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
