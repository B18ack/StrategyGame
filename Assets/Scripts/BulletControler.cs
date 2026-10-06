using System;
using UnityEngine;

public class BulletControler : MonoBehaviour
{
    [NonSerialized] public Vector3 position;
    public float speed = 30f;
    [NonSerialized] public int damage;   // задаётся стреляющим юнитом

    private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, position, step);

        if (transform.position == position)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            CarAttack attack = other.GetComponent<CarAttack>();
            if (attack != null)
                attack.TakeDamage(damage);
        }
    }
}