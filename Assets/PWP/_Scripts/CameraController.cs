using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Vector3 _offset;
    [SerializeField] private Transform _player;
    [SerializeField][Range(0, 1)] private float _lerpValue;
    [SerializeField] private float _sensitivity;

    private void Awake()
    {
    }
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _player.position + _offset, _lerpValue);
        _offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * _sensitivity, Vector3.up) * _offset;

        transform.LookAt(_player);
    }


}
