using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Bullet : NetworkBehaviour
{
    [field: SerializeField] public Rigidbody rb { get; private set; }
    [SerializeField] private float lifeTime = 1f;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        enabled = IsOwner;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        UpdateServerRpc();
    }

    [ServerRpc]
    private void UpdateServerRpc()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0f)
        {
            gameObject.GetComponent<NetworkObject>().Despawn();
        }
    }
}
