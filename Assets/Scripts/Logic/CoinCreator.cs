using UnityEngine;

/// <summary>
/// 金币创建器
/// </summary>
public class CoinCreator
{
    /// <summary>
    /// 金币阵列预设
    /// </summary>
    private static GameObject[] s_coinListPrefab = new GameObject[2];

    /// <summary>
    /// 随机生成金币阵列
    /// </summary>
    public static void RandomCreate(Vector3 startPos)
    {
        var id = Random.Range(0, 2);
        if(null == s_coinListPrefab[id])
        {
            // 加载金币预设
            s_coinListPrefab[id] = Resources.Load<GameObject>("CoinList" + id);
        }
        // 实例化预设
        var coinListRoot = Object.Instantiate(s_coinListPrefab[id]);
        var coinBhv = coinListRoot.AddComponent<Coin>();
        // 设置初始坐标
        coinBhv.SetPos(startPos);
    }
}
