using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public int score = 0;                 // คะแนน
    public bool getItem = false;          // สถานะเก็บไอเท็ม
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (getItem)
        {
            Debug.Log("Get Item");
        }
    }
    public void GetItem()
    {
        getItem = true;
        score += 1;
    }
}
