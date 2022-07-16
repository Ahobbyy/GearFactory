using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BubbleFramework;
using UnityEngine;

public class MsgMgr
{

    private static MsgMgr m_ins;

    public static MsgMgr Ins
    {
        get
        {
            if (m_ins == null)
            {
                m_ins = new MsgMgr();
            }

            return m_ins;
        }
    }
    public List<GearDriveBase> gearDrives;

    public List<GearAutoDrive> gearAutoDrives;
    public MsgMgr()
    {
        gearDrives = new List<GearDriveBase>();
        gearAutoDrives = new List<GearAutoDrive>();
    }


    public void CreateAutoGear(Vector3 gearPos)
    {
        var autoGear = CreateGear(gearPos,GameManager.Instance.autoGear);
        gearAutoDrives.Add(autoGear);
    }
    
    public void CreateLinkGear(Vector3 gearPos)
    {
        CreateGear(gearPos,GameManager.Instance.linkGear);
    }

    /// <summary>
    /// 创建齿轮
    /// </summary>
    private T CreateGear<T>(Vector3 gearPos , T gear) where  T : GearDriveBase
    {
        var gearModel =  GameObject.Instantiate(gear);
        gearModel.transform.position = gearPos;
        gearModel.Init();
        gearDrives.Add(gearModel);
        return gearModel;
    }

    public void DoUpdate(float dt)
    {
       
        for (int i = gearDrives.Count - 1; i >= 0; i--)
        {
            //清楚传动参数
            if (gearDrives[i].canBeDrived && gearDrives[i].beDrived)
            {
                gearDrives[i].beDrived = false;
            }
        }
        
        //传动
        for (int i = gearAutoDrives.Count - 1; i >= 0; i--)
        {
            DriveGear(gearAutoDrives[i]);
        }
        
        for (int i = gearDrives.Count - 1; i >= 0; i--)
        {
            gearDrives[i].DoUpdate(dt);
        }
    }
    
    //传动
    public void DriveGear(GearDriveBase gear)
    {
        var outRasts = Physics.SphereCastAll(gear.transform.position + new Vector3(0, 0, -gear.width * 0.5f),
            gear.gearRadius + gear.gearModulusWidth, gear.transform.forward);
        var inRasts = Physics.SphereCastAll(gear.transform.position + new Vector3(0, 0, -gear.width * 0.5f),
            gear.gearRadius, gear.transform.forward);
        for (int i = 0; i < outRasts.Length; i++)
        {
            if (outRasts[i].collider!=null && !inRasts.Contains(outRasts[i]))
            {
                var driveGear = outRasts[i].collider.GetComponentInParent<GearDriveBase>();
                if (driveGear && driveGear.canBeDrived && !driveGear.beDrived)
                {
                    driveGear.Drive(gear.driveLineSpeed,-1 * gear.direction);
                    DriveGear(driveGear);
                }
            }
        }
    }
}
