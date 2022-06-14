using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorChange : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    private Animator _animator;

    public Material _material;

    [SerializeField] private Color _color;

    void Start()
    {
       
        _meshRenderer = GetComponent<MeshRenderer>();
        _animator = GameObject.FindGameObjectWithTag("Image").GetComponent<Animator>();
      
     
    }
    private void OnTriggerEnter(Collider other)
    {

        switch (other.gameObject.tag)
        {

            case "Blue":
                _meshRenderer.sharedMaterial.color = Color.blue;
                _animator.SetTrigger("Flash");
                StartCoroutine(Flash());
                _material.color = _color;
           break;

            case "Red":
                _meshRenderer.sharedMaterial.color = Color.red;
                _animator.SetTrigger("Flash");
                StartCoroutine(Flash());
                _material.color = Color.red;
           break;

            case "Green":
                _meshRenderer.sharedMaterial.color = Color.green;
                _animator.SetTrigger("Flash");
                StartCoroutine(Flash());
                _material.color = Color.green;
            break;

            case "Black":
                _meshRenderer.sharedMaterial.color = Color.black;
                _animator.SetTrigger("Flash");
                StartCoroutine(Flash());
                _material.color = Color.black;
                break;

            case "Orange":
                _meshRenderer.sharedMaterial.color = Color.yellow;
                _animator.SetTrigger("Flash");
                StartCoroutine(Flash());
                _material.color = Color.yellow;
                break;

            case "Gray":
                _meshRenderer.sharedMaterial.color = Color.gray;
                _animator.SetTrigger("Flash");
                StartCoroutine(Flash());
                _material.color = Color.gray;
                break;

        }




        //if (other.gameObject.tag=="Blue")
        //{
        //    _meshRenderer.sharedMaterial.color = Color.blue;
        //    _animator.SetTrigger("Flash");
        //    StartCoroutine(Flash());
        //   _material.color = Color.blue;

        //}
        //if (other.gameObject.tag == "Red")
        //{
        //    _meshRenderer.sharedMaterial.color = Color.red;
        //    _animator.SetTrigger("Flash");
        //    StartCoroutine(Flash());
        //    _material.color = Color.red;
        //}
        //if (other.gameObject.tag == "Green")
        //{
        //    _meshRenderer.sharedMaterial.color = Color.green;
        //    _animator.SetTrigger("Flash");
        //    StartCoroutine(Flash());
        //    _material.color = Color.green;

        //}
    //    if (other.gameObject.tag == "Black")
    //    {
    //        _meshRenderer.sharedMaterial.color = Color.black;
    //        _animator.SetTrigger("Flash");
    //        StartCoroutine(Flash());
    //        _material.color = Color.black;

    //    }
    //    if (other.gameObject.tag == "Orange")
    //    {
    //        _meshRenderer.sharedMaterial.color = Color.yellow;
    //        _animator.SetTrigger("Flash");
    //        StartCoroutine(Flash());
    //        _material.color = Color.yellow;
    //    }
    //    if (other.gameObject.tag == "Gray")
    //    {
    //        _meshRenderer.sharedMaterial.color = Color.gray;
    //        _animator.SetTrigger("Flash");
    //        StartCoroutine(Flash());
    //        _material.color = Color.gray;
    //    }
       
    }
   IEnumerator Flash()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}
