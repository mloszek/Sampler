using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BkgRotator : MonoBehaviour
{
    [SerializeField]
    private Material material;
    [SerializeField]
    private float speed;

    private Vector2 offset;

    private void Start()
    {
        offset = material.mainTextureOffset;
        material.mainTextureOffset = Vector2.zero;
    }

    void Update()
    {
        offset.x -= Time.deltaTime * speed;
        offset.y += Time.deltaTime * speed;
        material.mainTextureOffset = offset;
    }
}
