using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] public string selectableTag = "Selectable";
    [SerializeField] public string customerTag = "Customer";
    [SerializeField] public string tableSpaceTag = "TableSpace";
    [SerializeField] private Material highlightMaterial;
    // private Material[] defaultMaterial;
    public Transform selected;
    public Selectable selectableSl;

    public GameObject holding;

    private PlayerController pc;

    private RaycastHit hit;

    void Awake(){
        pc = gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        LookForSelect();
        CheckInputs();
    }

    void CheckInputs(){
        if(Input.GetMouseButtonDown(0) && selected != null){
            if(selectableSl != null){
                selectableSl.DoAction(this);
            }
            else if(selected.CompareTag(customerTag)){
                if(holding != null){
                    Give();
                }
            }   
        }
        if(Input.GetMouseButtonDown(1) && holding != null){ //&& selected.CompareTag(tableSpaceTag)
           PutDown();
        }
    }

    void LookForSelect(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit)){
            Transform selection = hit.transform;
            if(selection != selected){
                Deselect();
            }
            selected = selection;
            //selectable highlights yellow
            if(selected.CompareTag(selectableTag)){
                selectableSl = selected.GetComponent<Selectable>();
                if(selectableSl == null){
                    selectableSl = selected.gameObject.GetComponentInParent<Selectable>();
                }
                if( selectableSl != null){
                    Debug.Log("Selecginting");
                    selectableSl.Select(highlightMaterial);
                }
            }
            else{
                selectableSl = null;
                Deselect();
            }
        }
        else{
            Deselect();
        }
    }


    void Deselect(){
        if(selected != null){
            // Renderer selectionRenderer = selected.GetComponent<Renderer>();
            // selectionRenderer.materials = defaultMaterial;
            // defaultMaterial = null;transform.parent.gameObject.GetComponent<Selectable>();
            if( selectableSl != null){
                selectableSl.Deselect();
                selected = null;
                selectableSl = null;
            }
        }
    }

    public void Grab(GameObject item){
        // if(holding != null){
        //     //"put the item back" even tho it never actually moved heh
        //    PutDown();
        // }
        holding = item;
        //Dish dish = item.GetComponent<Dish>();
        FoodItem foodItem = holding.GetComponent<FoodItem>();
        if(foodItem != null && foodItem.dish != null){
            //grabbing the foood item
            foodItem.dish.DeNest(item);
            foodItem.dish = null;
        }
        Transform hand = transform.Find("Hand");
        item.transform.parent = hand;
        item.transform.position = hand.position;
        pc.anima.SetBool("Holding", true);
    }

    public void PutDown(){
        if(holding != null){
            holding.transform.parent = null;
            holding.transform.position = hit.point;//spot.transform.Find("CounterSpace1").position;
            holding.SetActive(true);
            Dish dish = selected.GetComponent<Dish>();
            FoodItem foodItem = holding.GetComponent<FoodItem>();
            if(dish != null){
                dish.Nest(holding);
                if(foodItem != null){
                    foodItem.dish = dish;
                }
            }
            holding = null;

            pc.anima.SetBool("Holding", false);
        }
    }
    public void Give(){
        if(selected.gameObject.GetComponent<Customer>().RecieveItem(holding)){
            holding = null;
            pc.anima.SetBool("Holding", false);
        }
    }
}
