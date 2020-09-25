using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : Selectable
{
    public Food thisFood;
    public Menu menu;

    [System.Serializable]
    public enum FoodSpawn{
        SetPosition,
        Hand
    }
    public FoodSpawn spawnSpot;
    private Transform foodSpawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        if(spawnSpot == FoodSpawn.SetPosition){
            foodSpawnPosition = transform.Find("SpawnPoint");
        }
        else{
            //get player hand
        }
    }

    // Update is called once per frame
    public override void DoAction(){
        GameObject newFood = Instantiate(new GameObject(thisFood.name));
        newFood.AddComponent<FoodItem>();
        newFood.transform.parent = transform;
        newFood.transform.position = foodSpawnPosition.position;
        newFood.GetComponent<FoodItem>().CreateFood(thisFood);
    }
}
