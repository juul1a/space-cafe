using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : Action
{
    public List<Destination> destinations;
    public Destination moveTo;

    public override void Act(Customer controller)
    {
        Walk (controller);
    }

    private void Walk(Customer controller)
    {
        if(moveTo == null || moveTo.occupied){
            int index = Random.Range (0, destinations.Count);
            moveTo = destinations[index];
        }
        controller.navMeshAgent.destination = moveTo.position;
        controller.navMeshAgent.Resume ();

        if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending) 
        {
            controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
        }
    }
    
    public void Reset(){
        moveTo = null;
    }
}
