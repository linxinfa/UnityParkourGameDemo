
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public Button restartBtn;

    void Start()
    {
        restartBtn.onClick.AddListener(() => 
        {
            GameMgr.instance.state = GameState.Playing;
            SceneManager.LoadScene(0);
        });
    }
}
