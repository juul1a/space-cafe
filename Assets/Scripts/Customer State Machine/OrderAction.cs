using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Customer/Actions/Order")]
public class OrderAction : Action
{   
    public override void Act(Customer controller)
    { 
        if(controller.order == null){
            Order (controller);
        }
    }

    private void Order(Customer controller)
    {
        Menu menu = GameObject.Find("Menu").GetComponent<Menu>();;
        int index = Random.Range(0, menu.items.Count);
        controller.order = menu.items[index];

        GameObject foodItem = Instantiate(new GameObject("Order"));
        Transform spawnPoint = controller.speechBubble.transform.Find("SpawnPoint");
        foodItem.transform.parent = spawnPoint;
        foodItem.transform.position = spawnPoint.position;
        FoodItem food = foodItem.AddComponent<FoodItem>();
        food.spawnCenter = true;
        food.CreateFood(controller.order);
        
        controller.speechBubble.SetActive(true);
    }

    
}
