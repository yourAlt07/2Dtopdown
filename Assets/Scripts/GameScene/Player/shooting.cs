using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Shooting : MonoBehaviour
{
    
    private Camera mainCam;
    private Vector3 mousePos;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed=8;
    [SerializeField] private float timeBetweenShots;
    [SerializeField] private Transform gunOffset;
    [SerializeField] private GameObject gunObj;

    private SpriteRenderer gunSprite;
    private Transform gunTransform;
    private float powerUpDuration=0f;
    private float standardFireSpeed=.5f;
    private float powerUpSpeed=.2f;

    AudioManager audioManager;

    private bool fireContinuously;
    private float lastFireTime;

    private void Awake(){
        if(gunObj){
            gunSprite=gunObj.GetComponent<SpriteRenderer>();
        }
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnFire(InputValue inputValue){
        fireContinuously=inputValue.isPressed;
    }

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void FireBullet(float rotZ){
        if(bulletPrefab){
            audioManager.PlaySFX(audioManager.shoot);
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
            bullet.transform.rotation = Quaternion.Euler(0,0,rotZ-90);
            bullet.transform.position = this.transform.position;
            rigidbody.velocity = bulletSpeed*bullet.transform.up;
        }

    }

    public void PowerUp(float secs){
        powerUpDuration=3f;
    }

    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - this.transform.position;
        float rotZ = Mathf.Atan2(rotation.y,rotation.x)*Mathf.Rad2Deg;
        Vector3 newGunPos = gunObj.transform.localPosition;
        if(Mathf.Abs(rotZ)>90){
            gunSprite.flipY=true;
            newGunPos.y=.09f;
        }else{
            gunSprite.flipY=false;
            newGunPos.y=-.09f;
        }
        gunObj.transform.localPosition = newGunPos;
        this.transform.rotation = Quaternion.Euler(0,0,rotZ);

        if(Input.GetMouseButton(0)){
            float timeSinceLastFire = Time.time - lastFireTime;
            if(powerUpDuration>0){
                powerUpDuration-=Time.deltaTime;
                timeBetweenShots=powerUpSpeed;
            }else{
                timeBetweenShots=standardFireSpeed;
            }
            if (timeSinceLastFire >timeBetweenShots){
                FireBullet(rotZ);
                lastFireTime=Time.time;
            }
        }
    }
}
