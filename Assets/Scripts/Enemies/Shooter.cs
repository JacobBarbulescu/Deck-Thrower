using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    //Number of seconds between shots
    public float shootTime = 1f;
    private float timer;

    public float bulletForce = 15f;

    private GameObject player;

    public GameObject bullet;

    private Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        transform = gameObject.GetComponent<Transform>();

        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= shootTime )
        {
            shoot();
            timer = 0;
        }
    }

    public void shoot ()
    {
        //Finds the difference between card's coords and player's coords
        Vector2 difference = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        //Then, converts it into a direction that the bullet will follow
        difference = difference.normalized;

        GameObject newBullet = Instantiate(bullet, transform);
        newBullet.GetComponent<Rigidbody2D>().AddForce(difference * bulletForce);
    }
}
