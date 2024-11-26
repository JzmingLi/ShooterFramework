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
            newBullet.AddComponent<Bullet>();
            Bullet bullet = newBullet.GetComponent<Bullet>();
            bullet.baseVelocity = ammoType.baseVelocity;
            bullet.cartridgeSize = ammoType.cartridgeSize;
            bullet.projectilePrefab = newBullet;

            GameObject.Destroy(newBullet, Lifetime);
            return newBullet;
        }
        
        public static GameObject SpawnFlyweightBullet(AmmoType ammoType, Weapon source, float Lifetime)
        {
            Transform muzzle = source.Muzzle;
            GameObject newBullet = GameObject.Instantiate(ammoType.projectilePrefab, muzzle.position, muzzle.rotation);
            newBullet.AddComponent<BulletFlyweight>();
            BulletFlyweight bullet = newBullet.GetComponent<BulletFlyweight>();
            bullet.ammoType = ammoType;

            GameObject.Destroy(newBullet, Lifetime);
            return newBullet;
        }
    }
}