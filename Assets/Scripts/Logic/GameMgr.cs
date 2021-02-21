using UnityEngine;

public class GameMgr : MonoBehaviour
{
    private void Awake()
    {
        s_instance = this;
        m_state = GameState.Playing;
        score = 0;
    }

    public GameState state
    {
        get { return m_state; }
        set
        {
            m_state = value;
            if(GameState.End == value)
            {
                // 游戏结束
                var canvas = GameObject.Find("Canvas");
                var prefab = Resources.Load("GameOverPanel");
                var panel = GameObject.Instantiate(prefab) as GameObject;
                panel.transform.SetParent(canvas.transform, false);
            }
        }
    }

    private GameState m_state = GameState.Ready;
    public int score
    {
        get { return m_score; }
        set 
        {
            if (value != m_score)
                EventDispatcher.instance.DispatchEvent(EventNameDef.EVENT_ADD_COIN, value);
            m_score = value; 
        }
    }
    private int m_score;


    private static GameMgr s_instance;
    public static GameMgr instance { get { return s_instance; } }
}

public enum GameState
{
    Ready,
    Playing,
    End,
}
