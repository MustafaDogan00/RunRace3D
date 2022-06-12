using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorChange : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    private Animator _animator;

    private MeshRenderer _playerMesh;

    void Start()
    {
       
        _meshRenderer = GetComponent<MeshRenderer>();
        _animator = GameObject.FindGameObjectWithTag("Image").GetComponent<Animator>();
       FindObjectOfType<PlayerScript>().playerMesh = _playerMesh;
    }
    private void Update()
    {
        _playerMesh.material.color=_meshRenderer.material.color;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Blue")
        {
            _meshRenderer.sharedMaterial.color = Color.blue;
            _animator.SetTrigger("Flash");
            StartCoroutine(Flash());
           

        }
        if (other.gameObject.tag == "Red")
        {
            _meshRenderer.sharedMaterial.color = Color.red;
            _animator.SetTrigger("Flash");
            StartCoroutine(Flash());
           
        }
        if (other.gameObject.tag == "Green")
        {
            _meshRenderer.sharedMaterial.color = Color.green;
            _animator.SetTrigger("Flash");
            StartCoroutine(Flash());
         
        }
        if (other.gameObject.tag == "Black")
        {
            _meshRenderer.sharedMaterial.color = Color.black;
            _animator.SetTrigger("Flash");
            StartCoroutine(Flash());
           
        }
        if (other.gameObject.tag == "Orange")
        {
            _meshRenderer.sharedMaterial.color = Color.yellow;
            _animator.SetTrigger("Flash");
            StartCoroutine(Flash());
          
        }
        if (other.gameObject.tag == "Gray")
        {
            _meshRenderer.sharedMaterial.color = Color.gray;
            _animator.SetTrigger("Flash");
            StartCoroutine(Flash());
        }
       
    }
   IEnumerator Flash()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}
