using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedCoffeeData : MonoBehaviour
{
    public static CollectedCoffeeData instance;
    public List<Transform> CoffeeList;
    public int finalCount = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (finalCount == 8)
        {
            finalCount = 0;
        }
    }
}
