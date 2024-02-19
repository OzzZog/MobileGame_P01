using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public BreakableObject Spawn(BreakableObject breakableObjectPrefab, Transform location)
    {
        // spawn and hold on to the component type
        BreakableObject newBreakableObject = Instantiate(breakableObjectPrefab, location.position, location.rotation);
        //TODO do setup here if needed, spawn effects, etc.
        return newBreakableObject;
    }
}
