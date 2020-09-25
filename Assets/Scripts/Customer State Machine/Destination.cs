using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    public GameObject occupant = null;
    [System.Serializable]
    public enum DestType{
        Seat,
        Stand
    }
    public DestType type;

    void OnTriggerStay(Collider col){
        if(col.gameObject.GetComponent<Customer>() != null){
            occupant = col.gameObject;
        }
    }
    void OnTriggerExit(Collider col){
        if(col.gameObject.GetComponent<Customer>() != null){
            occupant = null;
        }
    }
}
