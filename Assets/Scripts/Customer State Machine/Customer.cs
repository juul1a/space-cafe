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
    public GameObject holding;
    public FoodItem holdingFood;

    public CustomerManager customerManager;
    
    public GameObject speechBubble;
    public Destination moveTo;
    public Destination seat;
    public bool sitting = false;

    public float waitTime = 0f;

    public Animator anima;
    
    private bool aiActive;

    void Awake(){
        customerManager = GameObject.Find("CustomerManager").GetComponent<CustomerManager>();
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
        speechBubble = transform.Find("Speech Bubble").gameObject;
        anima = GetComponent<Animator>();
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

    public bool RecieveItem(GameObject item){
        FoodItem food = item.GetComponent<FoodItem>();
        if(food == null){
            food = item.GetComponent<Dish>().food;
        }
        if(food.food == order){
            holding = item;
            holdingFood = food;
            anima.SetBool("Holding", true);
            Transform hand = transform.Find("Hand");
            item.transform.parent = hand;
            item.transform.position = hand.position;
            item.gameObject.SetActive(true);
            return true;
        }
        else{
            return false;
        }
    }

    public void PlaceItem(){

    }

}
