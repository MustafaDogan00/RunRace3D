using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPickController : MonoBehaviour
{
    public float speed; 

    private Animator _animator;
    void Start()
    {
        speed =2;
        _animator =transform.GetChild(0).GetComponent<Animator>();
    }

  
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward*Time.deltaTime*speed);
            _animator.SetBool("Grounded",true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -1 * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-1 * Time.deltaTime * speed, 0, 0 );
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(1 * Time.deltaTime * speed, 0, 0 );
        }
    }
}
