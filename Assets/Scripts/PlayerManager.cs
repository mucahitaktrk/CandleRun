using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerManager : MonoBehaviour
{
    private float _lastFingerPos = 0.0f;
    private float _moveX = 0.0f;
    [SerializeField] private float _speedX;
    [SerializeField] private float _speedZ;
    [SerializeField] private float _bondrey;

    [SerializeField] private float _meltingTime;


    [SerializeField] private GameObject[] _finishPanel;

    private bool _isWin = false;
    private bool _isFail = false;
    private void Awake()
    {
        for (int i = 0; i < _finishPanel.Length; i++)
        {
            _finishPanel[i].gameObject.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        MoveSystem();
    }

    private void Update()
    {
        Time.timeScale = 1.0f;
        GameOver();
    }

    private void MoveSystem()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastFingerPos = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            _moveX = _lastFingerPos - Input.mousePosition.x;
            _lastFingerPos = Input.mousePosition.x;
        }
        else
        {
            _moveX = 0.0f;
        }

        float xBondrey = Mathf.Clamp(value: transform.position.x, min: -_bondrey, max: _bondrey);
        transform.position = new Vector3(xBondrey, transform.position.y, transform.position.z);

        if (_isWin || _isFail)
        {
            _speedZ = 0.0f;
            _speedX = 0.0f;
        }
        float dragX = Time.fixedDeltaTime * _moveX * _speedX;
        transform.Translate(Vector3.forward * _speedZ);
        transform.Translate(Vector3.left * dragX);


    }

    public void CandleScaleUp(float up)
    {
        GetComponent<ParticleSystem>().Play();
        transform.localScale =
            new Vector3(
            transform.localScale.x,
            transform.localScale.y + up,
            transform.localScale.z);
    }

    public void CandleScaleDown(float down)
    {
        transform.localScale =
        new Vector3(
        transform.localScale.x,
        Mathf.Lerp(transform.localScale.y, transform.localScale.y - down, Time.fixedDeltaTime * _meltingTime),
        transform.localScale.z);
    }

    public void GameWin()
    {
        _isWin = true;
        _finishPanel[0].SetActive(true);
        transform.DOMoveX(0, 1.0f);
        Debug.Log("WIN !!");
    }
    private void GameOver()
    {
        if (transform.localScale.y < 0.0f)
        {
            _finishPanel[1].SetActive(true);
            transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            Debug.Log("GAME OVER !!");
            _isFail = true;
        }

    }
}
