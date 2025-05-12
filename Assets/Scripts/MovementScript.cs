using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] private float force = 20f;
    [SerializeField] private GameObject gun;

    private Vector3 mousePosition;
    private Vector2 direction;
    private Rigidbody2D rb;
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
            Recoil();
        }
    }


    private void Recoil()
    {
        
        rb.linearVelocity = Vector2.zero;
        Debug.Log(direction);
        rb.AddForce(direction * force, ForceMode2D.Impulse);
        
    }

}

