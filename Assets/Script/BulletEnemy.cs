using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10;

    private void Update() {
        transform.Translate(Vector2.left * Time.deltaTime * _moveSpeed);

        if(transform.position.x < -50 ){
          Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
      if(collision.TryGetComponent( out Player player )){
        player.TakeDamage(1);
        Destroy(gameObject);
      }
    }
}
