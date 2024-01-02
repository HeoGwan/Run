using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField]
    private float                   _speed = 0.1f;

    [SerializeField]
    private float                   _moveTime = 0.25f;

    [SerializeField]
    private float                   _slideTime = 0.25f;

    [SerializeField]
    float                           _jumpPower = 6f;

    bool                            _isMove = false;
    bool                            _isJump = false;
    bool                            _isSlide = false;

    int                             _moveDir = 0;
    int                             _point = 0;
    int                             _speedCount = 0;
    int                             _maxSpeedCount = 10;

    [SerializeField]
    TextMeshProUGUI                 _pointText;

    [SerializeField]
    Animator                        _animator = null;

    [SerializeField]
    Rigidbody                       _rigid = null;

    [SerializeField]
    CapsuleCollider                 _collider = null;

    Vector3                         _currentPosition;

    private void Start()
    {
        _animator ??= GetComponent<Animator>();
        _rigid ??= GetComponent<Rigidbody>();
        _collider ??= GetComponent<CapsuleCollider>();
    }


    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + _speed);
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            && transform.position.x > -2)
        {
            //_isMove = true;
            //_moveDir = -2;
            //_currentPosition = transform.position;
            transform.position = Vector3.Lerp(transform.position,
                new Vector3(transform.position.x - 2, transform.position.y, transform.position.z),
                1);
        }

        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            && transform.position.x < 2)
        {
            //_isMove = true;
            //_moveDir = 2;
            //_currentPosition = transform.position;
            transform.position = Vector3.Lerp(transform.position,
                new Vector3(transform.position.x + 2, transform.position.y, transform.position.z),
                1);
        }

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
        {
            Jump();
        }

        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && !_isSlide)
        {
            //Slide();
            StartCoroutine(Sliding());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            GameManager.instance.MovePlane();
        }
    }

    void Jump()
    {
        _rigid.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
    }

    


    /*
     * public functions
    */
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

    public void Die()
    {
        _speed = 0;
        _animator.SetTrigger("FallDown");
    }

    IEnumerator Sliding()
    {
        _isSlide = true;
        _collider.direction = 2;
        _animator.SetBool("isSlide", true);

        yield return new WaitForSeconds(_slideTime);

        _isSlide = false;
        _collider.direction = 1;
        _animator.SetBool("isSlide", false);
    }
}
