using System;
using Fusion;
using UnityEngine;

public class Projectile : NetworkBehaviour
{
    [SerializeField] float speed = 10f;
    
    public override void FixedUpdateNetwork()
    {
        base.FixedUpdateNetwork();
        if(Object.HasStateAuthority)
         transform.Translate(Vector3.forward * speed * Runner.DeltaTime);
    }
}
