using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GearDriveBase : MonoBehaviour
{
    [Bubble_Name("齿轮半径")]
    public float gearRadius;

    [Bubble_Name("模数宽")] public float gearModulusWidth;

    [Bubble_Name("厚度")] public float width;

    public bool beDrived;

    public float driveLineSpeed;
    public int direction;
    public abstract bool canBeDrived { get; }

    public virtual void Init()
    {
        
    }

    public virtual void Drive(float lineSpeed , int dir)
    {
        beDrived = true;
        driveLineSpeed = lineSpeed;
        direction = dir;
    }


    public virtual void DoUpdate(float dt)
    {
        if (beDrived)
        {
            var angleSpeed = driveLineSpeed / gearRadius;
            transform.Rotate(transform.forward,direction * angleSpeed * dt);
        }
    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,gearRadius);
        Gizmos.DrawWireSphere(transform.position,gearRadius + gearModulusWidth);
        Gizmos.DrawWireCube(transform.position,new Vector3(gearRadius,gearRadius,width));
    }
#endif
}
