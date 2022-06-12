using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorChange : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    private Animator _animator;

    public GameObject player;

    private MeshRenderer _playerMesh;
    void Start()
    {
       
        _meshRenderer = GetComponent<MeshRenderer>();
        _animator = GameObject.FindGameObjectWithTag("Image").GetComponent<Animator>();
        _playerMesh = player.GetComponent<MeshRenderer>();
    }

   
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Blue")
        {
            _meshRenderer.sharedMaterial.color = Color.blue;
            _animator.SetTrigger("Flash");
            StartCoroutine(Flash());
            _playerMesh.material.color = Color.blue;

        }
        if (other.gameObject.tag == "Red")
        {
            _meshRenderer.sharedMaterial.color = Color.red;
            _animator.SetTrigger("Flash");
            StartCoroutine(Flash());
            _playerMesh.sharedMaterial.color = Color.red;
        }
        if (other.gameObject.tag == "Green")
        {
            _meshRenderer.sharedMaterial.color = Color.green;
            _animator.SetTrigger("Flash");
            StartCoroutine(Flash());
            _playerMesh.sharedMaterial.color = Color.green;
        }
        if (other.gameObject.tag == "Black")
        {
            _meshRenderer.sharedMaterial.color = Color.black;
            _animator.SetTrigger("Flash");
            StartCoroutine(Flash());
            _playerMesh.sharedMaterial.color = Color.black;
        }
        if (other.gameObject.tag == "Orange")
        {
            _meshRenderer.sharedMaterial.color = Color.yellow;
            _animator.SetTrigger("Flash");
            StartCoroutine(Flash());
            _playerMesh.sharedMaterial.color = Color.yellow;
        }
        if (other.gameObject.tag == "Gray")
        {
            _meshRenderer.sharedMaterial.color = Color.gray;
            _animator.SetTrigger("Flash");
            StartCoroutine(Flash());
            _playerMesh.sharedMaterial.color = Color.gray;

        }
       
    }
   IEnumerator Flash()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}
