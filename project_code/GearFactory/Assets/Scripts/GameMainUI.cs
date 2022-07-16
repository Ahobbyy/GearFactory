using System.Collections;
using System.Collections.Generic;
using BubbleFramework.Bubble_Event;
using BubbleFramework.Bubble_UI;
using GameFramework._01_Scripts._03_Setting;
using UnityEngine.UI;
using EventType = UnityEngine.EventType;

public class GameMainUI : UI_Base<Test_01Content>
{
    [Bubble_Name("描述", Describe = "这个是描述")]
    public Text _des;

    public override void Init()
    {
        base.Init();
        UiType = UIType.Normal;
    }

    public override void SetContent(UI_BaseContent content)
    {
        base.SetContent(content);
        //_des.text = UiBaseContent.des;
    }
    
}

public class GameMainUIContent : UI_BaseContent
{
}