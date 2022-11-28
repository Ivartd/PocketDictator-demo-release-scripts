using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rotation : MonoBehaviour
{
    public float RotationSpeed { get; protected set; } = 2f;

    /*public Rotation(int rotationSpeed)
    {
        RotationSpeed = rotationSpeed;
    }*/

    public virtual void Rotating()
    {
        transform.Rotate(0, 0, 360 * RotationSpeed * Time.deltaTime);
    }

}
