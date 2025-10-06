using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelSwipe : MonoBehaviour
{

    private bool levelCleared = false;
    private Vector2 startTouchPos;
    private Vector2 endTouchPos;
    public float swipeThreshold = 100f;
    
    void Update()
    {
        if (!levelCleared && GameObject.FindGameObjectsWithTag("Pig").Length == 0)
        {
            levelCleared = true;
            Debug.Log("Fase Completa! Deslize para a próxima fase ->");
        }

        if (levelCleared)
        {
            DetectSwipe();
        }
    }

    void DetectSwipe()
    {
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                    startTouchPos = touch.position;

                if (touch.phase == TouchPhase.Ended)
                {
                    endTouchPos = touch.position;
                    float swipeDistance = endTouchPos.x - startTouchPos.x;

                    if (swipeDistance > swipeThreshold)
                    {
                        LoadNextLevel();
                    }
                }
            }
        }
    }

    void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log("Carregando próxima fase...");
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("Todas as fases concluídas!");
        }
    }
}
