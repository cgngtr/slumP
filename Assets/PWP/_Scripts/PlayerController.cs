using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _player;
    private Animator _animator;

    private Vector3 _axis, _movePlayer;
    private Vector3 _camRight, _camForward;
    private Camera _cam;

    [SerializeField] private float _moveSpeed;


    void Awake()
    {
        _player = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _cam = Camera.main;

    }

    private void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Input.GetAxis("Mouse X"), 0);
        _axis = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _animator.SetFloat("PosX", _axis.x);
        _animator.SetFloat("PosZ", _axis.z);

        if (_axis.magnitude > 1) _axis = _axis.normalized;
        //else _axis = transform.TransformDirection(_axis);
        _axis *= _moveSpeed;

        getDirection();
        _movePlayer = _axis.x * _camRight + _axis.z * _camForward;
        transform.LookAt(transform.position + _movePlayer);

        _player.Move(_movePlayer * Time.deltaTime); ;
    }


    private void getDirection()
    {
        _camRight = _cam.transform.right.normalized;
        _camForward = _cam.transform.forward.normalized;
        _camRight.y = 0;
        _camForward.y = 0;
    }


}
