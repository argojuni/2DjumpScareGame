using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMoving : MonoBehaviour
{
    public float speed = 5f;
    void Update()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
    }
}
