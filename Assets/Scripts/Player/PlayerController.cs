using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerData _playerData;
    private PlayerView _playerView;

    [SerializeField] private float _horizontalInput;

    [SerializeField] private float _limitXPosition = 8;

    private void Start()
    {
        _playerData = GetComponent<PlayerData>();
        _playerView = GetComponent<PlayerView>();
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");

        transform.Translate(Vector3.right * Time.deltaTime * _horizontalInput * _playerData.SpeedMovement);

        Limiter();

        VerifyShooter();
    }

    private void VerifyShooter()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _playerData.CanShoot)
        {
            GameObject bullet = _playerData.GetBulletObject(transform.position);
            _playerData.CanShoot = false;
            _playerData.Reload();
        }
    }

    private void Limiter()
    {
        if (transform.position.x > _limitXPosition)
        {
            transform.position = new Vector3(_limitXPosition, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -_limitXPosition)
        {
            transform.position = new Vector3(-_limitXPosition, transform.position.y, transform.position.z);
        }
    }
}