using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    public Material[][] defaultMaterials;
    public MeshRenderer[] mrs;

    void Start()
    {
        mrs = GetComponentsInChildren<MeshRenderer>();
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
}
