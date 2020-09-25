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
        FoodItem foodItem = controller.speechBubble.GetComponentInChildren<FoodItem>();
        foodItem.CreateFood(controller.order);
        
        controller.speechBubble.SetActive(true);
    }

    
}
