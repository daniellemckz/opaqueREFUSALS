using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float Vector2 = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, Vector2 * Time.deltaTime, 0f, Space.Self);
    }
}
