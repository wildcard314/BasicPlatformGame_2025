using System.Runtime.CompilerServices;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    //these will be used to determine where to spwan objects

    public GameObject lowestYspawn;
    public GameObject highestYspawn;
    //these are our colectables
    public GameObject yellowCollectable;
    public GameObject redCollectable;
    public GameObject greenCollectable;

    //random number to determine whcih to spwan
    private int randomPrefab;
    private GameObject spawnedCollectable;

    //when and how far between to spawn
    private float time;
    public float delay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //add time, see how much has passed sence lat frame
        time += Time.deltaTime;

        if (time >= delay)
        {
            spawnObj();
            //reset time so the delay is correct
            time = 0f;
        }
    }

    private void spawnObj()
    {
        //get rng to spawn which object
        //the max number in Random.Range is exclusive
        randomPrefab = Random.Range(0,3);

        if (randomPrefab == 0)
        {
            spawnedCollectable = Instantiate(redCollectable);
        }
        if (randomPrefab == 1)
        {
            spawnedCollectable = Instantiate (greenCollectable);
        }
        if(randomPrefab == 2)
        {
            spawnedCollectable = Instantiate(yellowCollectable);
        }
        spawnedCollectable.transform.position = new Vector2(lowestYspawn.transform.position.x, Random.Range(lowestYspawn.transform.position.y, highestYspawn.transform.position.y));
    }

}

