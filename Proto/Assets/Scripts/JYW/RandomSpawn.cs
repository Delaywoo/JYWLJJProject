using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    // ���� ���� �� �������� å��� �� �������� ��å�� ����� �ϰ�ʹ�.
    int[] myNums = new int[5];

    public GameObject BookFactory;
    public GameObject Books;
    



    // Start is called before the first frame update
    void Start()
    {

        // 1. table ������ ���ڸ�ŭ�� �ĺ��� �� ��å������ŭ�� ���ڸ� �ߺ����� ����.
        ChooseRandomNumbers();

        // 2. �� ���ڰ� ���Ե� ���̺� ���� ��å�� �����Ѵ�.
        MakingBooks();


    }

    // Update is called once per frame
    void Update()
    {
       

    }


    void ChooseRandomNumbers()
    {

        GameObject Table = GameObject.FindGameObjectWithTag("Table");

        for (int i = 0; i < myNums.Length; i++)
        {
            int TableNumber = Table.transform.childCount;
            //print(TableNumber);

            int number = Random.Range(0, TableNumber);
            myNums[i] = number;

            for (int j = 0; j < i; j++)
            {
                if (myNums[j] == number)
                {
                    i--;
                    break;
                }
            }

        }


    }

    void MakingBooks()
    {
        GameObject Table = GameObject.FindGameObjectWithTag("Table");

        for (int i = 0; i < myNums.Length; i++)
        {
            int index = myNums[i];
            GameObject go = Instantiate(BookFactory);

            //�ڽ� ������Ʈ�� myNums[i] ��° ���̺� ����

            go.transform.position = Table.transform.GetChild(index).transform.position + new Vector3(0, 1.5f, 0);
            go.transform.parent = Books.transform;
            

        }


    }





}
