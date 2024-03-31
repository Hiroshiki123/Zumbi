using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abobora : MonoBehaviour
{
    Transform player;
    bool coli =  false;


    private void Start()
    {
        
        //player = FindAnyObjectByType<Player>().transform;
        Destroy(gameObject,6);
    }
    private void Update()
    {
        if (coli)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * 9);
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            coli = true;
            player = collider.transform;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UiController.numabo += 1; 
            Destroy(gameObject);
        }
    }
}
