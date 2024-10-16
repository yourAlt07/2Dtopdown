using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed=1;
    [SerializeField] private float timeBetweenShots=1f;
    [SerializeField] private Transform gunOffset;

    private bool fireContinuously;
    private float lastFireTime;
    
    private void OnFire(InputValue inputValue){
        fireContinuously=inputValue.isPressed;
    }

    private void FireBullet(){
        if(bulletPrefab){
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
            rigidbody.velocity = bulletSpeed * transform.up;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if(fireContinuously){
            float timeSinceLastFire = Time.time - lastFireTime;
            if (timeSinceLastFire >timeBetweenShots){
                FireBullet();
                lastFireTime=Time.time;
            }
        }
    }
}
