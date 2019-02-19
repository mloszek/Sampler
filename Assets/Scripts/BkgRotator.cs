using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BkgRotator : MonoBehaviour
{
    [SerializeField]
    private float speed;

    void Update()
    {
        transform.Rotate(Vector3.back * Time.deltaTime * speed);
    }
}
