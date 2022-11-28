using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotor : Rotation
{
    [SerializeField]
    private float newSpeed;

    public void Update()
    {
        Rotating();
    }

    public override void Rotating()
    {
        RotationSpeed = newSpeed;
        base.Rotating();
    }

}
