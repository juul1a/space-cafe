using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public Destination[] destinations;

    public GameObject[] aliens;

    public float spawnTime = 20f;
    public float time = 0f;

    public int numAliens = 0;
    public int maxAliens = 5;
    
    void Awake()
    {
        destinations = Object.FindObjectsOfType<Destination>();
    }

    void Start(){
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= spawnTime){
            time = 0f;
            if(numAliens < maxAliens){
                Spawn();
            }
        }
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

    public void Spawn(){
        int index = Random.Range(0, aliens.Length);
        GameObject newAlien = Instantiate(aliens[index]);
        newAlien.transform.position = transform.position;
        numAliens++;
    }

    public void DestroyMe(Customer me){
        Destroy(me.gameObject);
        numAliens--;
    }
}
