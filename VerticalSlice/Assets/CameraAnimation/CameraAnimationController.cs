using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CameraAnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            animator.SetTrigger("StartAttack");
        }
    }
}
