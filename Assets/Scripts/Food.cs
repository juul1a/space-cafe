using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Food")]
public class Food : ScriptableObject
{
    public GameObject itemPrefab;
    public List<Transform> edible;

    void Awake(){
        foreach (Transform child in itemPrefab.transform){
            if (child.tag == "Edible")
                edible.Add(child);
        }
    }
}
