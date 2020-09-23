using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enviroment : MonoBehaviour
{
   // Speed multiplier
     public float speedMultiplier = 2f;
         
     void Awake(){
       Screen.lockCursor = true;
     }
     // Update is called once per frame
     void Update ()
     {
         //Sets the float value of "_Rotation", adjust it by Time.time and a multiplier.
         RenderSettings.skybox.SetFloat("_Rotation", Time.time * speedMultiplier);     
     }
}
