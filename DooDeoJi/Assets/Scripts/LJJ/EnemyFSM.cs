using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    NavMeshAgent agent;
    public enum State
    {
        Idle,
        Move,
    }

    public State state;

    //float time;
    //float checktime;

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
        if (state == State.Idle)
        {
            UpdateIdle();
        }
        else if (state == State.Move)
        {
            UpdateMove();
        }
        //else if (state == State.Kill)
        //{
        //    UpdateKill();
        //}

        //시간이 감소됨에 따라 Enemy의 속도가 빨라지게 하고 싶다.
        Countdown setTime = GameObject.Find("Main Camera").GetComponent<Countdown>();
        setTime.setTime = 10.0f;
        //if (setTime < )
        //{
            
        //}


    }

    public GameObject target;
    public float findDistance;
    private void UpdateIdle()
    {
        if(target != null)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);

            if (distance < findDistance)
            {
                state = State.Move;

                agent.destination = target.transform.position;
            }
        }
        else
        {
            return;
        }
        
        
    }

    public float speed = 1;
    //public float attackDistance = 1;
    private void UpdateMove()
    {
        
        if (target != null)
        {
            //Vector3 dir = target.transform.position - transform.position;
            //dir.Normalize();
            //transform.position += dir * speed * Time.deltaTime;
            agent.destination = target.transform.position;
        }
        else
        {
            state = State.Idle;
            agent.isStopped = true;
        }
        
        //float distance = Vector3.Distance(transform.position, target.transform.position);
        //if (distance < attackDistance)
        //{
        //    state = State.Kill;
        //}



    }

    //float currentTime;
    //float attackTime = 1;

    //private void UpdateKill()
    //{
    //    //currentTime += Time.deltaTime;

    //    //if (currentTime > attackTime)
    //    //{
    //    //    currentTime = 0;
    //    //    //target.AddDamage();
    //    //    float distance = Vector3.Distance(transform.position, target.transform.position);
    //    //    if (distance > attackDistance)
    //    //    {
    //    //        state = State.Move;
    //    //    }
    //    //}
    //}

   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(collision.gameObject);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.name == "Player")
    //    {
    //        Destroy(other.gameObject);
    //    }
    //}


}