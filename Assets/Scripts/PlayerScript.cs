using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Vector3 _move;

    public float speed, jumpForce, gravity, verticalVelocity;

    private CharacterController _characterController;

    private bool _doubleJump;
    private bool _wallSlide;

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
            _wallSlide = false;
            //verticalVelocity = 0;
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                verticalVelocity = jumpForce;
                //_doubleJump=true;
                _animator.SetTrigger("Jump");
            }
        }
        if (!_wallSlide)
        {
            gravity = 30;
            verticalVelocity -= gravity * Time.deltaTime;
            /* if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && _doubleJump)
             {
                 verticalVelocity = jumpForce + 15;
                 _doubleJump = false;
             }       */
        }
        else
        {
            gravity = 15;
            verticalVelocity -= gravity * 0.09f * Time.deltaTime;
        }

        _animator.SetBool("WallSlide", _wallSlide);
        _animator.SetBool("Grounded", _characterController.isGrounded);

        _move.Normalize();
        _move *= speed;
        _move.y = verticalVelocity;
        _characterController.Move(_move * Time.deltaTime);
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {


        if (!_characterController.isGrounded)
        {
            if (hit.collider.tag == "Wall")
            {
                if (verticalVelocity < 0)
                    _wallSlide = true;

                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    verticalVelocity = jumpForce;
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
                    _wallSlide = false;
                    _animator.SetTrigger("Jump");
                }

            }
        }
    }



}