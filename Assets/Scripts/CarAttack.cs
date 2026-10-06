using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CarAttack : MonoBehaviour
{
    [Header("Характеристики")]
    public int maxHealth = 100;   // ХП, настраивается в Inspector
    public int damage = 20;       // урон, настраивается в Inspector
    public float radius = 70f;
    public GameObject bullet;

    [NonSerialized] public int _health;

    private Coroutine _coroutine;
    private Transform _healthBar;
    private Vector3 _healthBarStartScale;

    private void Awake()
    {
        _health = maxHealth;
        _healthBar = transform.GetChild(0);
        _healthBarStartScale = _healthBar.localScale;
    }

    // Вызывается пулей
    public void TakeDamage(int amount)
    {
        _health -= amount;

        // Полоска уменьшается пропорционально оставшемуся ХП
        float percent = Mathf.Clamp01((float)_health / maxHealth);
        _healthBar.localScale = new Vector3(
            _healthBarStartScale.x * percent,
            _healthBarStartScale.y,
            _healthBarStartScale.z);

        if (_health <= 0)
            Destroy(gameObject);
    }

    private void Update()
    {
        DetectColistion();
    }

    private void DetectColistion()
    {
        Collider[] hitColiders = Physics.OverlapSphere(transform.position, radius);

        if (hitColiders.Length == 0 && _coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;

            if (gameObject.CompareTag("Enemy"))
                GetComponent<NavMeshAgent>().SetDestination(gameObject.transform.position);
        }

        foreach (var el in hitColiders)
        {
            if ((gameObject.CompareTag("Player") && el.gameObject.CompareTag("Enemy")) ||
                (gameObject.CompareTag("Enemy") && el.gameObject.CompareTag("Player")))
            {
                if (gameObject.CompareTag("Enemy"))
                    GetComponent<NavMeshAgent>().SetDestination(el.transform.position);

                if (_coroutine == null)
                    _coroutine = StartCoroutine(StartAttack(el));
            }
        }
    }

    IEnumerator StartAttack(Collider enemyPos)
    {
        GameObject obj = Instantiate(bullet, transform.GetChild(1).position, Quaternion.identity);
        BulletControler b = obj.GetComponent<BulletControler>();
        b.position = enemyPos.transform.position;
        b.damage = damage;               // передаём урон этого юнита
        yield return new WaitForSeconds(1f);
        StopCoroutine(_coroutine);
        _coroutine = null;
    }
}