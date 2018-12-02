using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentagramPresentionController : MonoBehaviour {

    static Animator animator;
    // Use this for initialization
    void Start() {
        animator = GetComponent<Animator>();
    }


    public static void doRotate()
    {
        animator.SetTrigger("Rotate");
    }
}
