using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<AudioManager>().playSound("Light Bounce");
    }
}
