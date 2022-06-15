using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorChange : MonoBehaviour
{
    private Camera _cameraMain;

    private int _currentPlayer=0;

    public float speed = .5f;
    public float selectionPos = 13;

   [SerializeField] private GameObject _charParent;

     void Awake()
    {
        _cameraMain=Camera.main;
        CameraPos();
    }
    private void Update()
    {
        
    }


    void CameraPos()
    {
        _currentPlayer = PlayerPrefs.GetInt("PlayerColor");

        _cameraMain.transform.position = new Vector3(_cameraMain.transform.position.x+(_currentPlayer*selectionPos), _cameraMain.transform.position.y, _cameraMain.transform.position.z);
    }
    public void Play()
    {
        SceneManager.LoadScene("2");
        PlayerPrefs.SetInt("PlayerColor",_currentPlayer);

    }
    public void Next()
    {
        if (_currentPlayer<_charParent.transform.childCount-1)
        {
            _currentPlayer++;
            StartCoroutine(MoveToNext());
           
        }
    }

   public void Prev()
    {
        if (_currentPlayer >0)
        {
            _currentPlayer--;
            StartCoroutine(MoveToPrev());
        }
    }

    IEnumerator MoveToNext()
    {
        Vector3 tempPos = new Vector3(_cameraMain.transform.position.x + selectionPos, _cameraMain.transform.position.y, _cameraMain.transform.position.z);
        while (_cameraMain.transform.position.x < tempPos.x)
        {

            _cameraMain.transform.position = Vector3.MoveTowards(_cameraMain.transform.position, tempPos, speed);
            yield return new WaitForSeconds(speed * Time.deltaTime);
        }

        yield return null;
    }
    IEnumerator MoveToPrev()
    {
        Vector3 tempPos = new Vector3(_cameraMain.transform.position.x -selectionPos, _cameraMain.transform.position.y, _cameraMain.transform.position.z);
        while (_cameraMain.transform.position.x > tempPos.x)
        {

            _cameraMain.transform.position = Vector3.MoveTowards(_cameraMain.transform.position, tempPos, speed);
            yield return new WaitForSeconds(speed * Time.deltaTime);
        }

        yield return null;
    }
}
