using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeScript : MonoBehaviour
{
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
            ReloadLevel();
        }
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
