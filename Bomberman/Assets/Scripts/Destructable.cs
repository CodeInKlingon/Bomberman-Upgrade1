using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {

    public Animator anim;

    // Use this for initialization
    public void Destroy()
    {
        anim.SetTrigger("Explode");
        Destroy(gameObject, .75f);
    }
}
