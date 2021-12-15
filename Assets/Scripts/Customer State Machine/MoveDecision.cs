using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Customer/Decisions/Move")]
public class MoveDecision : Decision
{
   public override bool Decide(Customer controller){
       if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending) 
        {
           controller.moveTo = null;
           controller.anima.SetBool("Walking", false);
           return true;
        }
        return false;
   }
}
