using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingItemEffect : MonoBehaviour
{
    [SerializeField]
    private float degreesPerSecond;
    [SerializeField]
    private float amplitude;
    [SerializeField]
    private float frequency;
 
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
 
    void Start () {
        posOffset = transform.position;
    }
     
    void Update () {
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);
 
        tempPos = posOffset;
        tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;
 
        transform.position = tempPos;
    }
}
