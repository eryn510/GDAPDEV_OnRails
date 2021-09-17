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
            if (this.gameObject.tag != "BOSS")
            {
                animator.SetBool("Cast Spell", true);
            }
            else
            {
                animator.SetBool("Attack", true);
            }
                
            attackTicks = 0.0f;
        }
        else
        {
            if (this.gameObject.tag != "BOSS")
            {
                animator.SetBool("Cast Spell", false);
            }
                
            else
            {
                animator.SetBool("Attack", false);
            }
                
        }
        
    }
}
