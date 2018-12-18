using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int hp = 500;
    [SerializeField] GameObject playerProjectile;
    [SerializeField] float projectileSpeed = 5f;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float fireRate = 0.2f;

    float minX;
    float maxX;
    float minY;
    float maxY;
    Coroutine fireCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        Camera myCamera = Camera.main;
        minX = myCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        maxX = myCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        minY = myCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        maxY = myCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            fireCoroutine = StartCoroutine(FireContinuosly());
        }
        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(fireCoroutine);
        }
    }

    private IEnumerator FireContinuosly()
    {
        while (true)
        {
            GameObject projectile = Instantiate(playerProjectile, transform.position, Quaternion.identity) as GameObject;
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(fireRate);
        }
    }

    private void Move()
    {
        float xOffset = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float yOffset = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float xRange = Mathf.Clamp(xOffset + transform.position.x, minX, maxX);
        float yRange = Mathf.Clamp(yOffset + transform.position.y, minY, maxY);
        transform.position = new Vector2(xRange, yRange);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer dd = collision.GetComponent<DamageDealer>();

        if (dd != null)
        {
            hp -= dd.GetDamage();
            Destroy(collision.gameObject);
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
