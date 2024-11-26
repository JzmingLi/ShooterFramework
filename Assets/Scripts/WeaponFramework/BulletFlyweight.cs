using UnityEngine;

public class BulletFlyweight : MonoBehaviour
{
    public AmmoType ammoType;
    
    
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * (Time.deltaTime * ammoType.baseVelocity);
    }
}
