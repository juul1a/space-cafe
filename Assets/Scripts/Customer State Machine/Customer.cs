using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public State currentState;
    public State remainState;

    [HideInInspector] public float stateTimeElapsed;
    [HideInInspector] public UnityEngine.AI.NavMeshAgent navMeshAgent;

    public FoodItem order;
    public FoodItem holding;

    public CustomerManager customerManager;
    
    private bool aiActive;

    void Awake(){
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
        // order = DecideOrder();
    // }

    // public void SetupAI(bool aiActivationFromCustomerManager, CustomerManager cm)
    // {
        // customerManager = cm;
        aiActive = true;//aiActivationFromCustomerManager;
        if (aiActive) 
        {
            navMeshAgent.enabled = true;
        } else 
        {
            navMeshAgent.enabled = false;
        }
    }

    void Update()
    {
        if (!aiActive)
            return;
        currentState.UpdateState (this);
    }

    // void OnDrawGizmos()
    // {
    //     if (currentState != null) 
    //     {
    //         Gizmos.color = currentState.sceneGizmoColor;
    //         Gizmos.DrawWireSphere (transform, 2f, 2f);
    //     }
    // }

    public void TransitionToState(State nextState)
    {
        if (nextState != remainState) 
        {
            currentState = nextState;
            OnExitState ();
        }
    }

    public bool CheckIfCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);
    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
    }

//Julia's functions
    // private FoodItem DecideOrder(){
    //     Menu menu = GameObject.Find("Menu").GetComponent<Menu>();;
    //     int index = Random.Range(0, menu.items.Length);
    //     return menu.items[index];
    // }

    // public void RecieveItem(FoodItem item){
    //     holding = item;
    // }

}
