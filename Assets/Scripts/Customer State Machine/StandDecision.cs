using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Customer/Decisions/Stand")]
public class StandDecision : Decision
{
    public override bool Decide(Customer controller){
        if(!controller.sitting){
            return true;
        }
        else{
            return false;
        }
    }
}
