using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarCena : MonoBehaviour
{

    public void CarregarCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }

    public void IrParaOJogo()
    {
        SceneManager.LoadScene("JogoAngryBirds");
    }

    public void SelecionarFase()
    {
        SceneManager.LoadScene("SeleçãoDeFases");
    }

    public void Fase2()
    {
        SceneManager.LoadScene("Fase2");
    }

    public void Fase3()
    {
        SceneManager.LoadScene("Fase3");
    }

    public void Fase4()
    {
        SceneManager.LoadScene("Fase4");
    }

    public void IrParaTelaDeTitulo()
    {
        SceneManager.LoadScene("TelaDeTitulo");
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }
    
}
