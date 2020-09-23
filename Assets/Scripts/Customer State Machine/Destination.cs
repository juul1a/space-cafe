using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    public bool occupied;
    public enum DestType{
        Seat,
        Stand
    }
    public DestType type;
}
