using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Customer/Decisions/Sit")]
public class DoneEatingDecision : Decision
{
    public override bool Decide(Customer controller){
        if(controller.waitTime >= controller.holdingFood.food.eatTime){
            return true;
        }
        else{
            return false;
        }
    }
}
