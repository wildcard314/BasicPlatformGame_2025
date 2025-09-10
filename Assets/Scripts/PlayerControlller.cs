using UnityEngine;

public class PlayerControlller : MonoBehaviour
{
    public float speed;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello From player Controller :3");

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("loop de loop");
    }


    private void horizontalMovement()
    {


    }
    // this is a test, if it works yippiee :3
    //dont judge me TODD
}
