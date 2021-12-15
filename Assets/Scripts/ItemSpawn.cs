using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : Selectable
{
    public GameObject item;

    private Transform spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
            spawnPosition = transform.Find("SpawnPoint");
    }

    // Update is called once per frame
    public override void DoAction(SelectionManager sm = null){
        GameObject newObj = Instantiate(item);
        // newObj.transform.parent = transform;
        newObj.transform.position = spawnPosition.position;
    }
}
