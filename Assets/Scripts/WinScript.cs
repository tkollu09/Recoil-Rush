using UnityEngine;

public class WinScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] CameraScript cam;
    private float speed = 0f;
    Vector2 pos;

    private void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            winLevel();
        }
    }

    private void winLevel()
    {
        Debug.Log("player won");
        player.transform.SetParent(transform);
        cam.followP = false; 
        speed = 0.5f;
        PlayerPrefs.SetInt("playerLevel", 1);
    }

    private void FixedUpdate()
    {
        pos = transform.position;
        pos = new Vector2 (pos.x + speed, pos.y);
        transform.position = pos;
    }
}
