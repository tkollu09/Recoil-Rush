using UnityEngine;

public class LifeScript : MonoBehaviour
{
    [SerializeField] private GameObject[] hearts;
    private Transform pos;
    private Rigidbody2D rb;

    private void Start()
    {
        pos = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (pos.position.y < -15)
        {
            ResetPlayerPosition();
        }
    }


    private void ResetPlayerPosition()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
}
