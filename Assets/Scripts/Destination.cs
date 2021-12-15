using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    public GameObject occupant = null;
    [System.Serializable]
    public enum DestType{
        Seat,
        Stand,
        Exit
    }
    public DestType type;
    public Transform seat;
    public Transform tableSpace;

    void OnTriggerStay(Collider col){
        if(col.gameObject.GetComponent<Customer>() != null && type == DestType.Stand){
            occupant = col.gameObject;
        }
    }
    void OnTriggerExit(Collider col){
        if(col.gameObject.GetComponent<Customer>() != null && type == DestType.Stand){
            occupant = null;
        }
    }
}
