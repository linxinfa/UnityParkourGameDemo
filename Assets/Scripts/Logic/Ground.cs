using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private Transform groundTranform;
    /// <summary>
    /// 地面移动的结束位置
    /// </summary>
    private Transform end;
    /// <summary>
    /// 地面移动的起始位置
    /// </summary>
    private Transform start;
    /// <summary>
    /// 地面的移动速度
    /// </summary>
    private float moveSpeed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        groundTranform = transform;
        end = GameObject.Find("GroundEndPos").transform;
        start = GameObject.Find("GroundStartPos").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.Playing != GameMgr.instance.state) return;

        if (groundTranform.position.x > end.position.x)
        {
            groundTranform.position -= new Vector3(moveSpeed, 0, 0);//往左移动
        }
        else//到达结束点
        {
            BackToStart();
        }
    }

    /// <summary>
    /// 回到起始点
    /// </summary>
    void BackToStart()
    {
        float yPosOffset = Random.Range(3, 20) * 0.1f; //随机高度偏移
        float xPosOffset = Random.Range(5, 15) * 0.1f; //随机水平偏移
        groundTranform.position = start.position + new Vector3(xPosOffset,  yPosOffset, 0);

        // 随机生成金币
        CoinCreator.RandomCreate(groundTranform.position);
    }
}
