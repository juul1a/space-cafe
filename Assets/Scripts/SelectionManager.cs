using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    // private Material[] defaultMaterial;
    private Transform selected;

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit)){
            Transform selection = hit.transform;
            if(selection != selected){
                Deselect();
            }
            if(selection.CompareTag(selectableTag)){
                Selectable sl = selection.GetComponent<Selectable>();
                if(sl == null){
                    sl = selection.transform.parent.gameObject.GetComponent<Selectable>();
                }
                if( sl != null){
                    sl.Select(highlightMaterial);
                    selected = selection;
                }
                // MeshRenderer selectionRenderer = selection.GetComponent<MeshRenderer>();
                // if(selectionRenderer != null){
                //     if(defaultMaterial == null){
                //         defaultMaterial = selectionRenderer.materials;
                //     }
                //     selectionRenderer.material = highlightMaterial;
                // }
                
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
            // defaultMaterial = null;
            Selectable sl = selected.GetComponent<Selectable>();
            if(sl == null){
                sl = selected.transform.parent.gameObject.GetComponent<Selectable>();
            }
            if( sl != null){
                sl.Deselect();
                selected = null;
            }
        }
    }
}
