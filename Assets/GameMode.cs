using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    public PlayerController m_PlayerController;
    private int m_BrickCount;
    public int Lives = 3;
    private int m_CurrentLives;

    private int m_Points;

    public GameObject BallPrefab;
    public GameObject BallStart;

    private void Start()
    {
        ResetGame();
    }

    private void BrickDestroyed() {
        m_BrickCount--;
        m_Points++;

        if (m_BrickCount <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.gameObject.tag;

        if (tag == "Ball")
        {
            m_CurrentLives--;

            if (m_CurrentLives <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                //GAME OVER
                ResetGame();
            }
        }
    }

    void ResetGame() {
        m_CurrentLives = Lives;
        m_Points = 0;

        GameObject ball = Instantiate(BallPrefab, BallStart.transform.position,Quaternion.identity);
        

        GameObject[] Bricks = GameObject.FindGameObjectsWithTag("Brick");

        m_BrickCount = Bricks.Length;

        foreach (GameObject obj in Bricks)
        {
            BrickBase brick = obj.GetComponent<BrickBase>();
            brick.BindEvent(BrickDestroyed);
        }


    }
}
