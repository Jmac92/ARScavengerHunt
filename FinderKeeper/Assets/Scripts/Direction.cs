using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour {
    public float RotationSpeed;
    private Quaternion _lookRotation;
    private Vector3 _direction;

    public GameObject FindClosestItem()
    {
        GameObject[] items;
        items = GameObject.FindGameObjectsWithTag("Low");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject item in items)
        {
            Vector3 diff = item.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = item;
                distance = curDistance;
            }
        }
        return closest;
    }

    void Update()
    {
        GameObject item = FindClosestItem();
        _direction = (item.transform.position - transform.position).normalized;
        _lookRotation = Quaternion.LookRotation(_direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime + RotationSpeed);
    }
}
