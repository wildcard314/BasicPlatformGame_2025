using UnityEngine;
using UnityEngine.UIElements;

public class GunController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletSpawnLocation;

    public bool hasGun = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shootGun();
    }

    private void shootGun()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet);
            bullet.transform.position = new Vector2(bulletSpawnLocation.transform.position.x, bulletSpawnLocation.transform.position.y);
        }
    }

}
