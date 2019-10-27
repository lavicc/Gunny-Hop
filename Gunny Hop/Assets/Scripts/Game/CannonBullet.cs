using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float bulletDuration;
    private float bulletDeleteTimer;

    private void OnEnable()
    {
        bulletDeleteTimer = bulletDuration;
    }

    private void Update()
    {
        //Bullet Travels Forward
        transform.position += transform.forward * speed * Time.deltaTime;

        //Destroy Bullet eventually
        bulletDeleteTimer -= Time.deltaTime;
        if (bulletDeleteTimer <= 0.0f)
        {
            gameObject.SetActive(false);
        }
    }
}
