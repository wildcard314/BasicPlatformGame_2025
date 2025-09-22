using UnityEngine;
using UnityEngine.Rendering;

public class PlatformController : MonoBehaviour
{
    public float moveSpeed;
    public bool horizontalMovement;
    public bool virticalMovement;

    private bool moveLeft;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        movePlatform();
    }

    private void movePlatform()
    {
        if(moveLeft)
        {
            //this needs to be multiplied by time.Deltatime so that we are moveing the platform based off of time not frame rate
            //we do not need to do this

            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
        else if(!moveLeft)
        {

            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlatformStart"))
        {
            moveLeft = false;
        }

        if (collision.gameObject.CompareTag("PlatformEnd"))
        {
            moveLeft = true;
        }
    }

}
