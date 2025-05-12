using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Transform camPos;
    private Vector3 pos;
    private bool followP = true;
    private void Start()
    {
        camPos = GetComponent<Transform>();
    }
    private void Update()
    {
        if (followP)
        {   
            pos = new Vector3(player.transform.position.x, player.transform.position.y, -10);
            camPos.position = pos;
        }
    }
}
