using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (pos.position.y < -15 || Input.GetKeyDown(KeyCode.R))
        {
            //ResetPlayerPosition();
            ReloadLevel();
        }
    }


    private void ResetPlayerPosition()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = new Vector2(-3, 0);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
