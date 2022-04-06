using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _damage = 10f;
    [SerializeField]
    private float _range = 100f;
    [SerializeField]
    private float _firerate = 15f;

    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public Camera fpsCam;
    private float nextTimeToFire = 0f;

    public float Damage
    {
        get { return _damage; }
    }
    public float Range
    {
        get { return _range; }
    }
    public float FireRate
    {
        get { return _firerate; }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / FireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, Range))
        {
            Debug.Log(hit.transform.name);
             HealthBehaviour target = hit.transform.GetComponent<HealthBehaviour>();
            if (target != null)
            {
                target.TakeDamage(Damage);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
