using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTimeAnimation : MonoBehaviour
{
    // Start is called before the first frame update


    Animator anim;
    public float r;
    void Start()
    {
        anim = GetComponent<Animator>();

         r = Random.Range(0.0f,1.0f);

        anim.SetFloat("randomTime", r);



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
