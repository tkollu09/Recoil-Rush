using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float force = 20f;

    private Vector3 mousePosition;
    private Vector2 direction;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (transform.position - mousePosition).normalized;

        if (Input.GetMouseButtonUp(0))
        {
            Move();
        }
    }

    private void Move()
    {
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(direction * force, ForceMode2D.Impulse);
        
    }

}

