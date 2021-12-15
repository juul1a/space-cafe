using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : Selectable
{

    public FoodItem food;

    public void Nest(GameObject incomingFood){
        Debug.Log("nestinf "+incomingFood.name);
        if(food == null){
            incomingFood.transform.parent = transform;
            FoodItem foodItem = incomingFood.GetComponent<FoodItem>();
            Debug.Log("food on dish is "+foodItem.food);
            food = foodItem;
        }
    }

    public void DeNest(GameObject incomingFood){
        incomingFood.transform.parent = null;
        food = null;
    }

    public override void DoAction(SelectionManager sm = null){
        if(sm != null && sm.holding == null){
            if(transform.parent != null){
                sm.Grab(transform.parent.gameObject);
            }
            else{
                sm.Grab(transform.gameObject);
            }
            
        }
    }
}
