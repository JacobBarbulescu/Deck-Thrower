using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public int maxCollisions;
    private int numCollisions = 0;

    public void OnCollisionEnter2D(Collision2D other)
    {
        //After enough collisions, the bullet will disappear
        numCollisions++;
        if (numCollisions >= maxCollisions)
        {
            Destroy(gameObject);
        }

        FindObjectOfType<AudioManager>().playSound("Card Bounce");
    }
}
