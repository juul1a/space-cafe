using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Customer/Decisions/Order")]
public class OrderDecision : Decision
{
    public override bool Decide(Customer controller){
        if(controller.holding != null){
            FoodItem holdingFood = controller.holding.GetComponent<FoodItem>();
            if(holdingFood == null){
                Dish dish = controller.holding.GetComponent<Dish>();
                if(dish != null){
                    holdingFood = dish.food;
                }
            }
            if(holdingFood != null && controller.holdingFood.food == controller.order){
                controller.speechBubble.SetActive(false);
                Destroy(controller.speechBubble.GetComponentInChildren<FoodItem>().gameObject);
                //take item in hand
                controller.order = null;//reset order
                return true;
            }
            else if(holdingFood != null && controller.holdingFood.food != controller.order){
                //say "nope"
                controller.holding = null;
                return false;
            }
        }
        return false;
    }
}
