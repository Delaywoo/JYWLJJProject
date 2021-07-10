using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//kagent.destination = target.transform.position;

public class EnemyFSM : MonoBehaviour
{

    public float delayTime = 60.0f;
    float currentTime = 0;
    NavMeshAgent smith;
    float rotRate = 0;
    bool isBooked = false;

    //NavMeshAgent agent;
    public enum State
    {
        Idle,
        Move,
        Kill,
        KillToMove,
        Die,
    }

    public State state;

    // Start is called before the first frame update
    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();

        state = State.Idle;
        target = GameObject.Find("Player");

        //NavmeshAgent컴포넌트를 가져옴
        smith = GetComponent<NavMeshAgent>();
        smith.speed = 5.0f;
        smith.acceleration = 10.0f;
        smith.stoppingDistance = findDistance;

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
            UpdateMove2();
        }
        else if (state == State.Kill)
        {
            Kill();
        }
        //else if (state == State.Kill)
        //{
        //    UpdateKill();
        //}

        ////시간이 감소됨에 따라 Enemy의 속도가 빨라지게 하고 싶다.
        //Countdown setTime = GameObject.Find("Main Camera").GetComponent<Countdown>();
        //setTime.setTime = 10.0f;
        //if (setTime < )
        //{

        //}

        //if(Time.time > nextTime)
        //{
        //    nextTime = Time.time + TimeLeft;
        //    addSpeed();
        //}

        if (currentTime > delayTime)
        {
            addSpeed();
            //print("속도 증가");
            currentTime = 0;
        }
        else
        {
            currentTime += Time.deltaTime;
        }

    }

    Animator EnemyAnimation;
    public GameObject target;
    public float findDistance;
    private void UpdateIdle()
    {
        if (target != null)
        {
            //float distance = Vector3.Distance(transform.position, target.transform.position);
            float distance = (target.transform.position - transform.position).magnitude;
            //float distance = (target.transform.position - transform.position).sqrMagnitude;

            if (distance < findDistance)
            {
                state = State.Move;

                //agent.destination = target.transform.position;
            }
        }
        else
        {
            return;
        }


    }

    public float speed = 1;
    Quaternion startRotation;
    CharacterController cc;

    private void UpdateMove()
    {

        if (target != null)
        {
            Vector3 dir = target.transform.position - transform.position;
            float distance = dir.magnitude;

            if (distance <= findDistance)
            {
                currentTime = 0;
                //CancelInvoke();

                //EnemyAnimation.SetTrigger("MoveToKill");

                return;
            }
            dir.Normalize();
            cc.Move(dir * speed * Time.deltaTime);
            //transform.position += dir * speed * Time.deltaTime;

            //이동 방향을 바라보도록 회전
            //transform.rotation = Quaternion.LookRotation(dir);
            Quaternion startRot = startRotation;
            Quaternion endRot = Quaternion.LookRotation(dir);
            rotRate += Time.deltaTime * 2f;

            //선형 보간을 이용하여 회전
            transform.rotation = Quaternion.Lerp(startRot, endRot, rotRate);

            //agent.destination = target.transform.position;
        }
        else
        {
            state = State.Idle;
            //agent.isStopped = true;
        }

        //float distance = Vector3.Distance(transform.position, target.transform.position);
        //if (distance < attackDistance)
        //{
        //    state = State.Kill;
        //}

    }

    void UpdateMove2()
    {
        if (target != null)
        {
            smith.enabled = true;
            //플레이어의 위치를 네브메쉬의 목적지로 설정한다.
            smith.SetDestination(target.transform.position);
            //smith.destination = target.transform.position;
            smith.isStopped = false;
        }
        else
        {
            state = State.Idle;
        }
        float dist = Vector3.Distance(target.transform.position, transform.position);
        if (dist <= findDistance)
        {
            state = State.Kill;
            //EnemyAnimation.SetTrigger("MoveToKill");
            smith.isStopped = true;
        }


    }

    private void Kill()
    {
        currentTime += Time.deltaTime;

        //만일 target이 공격 범위 이내라면
        if (Vector3.Distance(target.transform.position, transform.position) < findDistance)
        {
            if (currentTime > delayTime)
            {
                currentTime = 0;
                EnemyAnimation.SetTrigger("DelayToKill");
            }
            else
            {
                if (!isBooked)
                {
                    //1.5초 뒤에 이동 상태로 전환한다.
                    Invoke("SetMoveState", 1.5f);
                    isBooked = true;

                }
                //Invoke("SetMoveState", 1.5f);
                state = State.KillToMove;
            }
        }

    }

    void SetMoveState()
    {
        //이동 상태로 전환
        state = State.Move;

        //이동 애니메이션 실행
        //EnemyAnimation.SetTrigger("IdleToMove");

        //현재 회전 상태를 startRot로 정함
        startRotation = transform.rotation;
        //회전 보간을 위한 rotRate도 0으로 초기화 한다.
        rotRate = 0;

        isBooked = false;

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

    public void addSpeed()
    {
        speed = speed * 2;
        //print("속도 증가");

    }

}