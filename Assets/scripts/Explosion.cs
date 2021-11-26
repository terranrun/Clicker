using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;
    [SerializeField] private GameObject ExplosionEffect;   
    [SerializeField] private  UnityEvent Active;
    [SerializeField] private Collider col;
    private bool _explosionDone;


    void OnMouseDown()
    {
        Explode();
        Active?.Invoke();
        col.isTrigger = true;

    }




    public void Explode()
    {
        if (_explosionDone) return;
        _explosionDone = true;

        Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, _radius);

        for (int i = 0; i < overlappedColliders.Length; i++)
        {
            Rigidbody rigidbody = overlappedColliders[i].attachedRigidbody;
            if (rigidbody)
            {
                rigidbody.AddExplosionForce(_force, transform.position, _radius);

               Wall explosion = rigidbody.GetComponent<Wall>();
                if (explosion)
                {
                    if (Vector3.Distance(transform.position, rigidbody.position) < _radius)
                    {
                        Active?.Invoke();
                        col.isTrigger =true;
                    }

                   
                }
            }
        }
       
        Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
    }
    



}
