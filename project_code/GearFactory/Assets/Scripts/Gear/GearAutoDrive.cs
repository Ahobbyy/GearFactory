using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearAutoDrive : GearDriveBase
{
    [Bubble_Name("线速度")]
    public float gearLineSpeed;
    [Bubble_Name("旋转方向  1顺 -1逆")]
    public int directionLine = 1;
    public override bool canBeDrived => false;

    public override void Init()
    {
        base.Init();
        Drive(gearLineSpeed,directionLine);
    }
    

   
}
