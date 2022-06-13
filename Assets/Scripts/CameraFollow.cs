using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _player;

    public Vector3 offset;
   
    void Start()
    {
        _player = GameObject.Find(PlayerPrefs.GetString("PlayerName","Player")).transform;
    }

 
    void Update()
    {
        offset.x =_player.forward.x*5f;
        transform.position = Vector3.MoveTowards(transform.position,new Vector3(_player.position.x+offset.x, _player.position.y + offset.y, _player.position.z + offset.z),50*Time.deltaTime);
       if (GameManager.Instance.finish)
        {
            offset = new Vector3(5, 9, -30);
        }
    }
}
