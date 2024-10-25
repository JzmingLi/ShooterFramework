using UnityEngine;

namespace WeaponFramework.Factories
{
    public static class ProjectileFactory
    {
        // For being shot out of a weapon
        public static GameObject SpawnBullet(AmmoType ammoType, Weapon source, float Lifetime)
        {
            Transform muzzle = source.Muzzle;
            GameObject newBullet = GameObject.Instantiate(ammoType.projectilePrefab, muzzle.position, muzzle.rotation);
            Rigidbody rb = newBullet.GetComponent<Rigidbody>();
            float force = rb.mass * ammoType.baseVelocity;
            
            rb.AddForce(muzzle.forward * force, ForceMode.Impulse);
            
            GameObject.Destroy(newBullet, Lifetime);
            return newBullet;
        }
    }
}