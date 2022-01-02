using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float speed;
    public float smoothDampening;
    public float jumpHeight;
    public float airTimeLimit = 0.3f;
    public GroundCheck groundCheck;

    private float airTime;
    private Vector2 motion;
    private Vector2 velocity;
    private Rigidbody2D rigidbody2d;

    private bool isJumping;
    private bool isGrounded;
    private float jumpVelocity => Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rigidbody2d.gravityScale));

    private bool IsReadyToJump => isGrounded && isJumping;
    
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        motion = new Vector2
        {
            x = Input.GetAxis("Horizontal"),
            y = Input.GetAxis("Vertical")
        };

        isGrounded = groundCheck.IsTouching();

        if (isJumping)
        {
            airTime += Time.deltaTime;
        }
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            airTime = 0;
        }

        // FIXME: performance of the air limit isn't limiting air time correctly.
        if (Input.GetButtonUp("Jump") | airTime > airTimeLimit)
        {
            isJumping = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        var targetVelocity = new Vector2(motion.x * speed, rigidbody2d.velocity.y);
        rigidbody2d.velocity = Vector2.SmoothDamp(rigidbody2d.velocity, targetVelocity, ref velocity, smoothDampening);

        if (IsReadyToJump)
        {
            Jump();
        }
    }

    public void Jump()
    {
        isGrounded = false;
        rigidbody2d.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
    }
}
