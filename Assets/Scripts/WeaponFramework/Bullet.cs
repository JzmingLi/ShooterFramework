using System;
using UnityEngine;
using WeaponFramework;

public class Bullet : MonoBehaviour
{
    public CartridgeSize cartridgeSize;
    public GameObject projectilePrefab;

    public float baseVelocity;
    
    private void Update()
    {
        transform.Translate(transform.forward * (Time.deltaTime * baseVelocity));
    }
}
