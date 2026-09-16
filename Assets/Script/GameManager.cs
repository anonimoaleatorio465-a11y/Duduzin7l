using UnityEngine;

using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int pontuacaoJogador1;

    public int pontuacaoJogador2; 

    public Text textodePontuacao ;

    public Text textoVencedor;

    public AudioSource somDoGol;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;


        pontuacaoJogador1 = 0;
        pontuacaoJogador2 = 0;
        textodePontuacao.text = pontuacaoJogador1 + " X " + pontuacaoJogador2;
        
        textoVencedor.text = "";   // Garante que não tenha nada escrito ao iniciar o jogo
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ReiniciarPartida ();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SairDoJogo ();
        }
    }

    public void AumentarPontuacaoJogador1()
    {
        pontuacaoJogador1 += 1;
        AtualizarTextoDePontuacao ();

        // ADICIONE O IF AQUI:
        // Verifica se o jogador 1 bateu 10 pontos
        if (pontuacaoJogador1 >= 10)
        {
            textoVencedor.text = "JOGADOR 1 VENCEU!";   // Escreve na tela
            Time.timeScale = 0;   // Pausa o jogo
        }

    }

    public void AumentarPontuacaoJogador2()
    {
        pontuacaoJogador2 += 1;
        AtualizarTextoDePontuacao ();

        // ADICIONE O IF AQUI:
        // Verifica se o jogador 2 bateu 10 pontos
        if (pontuacaoJogador2 >= 10)
        {
            textoVencedor.text ="JOGADOR 2 VENCEU!";   // Escreve na tela
            Time.timeScale = 0;   // Pausa o jogo
        }
    }

    public void AtualizarTextoDePontuacao()
    {
        textodePontuacao.text = pontuacaoJogador1 + " X " + pontuacaoJogador2;

        somDoGol.Play();
    }


    private void ReiniciarPartida()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene().name);
    }

    private void SairDoJogo()
    {
        Application.Quit ();
        Debug.Log("Saiu do Jogo");
    }


}