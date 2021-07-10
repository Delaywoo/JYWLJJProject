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

        //NavmeshAgent������Ʈ�� ������
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

        ////�ð��� ���ҵʿ� ���� Enemy�� �ӵ��� �������� �ϰ� �ʹ�.
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
            //print("�ӵ� ����");
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

            //�̵� ������ �ٶ󺸵��� ȸ��
            //transform.rotation = Quaternion.LookRotation(dir);
            Quaternion startRot = startRotation;
            Quaternion endRot = Quaternion.LookRotation(dir);
            rotRate += Time.deltaTime * 2f;

            //���� ������ �̿��Ͽ� ȸ��
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
            //�÷��̾��� ��ġ�� �׺�޽��� �������� �����Ѵ�.
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

        //���� target�� ���� ���� �̳����
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
                    //1.5�� �ڿ� �̵� ���·� ��ȯ�Ѵ�.
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
        //�̵� ���·� ��ȯ
        state = State.Move;

        //�̵� �ִϸ��̼� ����
        //EnemyAnimation.SetTrigger("IdleToMove");

        //���� ȸ�� ���¸� startRot�� ����
        startRotation = transform.rotation;
        //ȸ�� ������ ���� rotRate�� 0���� �ʱ�ȭ �Ѵ�.
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
        //print("�ӵ� ����");

    }

}