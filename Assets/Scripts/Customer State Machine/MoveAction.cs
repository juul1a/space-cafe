using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Customer/Actions/Move")]
public class MoveAction : Action
{
    public Destination.DestType destinationType;
    private Destination moveTo;

    public override void Act(Customer controller)
    {
        Walk (controller);
    }

    private void Walk(Customer controller)
    {
        if(moveTo == null || (moveTo.occupant != null && moveTo.occupant != controller.gameObject)){
            List<Destination> destinations = controller.customerManager.GetDestinations(destinationType);
            int index = Random.Range (0, destinations.Count);
            moveTo = destinations[index].GetComponent<Destination>();
        }
        controller.navMeshAgent.destination = moveTo.transform.position;
        controller.navMeshAgent.Resume ();
    }
}
