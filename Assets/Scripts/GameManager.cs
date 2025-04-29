using UnityEngine;

public enum GameState { Start, Playing, GameOver }

public class GameManager : MonoBehaviour
{
    public static GameManager I;          // quick singleton
    public static GameState State { get; private set; }

    void Awake()
    {
        if (I != null) { Destroy(gameObject); return; }
        I = this; DontDestroyOnLoad(gameObject);
        ChangeState(GameState.Start);
    }

    public void StartGame() => ChangeState(GameState.Playing);
    public void GameOver() => ChangeState(GameState.GameOver);

    void ChangeState(GameState s)
    {
        State = s;
        Time.timeScale = (s == GameState.Playing) ? 1 : 0;   // pause on menus
        // TODO: toggle UI panels here once you create them
    }
}
