using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float speed = 10f;
    [SerializeField] Transform spawn;
    [SerializeField] MovementScript movementScript;
    private Vector3 mousePosition;
    private Vector2 direction;

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        UpdateRotation(angle);

        if (Input.GetMouseButtonUp(0) && AmmoScript.getAmmo() > 0)
        {
            Shoot(angle);
        }
    }

    private void Shoot(float angle)
    {
        movementScript.Recoil();
        GameObject projectile = Instantiate(projectilePrefab, spawn.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        Transform tf = rb.transform;
        rb.linearVelocity = direction * speed;
        tf.eulerAngles = new Vector3 (0, 0, angle);
        Destroy(projectile, 1f);
        AmmoScript.Shoot();
    }

    private void UpdateRotation(float angle)
    {
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}