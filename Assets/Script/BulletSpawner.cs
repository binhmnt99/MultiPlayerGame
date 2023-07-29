using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _launchingForce;

    public void SpawnBullet()
    {
        Bullet newBullet = Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
        newBullet.GetComponent<NetworkObject>().Spawn();
        newBullet.rb.velocity = _shootPoint.forward * _launchingForce;
    }
}
