using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Customer/Actions/Stand")]
public class StandAction : Action
{
    public float timeToLerp = 0.5f;
    public override void Act(Customer controller)
    { 
        if(controller.anima.GetBool("Sitting") && controller.seat != null && controller.sitting){
            controller.waitTime = 0f;
            controller.holdingFood.FoodEaten();
            Stand(controller);
        }
        else if(controller.waitTime<1.0f && controller.seat != null && controller.sitting){
            StandLerp(controller);
        }
        else{
            if(controller.sitting){
                controller.navMeshAgent.enabled = true;
                controller.sitting = false;
            }
        }
    }
    public void Stand(Customer controller){
        controller.seat.occupant = null;
        controller.anima.SetBool("Sitting", false);
        controller.holding = null;
        controller.anima.SetBool("Holding", false);
    }

    public void StandLerp(Customer controller){
        controller.waitTime += Time.deltaTime / timeToLerp;
        controller.transform.position = Vector3.Lerp(controller.seat.seat.position, controller.seat.transform.position, controller.waitTime);
    }
}
