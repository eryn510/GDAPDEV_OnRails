using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    float attackTicks = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        attackTicks += Time.deltaTime;
        if(attackTicks > 3.0f)
        {
            animator.SetBool("Cast Spell", true);
            attackTicks = 0.0f;
        }
        else
        {
            animator.SetBool("Cast Spell", false);
        }
        
    }
}
