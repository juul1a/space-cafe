using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] public string selectableTag = "Selectable";
    [SerializeField] public string customerTag = "Customer";
    [SerializeField] private Material highlightMaterial;
    // private Material[] defaultMaterial;
    public Transform selected;
    public Selectable selectableSl;


    public GameObject holding;

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
                if(holding.GetComponent<FoodItem>()){
                    Give();
                }
            }   
        }
    }

    void LookForSelect(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit)){
            Transform selection = hit.transform;
            if(selection != selected){
                Deselect();
            }
            if(selection.CompareTag(selectableTag)){
                selectableSl = selection.GetComponent<Selectable>();
                if(selectableSl == null){
                    selectableSl = selection.gameObject.GetComponentInParent<Selectable>();
                }
                if( selectableSl != null){
                    selectableSl.Select(highlightMaterial);
                    selected = selection;
                }
            }
            else if(selection.CompareTag(customerTag)){
                selected = selection;
                selectableSl = null;
            }
            else{
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
        holding = item;
        item.SetActive(false);
    }
    public void Give(){
        selected.gameObject.GetComponent<Customer>().RecieveItem(holding.GetComponent<FoodItem>());
        holding = null;
    }
}
