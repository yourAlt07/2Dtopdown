using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private HealthController enemyHPController;
    private Camera _camera;
    // Start is called before the first frame update
    private void Awake(){
        _camera = Camera.main;
    }
    private void Update(){
        DestroyOffScreen();
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.GetComponent<EnemyMovement>()){
            Destroy(this.gameObject);
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            enemyHPController = collision.GetComponent<HealthController>();
            enemyHPController.TakeDamage(10);
            // Destroy(collision.gameObject);
        }
    }
    private void DestroyOffScreen(){
        Vector2 screenPosition = _camera.WorldToScreenPoint(this.transform.position);

        if(screenPosition.x < 0 || 
        screenPosition.x > _camera.pixelWidth ||
        screenPosition.y < 0 || 
        screenPosition.y > _camera.pixelHeight
        ){
            Destroy(this.gameObject);
        }
    }
}
