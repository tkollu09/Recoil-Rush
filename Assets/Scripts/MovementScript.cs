using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] private float force = 20f;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpForce = 16f;
    [SerializeField] private bool canShoot = false;
    [SerializeField] private bool canWalk = false;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private GameObject gun;

    private float horizontal;
    private bool facingRight = true;
    private Vector3 mousePosition;
    private Vector2 direction;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Flip();
        if (canShoot)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (transform.position - mousePosition).normalized;
            if (Input.GetMouseButtonUp(0))
            {
                Recoil();
            }
        }
        if (canWalk)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            if (Input.GetKeyDown("w") && IsGrounded())
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }

            if (Input.GetKeyUp("w") && IsGrounded())
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
            }
        }

    }
    private void FixedUpdate()
    {
        if (canWalk)
        {
            rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
        }
    }

    private void Recoil()
    {
        
        rb.linearVelocity = Vector2.zero;
        Debug.Log(direction);
        rb.AddForce(direction * force, ForceMode2D.Impulse);
        
    }

    private void Flip()
    {
        if (facingRight && horizontal < 0f || !facingRight && horizontal > 0f)
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1f;
            transform.localScale = scale;
        }
    }

    private bool IsGrounded()
    {   
        bool beurh = Physics2D.OverlapCircle(groundCheck.position, 0.2f, 3);
        return beurh;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("WASD"))
        {
            canWalk = true;
            canShoot = false;
            Destroy(collision);;
        }
        if (collision.gameObject.name.Equals("Gun"))
        {
            canWalk = false;
            canShoot = true;
            Destroy(collision);
        }
    }
}

