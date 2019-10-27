using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //public GameObject bulletPrefab;
    public GameObject bulletSpawn;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("FIRE!");
            GameObject bulletObject = ObjectPoolingManager.Instance.GetBullet();
            bulletObject.transform.position = bulletSpawn.transform.position;
            bulletObject.transform.forward = bulletSpawn.transform.forward;
        }
    }
}
