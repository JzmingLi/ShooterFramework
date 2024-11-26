using UnityEngine;

public class BulletFlyweight : MonoBehaviour
{
    public AmmoType ammoType;
    
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * (Time.deltaTime * ammoType.baseVelocity));
    }
}
