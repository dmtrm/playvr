using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static GameObject GetNearest(Vector3 origin, List<GameObject> collection)
    {
        GameObject nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0.0f;

        foreach (GameObject entity in collection)
        {
            distance = (entity.gameObject.transform.position - origin).sqrMagnitude;

            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = entity;
            }
        }

        return nearest;
    }

    public static GameObject GetNearestPlatform(Vector3 origin, GameObject[] collection)
    {
        GameObject nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0.0f;

        foreach (GameObject entity in collection)
        {
            Vector3 plaformXZ = new Vector3(entity.gameObject.transform.position.x, 0, entity.gameObject.transform.position.z);
            Vector3 originXZ = new Vector3(origin.x, 0, origin.z);
            distance = (plaformXZ - origin).sqrMagnitude;

            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = entity;
            }
        }

        return nearest;
    }
}
