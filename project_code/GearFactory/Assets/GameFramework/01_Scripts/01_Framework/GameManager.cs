
using UnityEngine;

namespace BubbleFramework
{
    public class GameManager : Bubble_MonoSingle<GameManager>
    {
        [Bubble_Name("初始齿轮模型")]
        public GearAutoDrive autoGear;

        [Bubble_Name("传动齿轮")] public GearLinkDrive linkGear;
        void Awake()
        {
            BubbleFrameEntry.Awake();
            MsgMgr.Ins.CreateAutoGear(Vector3.zero);
            MsgMgr.Ins.CreateLinkGear(Vector3.zero);
            MsgMgr.Ins.CreateLinkGear(Vector3.zero);

        }

        void Update()
        {
            BubbleFrameEntry.Update(Time.deltaTime);
            MsgMgr.Ins.DoUpdate(Time.deltaTime);
        }
    }
}

