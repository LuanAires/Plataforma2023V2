using System.Collections;
using UnityEngine;

public class CharacterShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;    
    public float fireRate = 2.0f;   
    public float burstInterval = 4.0f; 

    private bool isShooting = false; 

    void Update()
    {
       
        if (Input.GetButton("Fire1") && !isShooting)
        {
          
            StartCoroutine(ShootBurst());
        }
    }

    IEnumerator ShootBurst()
    {
        isShooting = true;

       
        Shoot();
        yield return new WaitForSeconds(1f / fireRate);

       
        Shoot();
        yield return new WaitForSeconds(burstInterval);

        isShooting = false;
    }

    void Shoot()
    {
       
        if (firePoint != null)
        {
            
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
        else
        {
            Debug.LogWarning("FirePoint não foi configurado.");
        }
    }
}
