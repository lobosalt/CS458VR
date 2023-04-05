using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class slimePlay : MonoBehaviour
{
    public GameObject Player;
    public float distanceToPlayer;
    public float distanceToToy;
    public float playTimer;

    public characterHold Who;
    public WanderAI wander;

    public NavMeshAgent _agent;
    // Update is called once per frame
    void Update()
    {
        playTimer -= 1.0f * Time.deltaTime;
        //Distance to player
        distanceToPlayer = Vector3.Distance(Player.transform.position, transform.position);
        //Should hold the distance to the last toy picked up as the gameObject
        distanceToToy = Vector3.Distance(Who.heldToy.transform.position, transform.position);

        if (distanceToPlayer < 10 && Who.Hold == "Player")
        {
            playTimer = 200.0f;
            Debug.Log("\nWe are still playing for: " + playTimer);
            wander.isPlaying = true;
        }
        if (wander.isPlaying == true && playTimer > 0 && Who.Hold != "Player")
        {
            if(Who.Hold == "Pet")
            {
                _agent.SetDestination(Player.transform.position);
                if(distanceToPlayer < 5 && Who.Hold == "Pet")
                {
                    Who.heldToy.gameObject.GetComponent<Rigidbody>().velocity += Vector3.up * Time.deltaTime * 3.0f;
                    Who.Hold = "None";
                }
            }
            else
            {
                _agent.SetDestination(Who.heldToy.transform.position);
                if(distanceToPlayer < 10)
                {
                    _agent.isStopped = true;
                }
                else
                {
                    _agent.isStopped = false;
                }
            }
        }
        if (wander.isPlaying == true && playTimer < 0 && Who.Hold != "Pet")
        {
            wander.isPlaying = false;
        }
    }
}
