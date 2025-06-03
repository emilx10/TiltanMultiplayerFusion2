using System;
using UnityEngine;

public class SpawnPointGizmo : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 1f);
    }
}
