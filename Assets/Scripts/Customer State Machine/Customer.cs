using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public State currentState;
    public State remainState;

    [HideInInspector] public float stateTimeElapsed;
    [HideInInspector] public UnityEngine.AI.NavMeshAgent navMeshAgent;

    public Food order;
    public FoodItem holding;

    public CustomerManager customerManager;
    
    public GameObject speechBubble;
    
    private bool aiActive;

    void Awake(){
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
        speechBubble = transform.Find("Speech Bubble").gameObject;
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

    public void RecieveItem(FoodItem item){
        holding = item;
        Transform hand = transform.Find("Hand");
        item.transform.parent = hand;
        item.transform.position = hand.position;
        item.gameObject.SetActive(true);
    }

}
