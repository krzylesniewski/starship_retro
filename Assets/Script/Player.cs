using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 10;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private GameObject _shootEffect;

        // SoundEffects
    [SerializeField] private GameObject _getHitEffect;
    [SerializeField] private GameObject _getHitSound;
    [SerializeField] private GameObject _getKilledEffect;
    [SerializeField] private GameObject _getKilledSoundEffect;

    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
        UpdateHealthUI();
    }
    private void Update()
    {
        Vector2 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        transform.position = mousePosition;

        if( Input.GetMouseButtonDown(0) ) {
            var bullet = Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.identity);
            var shootSoundEffect = Instantiate(_shootEffect, transform.position, Quaternion.identity);
            Destroy(shootSoundEffect, 1f);
        }
    }

    public void TakeDamage(int dmg)
    {
        _health -= dmg;
        var damageEffect = Instantiate(_getHitEffect, transform.position, Quaternion.identity);
        UpdateHealthUI();
        Destroy(damageEffect, 1f);

        if (_health <= 0)
        {
            Destroy(gameObject);
            // kill effect
            var killEffect = Instantiate(_getKilledEffect, transform.position, Quaternion.identity);
            Destroy(killEffect, 2f);
            // kill sound effect
            var killSoundEffect = Instantiate(_getKilledSoundEffect, transform.position, Quaternion.identity);
            Destroy(killSoundEffect, 1.5f);
            // restet game
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            Destroy(gameObject);
        }
    }

    private void UpdateHealthUI(){
        _healthText.text = $"{_health}/10";
    }

}
