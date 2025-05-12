using UnityEngine;

public class AmmoScript : MonoBehaviour
{
    [SerializeField] private static int ammo = 0;

    public int Ammo { get { return ammo; } }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Equals(collision.gameObject.name, "Ammo"))
        {
            Destroy(collision.gameObject);
            ammo++;
        }
    }  
    private void Update()
    {
        Debug.Log(ammo);
    }
}
