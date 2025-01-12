using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LootScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Sets container of the cards to inactive so they don't show
        //gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void activate(GameObject[] cardTypes) {
        //Sets cardHolder to the empty object holding each loot card
        GameObject cardHolder = gameObject.transform.GetChild(0).gameObject;

        //Creates an arraylist of each card type's index in the main array. This is so we can prevent showing the same type twice.
        ArrayList indexes = new ArrayList();
        indexes.AddRange(Enumerable.Range(0, cardTypes.Length).ToArray());

        //Sets container of the cards to active so they display
        cardHolder.SetActive(true);

        //Goes through each card and randomly assigns it a card type
        for (int x = 0; x < 3; x++) {
            GameObject card = cardHolder.transform.GetChild(x).gameObject;

            //The index of the array list we want to access
            int indexIndex = Random.Range(0, indexes.Count);
            //Put the stores index as our cardType index
            int index = (int)indexes[indexIndex];
            //Remove that cardType index so we don't draw it again
            indexes.RemoveAt(indexIndex);

            //Set the loot card's sprite to the card type's
            card.GetComponent<UnityEngine.UI.Image>().sprite = cardTypes[index].GetComponent<SpriteRenderer>().sprite;
            //Store the value of the card type's index in the array so we can access it later after clicking on the loot card
            card.GetComponent<LootOption>().setTypeIndex(index);
        }
    }
}
