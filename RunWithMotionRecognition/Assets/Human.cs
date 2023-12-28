using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0.1f;

    [SerializeField]
    private float _moveTime = 0.25f;

    bool _isMove = false;
    int _moveDir = 0;
    int _point = 0;
    int _speedCount = 0;
    int _maxSpeedCount = 10;

    [SerializeField]
    TextMeshProUGUI _pointText;

    Vector3 _currentPosition;


    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + _speed);
    }

    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -2)
        {
            //_isMove = true;
            //_moveDir = -2;
            //_currentPosition = transform.position;
            transform.position = Vector3.Lerp(transform.position,
                new Vector3(transform.position.x - 2, transform.position.y, transform.position.z),
                1);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < 2)
        {
            //_isMove = true;
            //_moveDir = 2;
            //_currentPosition = transform.position;
            transform.position = Vector3.Lerp(transform.position,
                new Vector3(transform.position.x + 2, transform.position.y, transform.position.z),
                1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plane"))
        {
            GameManager.instance.MovePlane();
        }
    }

    void Move()
    {
        
    }

    public void GetPoint()
    {
        _point++;
        _speedCount++;
        _pointText.text = "Point: " + _point;
        if (_speedCount == _maxSpeedCount)
        {
            _speed += (_speedCount * 0.01f);
            _speedCount = 0;
        }
    }
}
