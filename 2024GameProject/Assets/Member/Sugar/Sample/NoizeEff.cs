using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoizeEff : MonoBehaviour
{
    public Vector2 speed = new Vector2(1f, 1f);
    public Material material;

    void Start()
    {
        //Renderer renderer = GetComponent<Renderer>();
        //material = renderer.material;
    }

    void Update()
    {
        // Calculate speed based on time or other factors
        float time = Time.deltaTime;
        Vector2 offset = new Vector2(speed.x * time, speed.y * time);
        material.SetVector("_Speed", offset);
    }
}
