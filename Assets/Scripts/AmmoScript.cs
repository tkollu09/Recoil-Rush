using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AmmoScript : MonoBehaviour
{
    [SerializeField] int inAmmo = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    private static int ammo;
    private void Start()
    {
        ammo = inAmmo;
        scoreText.text = ammo.ToString();
    }
    public int Ammo { get { return ammo; } }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Equals(collision.gameObject.name, "Ammo"))
        {
            Destroy(collision.gameObject);
            ammo++;
        }
    }  

    public static void Shoot()
    {
        ammo--;
    }

    private void Update()
    {
        scoreText.text = ammo.ToString();
    }

    public static int getAmmo()
    {
        return ammo;
    }

    public void resetAmmo()
    {
        ammo = inAmmo;
    }
}
