using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpriteScroller : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;
    Vector2 offset;
    Material material;
    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }
    void Start()
    {
        
    }

    void Update()
    {
        offset = Time.deltaTime * moveSpeed;
        material.mainTextureOffset += offset;
    }
}
