using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    // Enemy General Statistic
    [SerializeField] private int _hp = 3;
    [SerializeField] private int _speed = 5;
    [SerializeField] private int _killValue = 1;

    // EnemyUI
    [SerializeField] public HealthBar healthBar;
    [SerializeField] public GameScoreManager _gameScore;
    [SerializeField] public TextMeshProUGUI _gameScoreText;

    // Enemy attack
    [SerializeField] private float _attakSpeed = 1.0f;
    [SerializeField] private BulletEnemy _ememyBullet;
    [SerializeField] private Transform _shootPoint;


    // SoundEffects
    [SerializeField] private GameObject _getHitEffect;
    [SerializeField] private GameObject _getHitSound;
    [SerializeField] private GameObject _getKilledEffect;
    [SerializeField] private GameObject _getKilledSoundEffect;


    private void Start() {
        healthBar.SetMaxHealth(3);
        InvokeRepeating("Shoot", 0, _attakSpeed);

    }
    private void Update() {
        transform.Translate(Vector2.down * Time.deltaTime * _speed);

        if(transform.position.x > 50){
          Destroy(gameObject);
        }
    }

    public void TakeDamage(int dmg)
    {
        _hp -= dmg;
        healthBar.SetHealth(_hp);
        var damageEffect = Instantiate(_getHitEffect, transform.position, Quaternion.identity);
        Destroy(damageEffect, 1f);

        if (_hp <= 0)
        {
            _gameScore.UpdateGameScoreUI(_killValue);
            _gameScoreText.text = _gameScore.GetCurrentScore().ToString();
            // kill effect
            var killEffect = Instantiate(_getKilledEffect, transform.position, Quaternion.identity);
            Destroy(killEffect, 2f);
            // kill sound effect
            var killSoundEffect = Instantiate(_getKilledSoundEffect, transform.position, Quaternion.identity);
            Destroy(killSoundEffect, 1f);

            Destroy(gameObject);
            Destroy(healthBar);
        }
    }

    private void Shoot(){
        var bullet = Instantiate(_ememyBullet, transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.TryGetComponent(out Player player))
        {
            player.TakeDamage(100);
            Destroy(gameObject);
        }

    }
}