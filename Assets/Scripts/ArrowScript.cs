using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class ArrowScript : MonoBehaviour
{
    [SerializeField] private List<Transform> targets;
    Vector2 direction;

    private void Update()
    {
        Transform closestAmmo = GetClosestAmmo();
        if (closestAmmo != null)
        {
            direction = (closestAmmo.position - transform.position).normalized;
            float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
            Debug.Log(angle);
            transform.localRotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private Transform GetClosestAmmo()
    {
        Transform closest = null;
        float minDistance = float.MaxValue;

        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i] != null)
            {
                float distance = Vector2.Distance(transform.position, targets[i].position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closest = targets[i];
                }
            }
        }
        return closest;
    }
}
