using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class BulletSpawner : NetworkBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _launchingForce;

    [ServerRpc]
    public void SpawnBulletServerRpc()
    {
        Bullet newBullet = Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
        newBullet.GetComponent<NetworkObject>().Spawn();
        newBullet.rb.velocity = _shootPoint.forward * _launchingForce;
    }
}
