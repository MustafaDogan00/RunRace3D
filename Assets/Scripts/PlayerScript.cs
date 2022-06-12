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
    private bool _turn,_superJump;

    private Animator _animator,_cubeAnimator;

    public GameObject cube;
    private GameObject _supriseGround;
    public GameObject _impostorCube;

    private TrailRenderer _trailRenderer;
    private void Awake()
    {
        gameObject.name = PlayerPrefs.GetString("PlayerName", "Player");
    }
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = transform.GetChild(0).GetComponent<Animator>();
        _supriseGround = GameObject.FindGameObjectWithTag("SupriseGround");
        _trailRenderer =gameObject.GetComponent<TrailRenderer>();
        _cubeAnimator=cube.GetComponent<Animator>();
      
    }

    void DoubleJump()
    {

        if (!_characterController.isGrounded && _doubleJump)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && _doubleJump)
            {
                verticalVelocity = jumpForce;
                _doubleJump = false;
                _animator.SetTrigger("Jump");
            }
        }
    }

    
   
    void Update()
    {
        if (GameManager.Instance.finish)
        {
            _move = Vector3.zero;

            if (!_characterController.isGrounded)
            {
                verticalVelocity -= gravity * Time.deltaTime;
            }
            else
            {
                verticalVelocity = 0;
            }
            _move.y = verticalVelocity;
            _characterController.Move(new Vector3(0, _move.y * Time.deltaTime, 0));
            if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Dance"))
            {
                _animator.SetTrigger("Dance");
                transform.eulerAngles = Vector3.up * 180;
            }


            return;

        }

        if (!GameManager.Instance.start)
        { return; }
        _move = Vector3.zero;
        _move = transform.forward;

        if (_characterController.isGrounded )
        {
            _wallSlide = false;
            verticalVelocity = 0;
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                verticalVelocity = jumpForce;
                _doubleJump=true;
                _animator.SetTrigger("Jump");
            }

           /* if (_turn)
            {
                _turn = false;
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);             
                print("euler");             
            }*/
        }
        if (_superJump)
        {
            _superJump=false;
            verticalVelocity = jumpForce * 3;
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
        DoubleJump();

        _animator.SetBool("WallSlide", _wallSlide);
        _animator.SetBool("Grounded", _characterController.isGrounded);

        _move.Normalize();
        _move *= speed;
        _move.y = verticalVelocity;
        _characterController.Move(_move * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Coin")
        {
            Destroy(other.gameObject);
            _supriseGround.gameObject.SetActive(false);
            _cubeAnimator.SetTrigger("CubeFalling");
            _impostorCube.gameObject.SetActive(true);
        }
        if (other.gameObject.tag == "ImpostorCube")
        {
            Destroy(cube);
            StartCoroutine(SpeedBoost());
            _impostorCube.gameObject.SetActive(false);
        }
    }
   
    IEnumerator SpeedBoost()
    {
        speed = 50;
        _trailRenderer.enabled = true;
        yield return new WaitForSeconds(8);
        speed = 25;
        _trailRenderer.enabled = false;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
       
        if (!_characterController.isGrounded)
        {
            if (hit.collider.tag == "Wall" )
            {          
               if (verticalVelocity <0)
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
        else
        {
            if (hit.collider.tag=="Bump")
            {
                _superJump = true;
            }
           /* if (transform.forward != hit.collider.transform.right && hit.collider.tag == "Ground" && !_turn)
            {
                _turn = true;
                print("turn");
            }*/
            _wallSlide = false;
        }
        if (hit.collider.tag == "Slide" && _characterController.isGrounded)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
            verticalVelocity = jumpForce;
        }
        else if (hit.collider.tag == "Slide")
        {         
            _wallSlide = true;
        }
    }



}