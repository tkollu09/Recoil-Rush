using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform truck;
    [SerializeField] CameraScript cam;
    [SerializeField] int levelNum;
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
        player.transform.SetParent(truck);
        cam.followP = false; 
        speed = 2f;
        PlayerPrefs.SetInt("playerLevel", levelNum+1);
        StartCoroutine(nextLevel());
    }

    IEnumerator nextLevel()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(levelNum + 1);
    }


    private void FixedUpdate()
    {
        pos = truck.position;
        pos = new Vector2 (pos.x + speed, pos.y);
        truck.position = pos;
    }
}
