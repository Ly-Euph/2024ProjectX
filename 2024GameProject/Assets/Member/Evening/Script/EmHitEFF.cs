using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmHitEFF : MonoBehaviour
{
    float lifeT = 1.0f;
    void Start()
    {
        Destroy(this.gameObject, lifeT);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
