using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// 跳跃次数
    /// </summary>
    private int m_jumpCount = 0;

    private Animator m_ani;
    private Rigidbody2D m_rig;

    /// <summary>
    /// 一段跳速度
    /// </summary>
    public float JumpSpeed = 20;
    /// <summary>
    /// 二段跳速度
    /// </summary>
    public float SecondJumpSpeed = 15;

    private void Awake()
    {
        EventDispatcher.instance.Regist(EventNameDef.EVENT_JUMP, OnEventJump);
    }

    private void OnDestroy()
    {
        EventDispatcher.instance.UnRegist(EventNameDef.EVENT_JUMP, OnEventJump);
    }

    void Start()
    {
        m_ani = gameObject.GetComponent<Animator>();
        m_rig = gameObject.GetComponent<Rigidbody2D>();
    }


    void OnEventJump(params object[] args)
    {
        if (0 == m_jumpCount)   //一段
        {
            m_ani.SetBool("IsJumping1", true);
            m_rig.velocity = new Vector2(0, JumpSpeed);
            ++m_jumpCount;
        }
        else if (1 == m_jumpCount)  //二段
        {
            m_ani.SetBool("IsJumping2", true);
            m_rig.velocity = new Vector2(0, SecondJumpSpeed);
            ++m_jumpCount;
        }
    }

    void Update()
    {
        if (GameState.Playing != GameMgr.instance.state) return;

        // 按下空白键
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnEventJump();
        }
    }

    /// <summary>
    /// 触发器事件
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ("Coin" == collision.gameObject.tag)
        {
            // 吃到金币
            Destroy(collision.gameObject);
            GameMgr.instance.score++;
        }
    }

    /// <summary>
    /// 碰撞事件方法
    /// </summary>
    /// <param name="other"></param>
	void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Ground":
                {
                    // 碰撞到地面
                    m_ani.SetBool("IsJumping1", false);
                    m_ani.SetBool("IsJumping2", false);

                    m_jumpCount = 0;
                }
                break;
            case "Border":
                {
                    // 游戏结束
                    GameMgr.instance.state = GameState.End;
                }
                break;
        }

    }
}
