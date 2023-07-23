using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KYS_Background : MonoBehaviour
{
    Material mt = null;
    float map_speed = 5f;

    private void Awake()
    {
        mt = GetComponent<MeshRenderer>().material;
        
    }

    // Update is called once per frame
    void Update()
    {
       mt.mainTextureOffset += new Vector2 (0.5f * Time.deltaTime, 0);
    }
}
