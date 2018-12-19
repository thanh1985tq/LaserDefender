using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] List<Transform> waypoint;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] GameObject explosionParticles;
    [SerializeField] GameObject enemyProjectile;
    [SerializeField] float projectileSpeed = 3f;
    [SerializeField] int hp = 100;
    [SerializeField] float minFireRate = 1f;
    [SerializeField] float maxFireRate = 3f;

    float fireRate;
    int currentWayPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        fireRate = Random.Range(minFireRate, maxFireRate);

        //Set position of enemy at the first waypoint
        transform.position = waypoint[currentWayPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        Move(waypoint);
        Fire();
    }

    private void Move(List<Transform> waypoint)
    {
        int wpCount = waypoint.Count;
        if(currentWayPoint < wpCount) { 
            Vector3 target = waypoint[currentWayPoint].transform.position;
            transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            if(transform.position == target)
            {
                currentWayPoint++;
            }
        }else
        {
            Destroy(gameObject);
        }
    }

    private void Fire()
    {
        fireRate -= Time.deltaTime;
        if(fireRate <= 0)
        {
            //Do fire
            GameObject projectile = Instantiate(enemyProjectile, transform.position, Quaternion.identity)
                as GameObject;
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -projectileSpeed);

            //Reset fire rate
            fireRate = Random.Range(minFireRate, maxFireRate);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer dd = collision.GetComponent<DamageDealer>();

        if(dd != null)
        {
            hp -= dd.GetDamage();
            Destroy(collision.gameObject);
        }

        if(hp <= 0)
        {
            Destroy(gameObject);
            GameObject explosion = Instantiate(explosionParticles, transform.position, Quaternion.identity);
            Destroy(explosion, 1f);
        }
    }
}
