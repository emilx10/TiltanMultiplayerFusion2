using System;
using System.Linq;
using UnityEngine;

[ExecuteInEditMode]
public class RadialPositioner : MonoBehaviour
{
    [SerializeField] private Transform[] targets;
    [SerializeField] private float radius = 5f;
    
    void Update()
    {
        if (targets == null || targets.Length == 0) return;

        float angleStep = 360f / targets.Length;
        for (int i = 0; i < targets.Length; i++)
        {
            float angle = i * angleStep;
            float x = radius * Mathf.Cos(angle * Mathf.Deg2Rad);
            float z = radius * Mathf.Sin(angle * Mathf.Deg2Rad);
            targets[i].position = transform.position + new Vector3(x, 0, z);
            targets[i].LookAt(transform.position, Vector3.up);
        }
    }

    private void OnValidate()
    {
        if(targets == null || targets.Length == 0)
            targets = GetComponentsInChildren<Transform>(true).Where(t => t != transform).ToArray();
    }
}
