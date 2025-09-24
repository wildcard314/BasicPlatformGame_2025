using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControlller : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    private float inputHorizontal;
    private float inputVertical;
    private int maxJumps;
    private int jumps;
    Rigidbody2D rb;

    public GameObject doubleJumpHatLoctaion;
    public GameObject gunLocation;

    public GunController gunController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        maxJumps = 1;
        jumps = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement();
        jump();
    }
       

    public void flipPlayerSprite(float inputHorizontal)
    {
        //this is how we will make the player face the direction they are moveing

        if(inputHorizontal > 0)
        {
            transform.eulerAngles = new Vector3 (0, 0, 0);
        }
        else if (inputHorizontal < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }


    }

    public void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && jumps <= maxJumps)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpforce);
            jumps++;
        }
    }

    public void horizontalMovement()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(speed * inputHorizontal, rb.linearVelocity.y);
        flipPlayerSprite(inputHorizontal);

    }


    //collions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision will contain information about the object that the plater collided with
        //Debug.Log(collision.gameObject);
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumps = 1;
        }
        else if (collision.gameObject.CompareTag("oob")) 
        {
            SceneManager.LoadScene("SampleScene");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //double jump
        if(collision.gameObject.CompareTag("DoubleJump"))
        {
            GameObject hat = collision.gameObject;
            equipDoubleJumpHat(hat);
            maxJumps = 2;
           
        }
        // gun
        if(collision.gameObject.CompareTag("Gun"))
        {   
            GameObject gun = collision.gameObject;
            equipGun(gun);
        }

    }

    private void equipDoubleJumpHat(GameObject hat)
    {
        hat.transform.position = doubleJumpHatLoctaion.transform.position;
        hat.gameObject.transform.SetParent(gameObject.transform);
    }

    private void equipGun(GameObject gun)
    {
        gun.transform.position = gunLocation.transform.position;
        gun.gameObject.transform.SetParent(gameObject.transform);
    }

}
