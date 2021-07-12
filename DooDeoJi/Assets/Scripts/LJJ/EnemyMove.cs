using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    NavMeshAgent agent;

    public enum State
    {
        Idle,
        Move,
    }

    public State state;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        state = State.Idle;

        target = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if(state == State.Idle)
        {
            UpdateIdle();
        }
        else if (state == State.Move)
        {
            UpdateMove();
        }
    }

    GameObject target;
    public float findDistance = 5;
    private void UpdateIdle()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if(distance < findDistance)
        {
            state = State.Move;

            agent.destination = target.transform.position;

        }

    }

    public float speed = 1;
    private void UpdateMove()
    {
        agent.destination = target.transform.position;
    }

}
