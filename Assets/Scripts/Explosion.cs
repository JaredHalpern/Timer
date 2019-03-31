using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour, IExecutableAction
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ExecuteAction()
    {
        animator.SetTrigger("explode");
    }
}