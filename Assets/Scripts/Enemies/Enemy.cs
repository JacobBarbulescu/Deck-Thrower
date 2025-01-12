using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //The enemy's health
    public int health = 10;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    public void takeDamage (int damage)
    {
        health -= damage;

        //When out of health, die and let the Game Manager know
        if (health <= 0)
        {
            gameManager.updateEnemyCount();

            GameObject.Destroy(gameObject);
        }
    }
}
