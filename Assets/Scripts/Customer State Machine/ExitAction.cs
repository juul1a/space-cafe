using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Customer/Actions/Exit")]
public class ExitAction : Action
{
    public override void Act(Customer controller)
    {
        controller.customerManager.DestroyMe(controller);
    }
}
