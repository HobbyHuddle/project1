using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using World;

namespace Characters
{
    [Serializable]
    public class PlayerDeathEvent : UnityEvent {}

    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterController2D : MonoBehaviour
    {
        public float speed;
        public float jumpHeight;
        [Tooltip("Amount of time jumping in the air")] public float airTimeLimit = 0.3f;
        public int gravity = 8;
        [Tooltip("Smooths player movement transitions."), Range(0, 0.2f)]
        public float smoothDampening;
        public GroundCheck groundCheck;

        public static readonly int Idle = Animator.StringToHash("idle");
        public static readonly int Running = Animator.StringToHash("running");
        public static readonly int Jumping = Animator.StringToHash("jumping");
        public static readonly int Falling = Animator.StringToHash("falling");
        public static readonly int Dead = Animator.StringToHash("dead");

        private float airTime;
        private Vector2 motion;
        private Vector2 velocity;
        private Rigidbody2D rigidbody2d;
        private Animator animator;
        private Vector3 currentScale;

        private bool jumping;
        private bool grounded;
        private bool facingLeft;
        private bool dead;
        
        private float jumpVelocity => Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rigidbody2d.gravityScale));

        private bool IsReadyToJump => grounded && jumping;
        public bool IsIdle => motion.x == 0 & motion.y == 0;
        public bool IsRunning => Mathf.Abs(motion.x) > 0 | Mathf.Abs(motion.y) > 0;
        public bool IsJumping => jumping;
        public bool IsFalling => !dead && !jumping && !grounded;
        public bool IsFacingLeft => facingLeft;
        public bool IsDead => dead;

        public PlayerDeathEvent onDeath;
        
        void Start()
        {
            animator = GetComponent<Animator>();
            rigidbody2d = GetComponent<Rigidbody2D>();
            rigidbody2d.gravityScale = gravity;
            currentScale = rigidbody2d.transform.localScale;

            var spawner = FindObjectOfType<Spawner>();
            onDeath.AddListener(spawner.Spawn);
        }

        private void Update()
        {
            if (IsDead)
            {
                motion = Vector2.zero;
                SetAnimationState();
                StartCoroutine(RemoveCorpse());
                return;
            }
            
            motion = new Vector2
            {
                x = Input.GetAxis("Horizontal"),
                y = Input.GetAxis("Vertical")
            };
            if (motion.x > 0) facingLeft = false;
            if (motion.x < 0) facingLeft = true;

            grounded = groundCheck.IsTouching();

            if (Input.GetButtonDown("Jump") && grounded)
            {
                jumping = true;
                airTime = 0;
            }
            if (jumping)
            {
                airTime += Time.deltaTime;
            }
        
            // FIXME: performance of the air limit isn't limiting air time correctly.
            if (Input.GetButtonUp("Jump") | airTime > airTimeLimit)
            {
                jumping = false;
            }
            
            SetAnimationState();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Move();
            ChangeFaceDirection();
        }
        
        public void ChangeFaceDirection() 
        { 
            if ((!IsFacingLeft && currentScale.x < 0) || (IsFacingLeft && currentScale.x > 0))
            {
                currentScale.x *= -1;
            }
            transform.localScale = currentScale;
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
            grounded = false;
            rigidbody2d.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
        }

        public void Die()
        {
            Debug.Log("Player has died.");
            dead = true;
        }

        IEnumerator RemoveCorpse()
        {
            yield return new WaitForSeconds(2);
            onDeath.Invoke();
            Destroy(gameObject);
        }

        private void SetAnimationState()
        {
            animator.SetBool(Idle, IsIdle);
            animator.SetBool(Running, IsRunning);
            animator.SetBool(Jumping, IsJumping);
            animator.SetBool(Falling, IsFalling);
            animator.SetBool(Dead, IsDead);
        }
    }
}
