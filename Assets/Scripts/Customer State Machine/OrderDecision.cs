using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Customer/Decisions/Order")]
public class OrderDecision : Decision
{
    public override bool Decide(Customer controller){
        if(controller.holding != null && controller.holding == controller.order){
            controller.speechBubble.SetActive(false);
            //take item in hand
            controller.order = null;//reset order
            return true;
        }
        else if(controller.holding != null && controller.holding != controller.order){
            //say "nope"
            controller.holding = null;
            return false;
        }
        return false;
        
    }
}
