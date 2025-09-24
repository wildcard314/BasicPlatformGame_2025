using JetBrains.Rider.Unity.Editor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Tilemaps;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rb;

    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        playerDirection();
    }

    private void playerDirection()
    {
        if (player.transform.eulerAngles == new Vector3(0, 180, 0))
        {
            moveleft();
        }
        else
        {
            moveRight();
        }
    }

    private void moveleft()
    {
        rb.linearVelocity = new Vector2(speed * -1, 0);
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    private void moveRight()
    {
        rb.linearVelocity = new Vector2(speed, 0);
        transform.eulerAngles = new Vector3(0, 180, 0);
    }
}
