using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5;

    private void Update() {
        transform.Translate(Vector2.right * Time.deltaTime * _moveSpeed);

        if(transform.position.x > 50 ){
          Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
      if(collision.TryGetComponent( out Enemy enemy )){
        enemy.TakeDamage(1);
        Destroy(gameObject);
      }
    }
}