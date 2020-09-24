using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public Destination[] destinations;
    
    void Awake()
    {
        destinations = Object.FindObjectsOfType<Destination>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Destination> GetDestinations(Destination.DestType type){
        List<Destination> returnDests = new List<Destination>();
        foreach(Destination dest in destinations){
            if(dest.type == type){
                returnDests.Add(dest);
            }
        }
        return returnDests;
    }
}
