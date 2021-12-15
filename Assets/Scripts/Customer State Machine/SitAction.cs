using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Customer/Actions/Sit")]
public class SitAction : Action
{
    public float timeToLerp = 0.5f;
    public override void Act(Customer controller)
    {
        if(!controller.anima.GetBool("Sitting")){
            controller.waitTime = 0f;
            Sit(controller);
        }
        if(controller.waitTime<1.0f && controller.seat != null){
            SitLerp(controller);
        }
        else{
            if(!controller.sitting){
                controller.sitting = true;
            }
            controller.waitTime += Time.deltaTime;
        }
    }

    public void Sit(Customer controller){
        controller.seat.occupant = controller.gameObject;
        controller.navMeshAgent.enabled = false;
        controller.anima.SetBool("Sitting", true);
        
        if(controller.seat.seat != null){
            controller.transform.rotation = Quaternion.Euler(controller.transform.eulerAngles.x,controller.seat.seat.eulerAngles.y,controller.transform.eulerAngles.z);
        }
        if(controller.holding != null){
            controller.holding.transform.parent = controller.seat.tableSpace;
            controller.holding.transform.position = controller.seat.tableSpace.position;
            // controller.holding = null;
        }
    }

    public void SitLerp(Customer controller){
        controller.waitTime += Time.deltaTime / timeToLerp;
        controller.transform.position = Vector3.Lerp(controller.seat.transform.position, controller.seat.seat.position, controller.waitTime);
    }
}
