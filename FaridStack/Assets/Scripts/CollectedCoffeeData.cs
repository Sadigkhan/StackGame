using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedCoffeeData : MonoBehaviour
{
    public static CollectedCoffeeData instance;
    public List<Transform> CoffeeList;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
}
