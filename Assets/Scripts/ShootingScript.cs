using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float speed = 10f;
    [SerializeField] Transform spawn;
    private Vector3 mousePosition;
    private Vector2 direction;

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        UpdateRotation(angle);

        if (Input.GetMouseButtonUp(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, spawn.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * speed;
        Destroy(projectile, 1f);
    }

    private void UpdateRotation(float angle)
    {
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}