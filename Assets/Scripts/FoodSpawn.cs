using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : Selectable
{
    public Food thisFood;
    public Menu menu;

    [System.Serializable]
    public enum SpawnPos{
        SetPosition,
        Hand
    }
    public SpawnPos spawnSpot;
    private Transform foodSpawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        if(spawnSpot == SpawnPos.SetPosition){
            foodSpawnPosition = transform.Find("SpawnPoint");
        }
        else{
            foodSpawnPosition = transform;
        }
    }

    // Update is called once per frame
    public override void DoAction(SelectionManager sm = null){
        GameObject newFood = new GameObject(thisFood.name);
        newFood.AddComponent<FoodItem>();
        newFood.transform.parent = transform;
        newFood.transform.position = foodSpawnPosition.position;
        newFood.GetComponent<FoodItem>().CreateFood(thisFood);
        if(spawnSpot == SpawnPos.Hand){
            newFood.GetComponent<FoodItem>().DoAction(sm);
        }
    }
}
