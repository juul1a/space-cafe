using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Customer/Actions/Move")]
public class MoveAction : Action
{
    public Destination.DestType destinationType;

    public override void Act(Customer controller)
    {
        
            Debug.Log("Walking");
            Walk (controller);
    }

    private void Walk(Customer controller)
    {
        if(!controller.anima.GetBool("Walking"));
        {
            controller.anima.SetBool("Walking", true);
        }
        if(controller.moveTo == null || (controller.moveTo.occupant != null && controller.moveTo.occupant != controller.gameObject)){
            List<Destination> destinations = controller.customerManager.GetDestinations(destinationType);
            int index = Random.Range (0, destinations.Count);
            controller.moveTo = destinations[index].GetComponent<Destination>();
            if(destinationType == Destination.DestType.Seat){
                controller.seat = controller.moveTo;
            }
        }
        controller.navMeshAgent.destination = controller.moveTo.transform.position;
        controller.navMeshAgent.Resume ();
    }
}
