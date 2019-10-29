using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //Shoot Variables
    public GameObject bulletSpawn;

    //Scope Variables
    public Animator animator;
    public GameObject scopeOverlay;
    public GameObject weaponCamera;
    public Camera mainCamera;

    [SerializeField] private float waitForScopeAnim;

    public float scopedFOV = 15f;
    private float normalFOV;

    private bool scoping = false;
    
    private void Update()
    {
        if (!scoping)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("FIRE!");
                GameObject bulletObject = ObjectPoolingManager.Instance.GetBullet();
                bulletObject.transform.position = bulletSpawn.transform.position;
                bulletObject.transform.forward = bulletSpawn.transform.forward;
            }
        }

        if (Input.GetButtonDown("Fire2"))
        {
            scoping = !scoping;
            animator.SetBool("isScoping", scoping);

            if (scoping)
            {
                StartCoroutine(Onscoped());
            }
            else {
                OnUnscoped();
            }
        }

        void OnUnscoped()
        {
            scopeOverlay.SetActive(false);
            weaponCamera.SetActive(true);

            mainCamera.fieldOfView = normalFOV;
        }

        IEnumerator Onscoped()
        {
            yield return new WaitForSeconds(waitForScopeAnim);
            scopeOverlay.SetActive(true);
            weaponCamera.SetActive(false);

            normalFOV = mainCamera.fieldOfView;
            mainCamera.fieldOfView = scopedFOV;
        }
    }
}
