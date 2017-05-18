using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown2D : MonoBehaviour
{
    float platformSpeed;
    bool endPoint; //check

    float endPointt;
    float startPoint;
    public int unitsToMove = 2;

    void Start()
    {
        platformSpeed = Random.Range(1f, 4f);
        startPoint = transform.position.y;

        endPointt = startPoint + unitsToMove;
    }


    // Update is called once per frame
    void Update()
    {
        if (endPoint)
        {
            transform.position += Vector3.up * platformSpeed * Time.deltaTime;
        }
        else
        {
            transform.position -= Vector3.up * platformSpeed * Time.deltaTime;
        }

        if (transform.position.y >= endPointt)
        {
            endPoint = false;
        }
        else if (transform.position.y <= startPoint)
        {
            endPoint = true;
        }
    }
}
    