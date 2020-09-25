using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Selectable : MonoBehaviour
{
    private Material[][] defaultMaterials;
    public MeshRenderer[] mrs;
    
    void Awake(){
        SetMaterials();
    }

    public void SetMaterials(){
        mrs = gameObject.GetComponentsInChildren<MeshRenderer>();
        // if(mrs.Length == 0 || mrs == null){
        //     mrs = gameobject.GetComponentsInChildren<MeshRenderer>();
        // }
        defaultMaterials = new Material[mrs.Length][];
        for(int i = 0; i < mrs.Length; i++){
            defaultMaterials[i] = mrs[i].materials;
        }
    }

    public void Select(Material mat){
        foreach(MeshRenderer mr in mrs){
            Material[] selectMat = new Material[mr.materials.Length];
            for(int i = 0; i < selectMat.Length; i++){
                selectMat[i] = mat;
            }
            mr.materials = selectMat;
        }
    }
    public void Deselect(){
        for(int i = 0; i < mrs.Length; i++){
            mrs[i].materials = defaultMaterials[i];
        }
    }

    public abstract void DoAction (SelectionManager sm = null);
}
