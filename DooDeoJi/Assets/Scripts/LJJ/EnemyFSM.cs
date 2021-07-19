using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{

    public float delayTime = 60.0f;
    float currentTime = 0;
    NavMeshAgent smith;
    float rotRate = 0;
    bool isBooked = false;
    Transform player;

    public Transform GetTargetTransform()
    {
        return player;
    }


    //NavMeshAgent agent;
    public enum State
    {
        Idle,
        Move,
        KillToMove,
        Kill,
        Die,
    }

    public State state;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Idle;
        player = GameObject.Find("Player").transform;

        cc = transform.GetComponent<CharacterController>();

        EnemyAnimation = GetComponentInChildren<Animator>();

        //EnemyAnimation.SetBool("isDie", false);

        //NavmeshAgent������Ʈ�� ������
        smith = GetComponent<NavMeshAgent>();
        smith.speed = 1.0f;
        smith.acceleration = 10.0f;
        smith.stoppingDistance = 0;

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
        //else if (state == State.Kill)
        //{
        //    UpdateKill();
        //}
        else if (state == State.Die)
        {
            Die();
        }

        //���� �ð� ���ҿ� ���� Enemy���� ��ȭ
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

    public void addSpeed()
    {
        speed = speed + 2;
        //print("�ӵ� ����");

    }

    Animator EnemyAnimation;
    public float findDistance;
    private void UpdateIdle()
    {
        if (player != null)
        {
            //float distance = Vector3.Distance(transform.position, target.transform.position);
            float distance = (player.position - transform.position).magnitude;
            //float distance = (target.transform.position - transform.position).sqrMagnitude;

            if (findDistance >= distance)
            {
                //�̵� ���·� ��ȯ
                SetMoveState();

            }
            //���ݹ��� ���̶��
            else
            {
                if (!isBooked)
                {
                    //5�� �ڿ� �̵� ���·� ��ȯ�Ѵ�.
                    Invoke("SetMoveState", 5.0f);
                    isBooked = true;

                }
                //Invoke("SetMoveState", 1.5f);
                //state = State.KillToMove;
            }
        }
        else
        {
            return;
        }

    }

    void SetMoveState()
    {
        //�̵� ���·� ��ȯ
        state = State.Move;

        //�̵� �ִϸ��̼� ����
        EnemyAnimation.SetTrigger("IdleToMove");

        //���� ȸ�� ���¸� startRot�� ����
        startRotation = transform.rotation;
        //ȸ�� ������ ���� rotRate�� 0���� �ʱ�ȭ �Ѵ�.
        rotRate = 0;

        //isBooked = false;

    }

    public float speed = 1;
    Quaternion startRotation;
    CharacterController cc;
    private void UpdateMove()
    {

        if (player != null)
        {
            Vector3 dir = player.position - transform.position;
            float distance = dir.magnitude;

            //if (distance <= findDistance)
            //{

            //    currentTime = 0;
            //    //CancelInvoke();

            //    //EnemyAnimation.SetTrigger("MoveToKill");

            //    return;
            //}
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
        if (player != null)
        {
            smith.enabled = true;
            //�÷��̾��� ��ġ�� �׺�޽��� �������� �����Ѵ�.
            smith.SetDestination(player.position);
            //smith.destination = target.transform.position;
            smith.isStopped = false;

        }
        else
        {
            state = State.Idle;
            
        }
        //float dist = Vector3.Distance(target.transform.position, transform.position);
        //if (dist <= findDistance)
        //{
        //    state = State.KillToMove;
        //    //EnemyAnimation.SetTrigger("");
        //    smith.isStopped = true;
        //}
        //else
        //{
        //    //if (!isBooked)
        //    //{
        //    //    //1.5�� �ڿ� �̵� ���·� ��ȯ�Ѵ�.
        //    //    Invoke("SetMoveState", 1.5f);
        //    //    isBooked = true;

        //    //}
        //}


    }

    //private void KillToMove()
    //{
    //    currentTime += Time.deltaTime;

    //    //���� target�� ���� ���� �̳����
    //    if (Vector3.Distance(player.position, transform.position) < findDistance)
    //    {
    //        if (currentTime > delayTime)
    //        {
    //            currentTime = 0;
    //            //EnemyAnimation.SetTrigger("DelayToKill");
    //        }
    //        //���ݹ��� ���̶��
    //        else
    //        {
    //            if (!isBooked)
    //            {
    //                //1.5�� �ڿ� �̵� ���·� ��ȯ�Ѵ�.
    //                Invoke("SetMoveState", 1.5f);
    //                isBooked = true;

    //            }
    //            //Invoke("SetMoveState", 1.5f);
    //            state = State.KillToMove;
    //        }
    //    }

    //}

    //float attackTime = 0;
    //private void UpdateKill()
    //{
    //    currentTime += Time.deltaTime;

    //    if (currentTime > attackTime)
    //    {
    //        currentTime = 0;
    //        //target.AddDamage();
    //        float distance = Vector3.Distance(transform.position, target.transform.position);
    //        if (distance > attackDistance)
    //        {
    //            state = State.Move;
    //        }
    //    }
    //}


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Camera.main.gameObject.transform.parent = null;

            Destroy(collision.gameObject);
            //state = State.Kill;
            //EnemyAnimation.SetBool("isDie", true);
            GameManager.gm.SetActiveOption(true);

        }
    }

    private void Kill()
    {
        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.name == "Player")
    //    {
    //        Destroy(other.gameObject);
    //    }
    //}

    public void Die()
    {
        //�÷��̾ å�� 5�� ���� ������ ���� ����
        
    }
}