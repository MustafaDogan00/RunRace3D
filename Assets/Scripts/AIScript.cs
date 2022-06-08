﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    private Vector3 _move;

    public float speed, jumpForce, gravity, verticalVelocity;

    private CharacterController _characterController;

    private bool _doubleJump,_jump;
    private bool _wallSlide;
    private bool _turn, _freeFall;

    private Animator _animator;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = transform.GetChild(0).GetComponent<Animator>();

    }

    
    void Update()
    {
        _move = Vector3.zero;
        _move = transform.forward;
      
        if (_characterController.isGrounded)
        {
            verticalVelocity = 0;
            _wallSlide = false;
            _jump = true;
            Raycasting();
        }

        if (!_wallSlide)
        {
            
            gravity = 30;
            verticalVelocity -= gravity * Time.deltaTime;


        }
        else
        {
            gravity = 15;
            verticalVelocity -= gravity * Time.deltaTime;

        }
        _animator.SetBool("Grounded",_characterController.isGrounded);
        _animator.SetBool("WallSlide",_wallSlide);



        _move.Normalize();
        _move *= speed;
        _move.y = verticalVelocity;
        _characterController.Move(_move * Time.deltaTime);
    }
    




    void Raycasting()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.forward,out hit,10f))
        {
            Debug.DrawLine(transform.position, hit.point,Color.red);
            if (hit.collider.tag=="Wall")
            {
                verticalVelocity = jumpForce;
                _animator.SetTrigger("Jump");
               
            }
           
        }


    }

    IEnumerator LateJump(float time)
    {
        _jump = false;
        _wallSlide = true;
        yield return new WaitForSeconds(time);
        if (!_characterController.isGrounded)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
            verticalVelocity = jumpForce;
            _animator.SetTrigger("Jump");
        }

        _jump = true;
        _wallSlide=false;

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.tag=="Wall")
        {
            if (_jump)
            { StartCoroutine(LateJump(Random.Range(0.1f,0.3f))); }
            if (verticalVelocity<0)
            {
                _wallSlide = true;
            }
        }
        if (hit.collider.tag == "Slide" && _characterController.isGrounded)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
            verticalVelocity = jumpForce;

        }
        else if(hit.collider.tag == "Slide")
        {
            _wallSlide=true;
        }
    }



}