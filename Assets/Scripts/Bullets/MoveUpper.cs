using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpper : MonoBehaviour
{
    public float SpeedMovement = 15f;

    void Update()
    {
        transform.Translate(Vector3.up * SpeedMovement * Time.deltaTime);    
    }
}