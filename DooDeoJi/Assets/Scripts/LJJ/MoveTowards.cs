using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveLookAt();
    }

    void MoveLookAt()
    {
        //���� ī�޶� �ٶ󺸴� ����
        Vector3 dir = cam.transform.localRotation * Vector3.forward;
        //ī�޶� �ٶ󺸴� �������� �Ѹǵ� �ٶ󺸰� ��
        transform.localRotation = cam.transform.localRotation;
        //�Ѹ��� Rotation.x���� freeze�س������� �������� ���� Rotation���� 0���� ��������
        transform.localRotation = new Quaternion(0, transform.localRotation.y, 0, transform.localRotation.w);
        //�ٶ󺸴� ���� �������� �̵�
        gameObject.transform.Translate(dir * 0.1f * Time.deltaTime);
    
    }


}
