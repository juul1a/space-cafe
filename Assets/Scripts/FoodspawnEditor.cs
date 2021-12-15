using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

 [CustomEditor(typeof(FoodSpawn))]
 public class FoodspawnEditor : Editor
 {
    int _choiceIndex;
 
   public override void OnInspectorGUI ()
   {
        // Draw the default inspector
        DrawDefaultInspector();
        FoodSpawn interactable = target as FoodSpawn;
        _choiceIndex = interactable.menu.items.IndexOf(interactable.thisFood);
        string[] menuItems = new string[interactable.menu.items.Count];
        for(int i = 0; i<menuItems.Length; i++){
            menuItems[i] = interactable.menu.items[i].name;
        }
        _choiceIndex = EditorGUILayout.Popup(_choiceIndex, menuItems);
        // Update the selected choice in the underlying object
        interactable.thisFood = interactable.menu.items[_choiceIndex];
        // Save the changes back to the object
        EditorUtility.SetDirty(target);
   }
 }
