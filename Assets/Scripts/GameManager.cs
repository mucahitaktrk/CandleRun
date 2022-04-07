using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _fansList;
    [SerializeField] private GameObject[] _sawsList;
    [SerializeField] private float _rotateSpeed;

    private void Start()
    {
        _fansList = GameObject.FindGameObjectsWithTag("Fan");
        _sawsList = GameObject.FindGameObjectsWithTag("Saw");
    }

    
    private void Update()
    {
        FanSystem();
        SawSystem();
    }

    private void FanSystem()
    {
        for (int i = 0; i < _fansList.Length; i++)
        {
            _fansList[i].transform.Rotate(Vector3.up * Time.deltaTime * _rotateSpeed);
        }
    }

    private void SawSystem()
    {
        for (int i = 0; i < _sawsList.Length; i++)
        {
            _sawsList[i].transform.Rotate(Vector3.right * Time.deltaTime * _rotateSpeed);
        }
    }

    public void NextLevelButton()
    {
        SceneManager.LoadScene(0);
    }

    public void LoseButton()
    {
        SceneManager.LoadScene(0);
    }
}
