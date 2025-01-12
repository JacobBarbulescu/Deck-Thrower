using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //How far apart each heart is
    public float heartSpacing = 38;

    //The heart prefab
    public GameObject heart;

    //Heart sprites
    public Sprite emptyHeartSprite;
    public Sprite heartSprite;

    //Keeps track of all of the hearts
    private GameObject[] hearts;

    // Start is called before the first frame update
    void Start()
    {
        //The health that the player starts with
        int playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().health;

        //Sets the size of the hearts array to the amount of health
        hearts = new GameObject[playerHealth];

        //Creates each heart (1 for every health the player has)
        for (int x = 0; x < playerHealth; x++)
        {
            //Creates a new heart as a child of Health and adds it to the array
            hearts[x] = Instantiate<GameObject>(heart);

            //Sets the parent of heart as the heart container
            hearts[x].transform.SetParent(gameObject.transform, false);

            //Moves the heart the proper amount to the right
            hearts[x].transform.localPosition = new Vector3(heartSpacing*x, 0, 0);
        }
    }

    //Updates the hearts to reflect the new health
    public void lowerHealth (int newHealth)
    {
        //Sets the chosen heart to the empty sprite
        hearts[newHealth].GetComponent<Image>().sprite = emptyHeartSprite;
    }

    public void raiseHealth (int newHealth)
    {
        if (newHealth >= hearts.Length)
        {
            return;
        }
        hearts[newHealth].GetComponent<Image>().sprite = heartSprite;
    }
}
