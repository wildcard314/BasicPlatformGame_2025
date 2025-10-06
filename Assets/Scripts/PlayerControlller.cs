using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

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

    private GunController gunControllerScript;

    public GameObject scoreManager;
    private ScoreManagerGui scoreManagerScript;

    private int playerScore;
    private int HighScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        scoreManagerScript = scoreManager.GetComponent<ScoreManagerGui>();
        gunControllerScript = GetComponent<GunController>();

        maxJumps = 1;
        jumps = 1;

        playerScore = 0;
        HighScore = 0;
        
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
        if(collision.gameObject.CompareTag("Collectable"))
        {
            GameObject collectable = collision.gameObject;
            CollectableData cdScript = collectable.GetComponent<CollectableData>();
            int valueOfCollectable = cdScript.getValue();
            changePlayerScore(valueOfCollectable);
            cdScript.destroyCollectable();
            scoreManagerScript.setGUIcurScore();

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

    public int getPlayerScore()
    {
        return playerScore;
    }
    public void setPlayerScore(int score)
    {
        playerScore = score;
    }
    public void changePlayerScore(int value)
    {
        playerScore += value;
        Debug.Log("SCORE: " +  playerScore);
    }

    public void setPlayerHighSCore(int s)
    {
        HighScore = s;
    }

    public int getPlayerHighSCore()
    {
        return HighScore;
    }

}
