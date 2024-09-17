using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleEm : MonoBehaviour
{
    [SerializeField]Animator anim;
    void Update()
    {
        anim.Play("idle");

    }
}
