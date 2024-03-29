﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : Selectable
{
    public Food food;
    public bool selectable = true;
    public bool spawnCenter = false;

    public Dish dish;
    
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
            if(spawnCenter){
                Renderer rr = foodObject.GetComponent<Renderer>();
                if(rr == null){
                    rr = foodObject.GetComponentsInChildren<Renderer>()[0];
                }
                if(rr != null){
                    Debug.Log("Spawning center");
                    foodObject.transform.position += foodObject.transform.position - rr.bounds.center;
                }
            }
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
        if(food.edible){
            Destroy(gameObject);
        }
    }
    public void SetSelectable(Transform t){
        gameObject.tag = "Selectable";
        foreach(Transform tr in t){
            if (tr.childCount>0){
                SetSelectable(tr);
            }
            tr.gameObject.tag = "Selectable";
        }
    }

    public override void DoAction(SelectionManager sm = null){
        if(sm != null && sm.holding == null){
            sm.Grab(gameObject);
        }
    }
}
