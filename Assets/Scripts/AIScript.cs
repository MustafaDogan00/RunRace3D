using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    private Vector3 _move;

    public float speed, jumpForce, gravity, verticalVelocity;

    private CharacterController _characterController;

    private bool _doubleJump,_jump;
    private bool _wallSlide;
    private bool _turn,_superJump;

    public GameObject bump;

    private Animator _animator,_bumpAnimator;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = transform.GetChild(0).GetComponent<Animator>();
        gameObject.name =AIName.Name[Random.Range(0,AIName.Name.Length)];
        _bumpAnimator=bump.GetComponent<Animator>();
    }

    
    void Update()
    {

        if (GameManager.Instance.finish)
        {
            _move = Vector3.zero;
      
            if (!_characterController.isGrounded)
            {             
                verticalVelocity -=gravity*Time.deltaTime;
            }
            else
            {
                verticalVelocity = 0;
            }
            _move.y = verticalVelocity;
            _characterController.Move(new Vector3(0,_move.y*Time.deltaTime,0));
            if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Dance"))
            {
                _animator.SetBool("Dance", true);
                transform.eulerAngles = Vector3.up*180;
            }


            return;
        }
        if (!GameManager.Instance.start)
        { return; }
        _move = Vector3.zero;
        _move = transform.forward;
      
        if (_characterController.isGrounded)
        {
            verticalVelocity = 0;
            _wallSlide = false;
            _jump = true;
            Raycasting();
        }
        if (_superJump)
        {
            _superJump = false;
            verticalVelocity = jumpForce * 2.87f;
            _animator.SetTrigger("Jump");
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
            //Debug.DrawLine(transform.position, hit.point);
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
        if (hit.collider.tag =="Bump")
        {
            _bumpAnimator.SetTrigger("Bump");
            _superJump = true;
        }
    }



}
