﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Customer/State")]
public class State : ScriptableObject 
{
    public Action[] actions;
    public Transition[] transitions;
    public Color sceneGizmoColor = Color.grey;

    public void UpdateState(Customer controller)
    {
        DoActions (controller);
        CheckTransitions (controller);
    }

    private void DoActions(Customer controller)
    {
        for (int i = 0; i < actions.Length; i++) {
            actions [i].Act (controller);
        }
    }

    private void CheckTransitions(Customer controller)
    {
        for (int i = 0; i < transitions.Length; i++) 
        {
            bool decisionSucceeded = transitions [i].decision.Decide (controller);

            if (decisionSucceeded) {
                controller.TransitionToState (transitions [i].trueState);
            } else 
            {
                controller.TransitionToState (transitions [i].falseState);
            }
        }
    }


}
