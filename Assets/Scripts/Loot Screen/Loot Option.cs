using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LootOption : MonoBehaviour
{
    private GameManager gameManager;

    private int typeIndex;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    public void setTypeIndex (int index)
    {
        typeIndex = index;
    }

    public int getTypeIndex ()
    {
        return typeIndex;
    }
}
