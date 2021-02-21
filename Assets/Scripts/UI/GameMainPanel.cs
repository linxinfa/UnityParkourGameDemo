using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMainPanel : MonoBehaviour
{
    /// <summary>
    /// 跳跃按钮
    /// </summary>
    public Button jumpBtn;
    /// <summary>
    /// 金币文本
    /// </summary>
    public Text coinLbl;

    private void Awake()
    {
        EventDispatcher.instance.Regist(EventNameDef.EVENT_ADD_COIN, OnEventAddCoin);

        jumpBtn.onClick.AddListener(() =>
        {
            // 抛出事件
            EventDispatcher.instance.DispatchEvent(EventNameDef.EVENT_JUMP);

        });
    }

    private void OnDestroy()
    {
        EventDispatcher.instance.UnRegist(EventNameDef.EVENT_ADD_COIN, OnEventAddCoin);
    }

    /// <summary>
    /// 加金币事件，同步数值到UI
    /// </summary>
    /// <param name="args"></param>
    private void OnEventAddCoin(params object[] args)
    {
        coinLbl.text = ((int)args[0]).ToString();
    }
}
