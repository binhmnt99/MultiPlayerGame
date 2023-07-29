using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class AutomaticRifle : NetworkBehaviour
{
    [SerializeField] private float _cooldown;
    [SerializeField] private InputActionReference _shootAction;
    private float _lastShotTime;

    public UnityEvent BulletShot;
    // Start is called before the first frame update

    private void Start()
    {
        enabled = IsOwner;
    }
    private void Update()
    {
        if (Time.time - _lastShotTime >= _cooldown && _shootAction.action.IsPressed())
        {
            OnShoot();
            _lastShotTime = Time.time;
        }
    }

    private void OnShoot()
    {
        BulletShot?.Invoke();
    }
}
