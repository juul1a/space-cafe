using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Food")]
public class Food : ScriptableObject
{
    public GameObject itemPrefab;
    public bool edible;
    public float eatTime = 15f;
    
}
