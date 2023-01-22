using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    private GameObject[] ChildList;

    public int difficultyLevel;
    

    // Start is called before the first frame update
    void Start()
    {
        difficultyLevel = Difficulty.instance.difficultyLevel;


        if (difficultyLevel == 2 || difficultyLevel == 3)
        {
            ChildList = new GameObject[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                ChildList[i] = transform.GetChild(i).gameObject;

            }
            foreach (GameObject go in ChildList)
            {
                go.SetActive(false);

            }
            ChildList[Random.Range(0, ChildList.Length)].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
