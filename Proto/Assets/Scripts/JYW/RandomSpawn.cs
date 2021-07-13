using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    // 게임 시작 시 여러개의 책상들 중 랜덤으로 공책이 생기게 하고싶다.
    int[] myNums = new int[5];

    public GameObject BookFactory;
    public GameObject Books;
    



    // Start is called before the first frame update
    void Start()
    {

        // 1. table 개수의 숫자만큼의 후보들 중 공책개수만큼의 숫자를 중복없이 고른다.
        ChooseRandomNumbers();

        // 2. 고른 숫자가 포함된 테이블 위에 공책을 생성한다.
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

            //자식 오브젝트의 myNums[i] 번째 테이블에 생성

            go.transform.position = Table.transform.GetChild(index).transform.position + new Vector3(0, 1.5f, 0);
            go.transform.parent = Books.transform;
            

        }


    }





}
