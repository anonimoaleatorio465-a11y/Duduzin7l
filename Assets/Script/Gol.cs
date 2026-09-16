using System.Collections;
// using → libera acesso a um pacote de ferramentas de fora do arquivo
// System.Collections → pacote padrão do C# com ferramentas de listas e coleções
// RESUMO: libera acesso a ferramentas de coleções, mesmo não sendo usadas diretamente aqui

using UnityEngine;
// using → libera acesso a um pacote
// UnityEngine → pacote com as ferramentas principais da Unity (Vector2, MonoBehaviour, Time, etc.)
// RESUMO: libera acesso às ferramentas básicas da Unity usadas neste script

using UnityEngine.InputSystem;
// using → libera acesso a um pacote
// UnityEngine.InputSystem → pacote específico da Unity pra ler teclado, mouse e controle pelo sistema novo de input
// RESUMO: libera acesso ao Keyboard.current, usado mais abaixo pra detectar teclas pressionadas

public class Gol : MonoBehaviour
{

    public bool GolJogador1 ;

    public bool jogador1 = true;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (GolJogador1 == true)
        {
            FindAnyObjectByType<GameManager>().AumentarPontuacaoJogador2() ;
            other.gameObject.transform.position = Vector2.zero ;

        }

        else
        {
            FindAnyObjectByType<GameManager>().AumentarPontuacaoJogador1() ;
            other.gameObject.transform.position = Vector2.zero ;
        }
    }
}