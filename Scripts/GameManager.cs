using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int totalBirds = 3;
    public int totalPigs;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        totalPigs = GameObject.FindGameObjectsWithTag("Pig").Length;
    }

    public void BirdLaunched()
    {
        totalBirds--;
        Invoke("CheckDefeat", 6f);
    }

    public void PigDestroyed()
    {
        totalPigs--;
        if (totalPigs <= 0)
            Victory();
    }


    void CheckDefeat()
    {
        if (totalBirds <= 0 && totalPigs > 0)
            Defeat();
    }

    void Victory()
    {
        Debug.Log("Vitória!");
    }

    void Defeat()
    {
        Debug.Log("Derrota!");
    }
}
