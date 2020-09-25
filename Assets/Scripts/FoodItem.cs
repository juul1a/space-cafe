using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : Selectable
{
    public Food food;
    public bool selectable = true;
    
    public void Awake(){
        if(selectable){
            SetSelectable(transform);
        }
    }
    public GameObject CreateFood(Food createFood = null, bool select = true){
        if(createFood != null){
            food = createFood;
        }
        if(food != null){
            GameObject foodObject = Instantiate(food.itemPrefab);
            foodObject.transform.parent = transform;
            foodObject.transform.position = transform.position;
            if(select){
                selectable = true;
                SetSelectable(transform);
                SetMaterials();
            }
            else{
                selectable = false;
            }
            return foodObject;
        }
        return null;
    }

    public void FoodEaten(){
        if(food.edible != null){
            foreach(Transform edibleBit in food.edible){
                edibleBit.gameObject.SetActive(false);
            }
        }
    }
    public void SetSelectable(Transform t){
        foreach(Transform tr in t){
            if (tr.childCount>0){
                SetSelectable(tr);
            }
            tr.gameObject.tag = "Selectable";
        }
    }

    public override void DoAction(){
        //pick up
    }
}
