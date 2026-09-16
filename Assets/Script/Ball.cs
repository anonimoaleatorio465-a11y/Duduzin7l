using System.Collections;
// using → libera acesso a um pacote de ferramentas de fora do arquivo
// System.Collections → pacote padrão do C# com ferramentas de listas e coleções (não está sendo usado ainda nesse script, mas o Unity cria por padrão)
// RESUMO: essa linha libera acesso a ferramentas de coleções do C#, mesmo não usando nenhuma delas aqui ainda

using UnityEngine;
// using → mesma função de sempre: liberar acesso a um pacote
// UnityEngine → pacote de ferramentas prontas da Unity (Vector2, Rigidbody2D, MonoBehaviour, Random, etc.)
// RESUMO: essa linha libera acesso a todas as ferramentas principais da Unity usadas no script

using UnityEngine.InputSystem;
// using → libera acesso a um pacote de ferramentas de fora do arquivo
// UnityEngine.InputSystem → pacote específico da Unity pra ler teclado, mouse e controle pelo "novo" sistema de input
// RESUMO: essa linha libera acesso às ferramentas de leitura de teclado/controle (usada no seu outro script, PlayersControler; aqui no Ball não é usada ainda)


public class Ball : MonoBehaviour
// public → qualquer script do projeto pode enxergar essa classe
// class Ball → cria o molde chamado Ball
// : MonoBehaviour → herda os poderes de virar componente do Unity (Start, Update, OnTriggerEnter2D funcionando sozinhos)
// RESUMO: essa linha cria o molde Ball, visível a todo o projeto, já pronto pra ser anexado num objeto da cena
{
    // =========================================================================
    // PASSO 1: O PAINEL DE CONTROLE (VARIÁVEIS)
    // -------------------------------------------------------------------------
    // O que é: Funciona como o painel de configurações da bolinha.
    // 
    // O que ele faz: Cria espaços lá na tela da Unity para você ajustar a 
    // velocidade da bola, a força do desvio e conectar o áudio do jogo,
    // além de reservar a gaveta do "motor de física" (o Rigidbody2D).
    // =========================================================================

    public float velocidade = 5f;
    // public → editável no Inspector do Unity
    // float → número com casas decimais
    // velocidade → nome da caixinha
    // = 5f → valor inicial, 5
    // RESUMO: cria a caixinha velocidade, ajustável no Inspector, que controla o quão rápido a bola se move

    public float direcaoAleatoriaX;
    // public → deixa a variável visível e editável no painel Inspector da Unity
    // float → tipo da variável, significa que aceita números com casas decimais (ex: 1.5)
    // direcaoAleatoriaX → o nome que você deu para essa caixinha
    // RESUMO: cria uma caixinha no Inspector para você digitar a força do desvio na horizontal (esquerda/direita)

    public float direcaoAleatoriaY;
    // public → deixa a variável visível e editável no painel Inspector da Unity
    // float → tipo da variável, significa que aceita números com casas decimais (ex: 1.5)
    // direcaoAleatoriaY → o nome que você deu para essa caixinha
    // RESUMO: cria uma caixinha no Inspector para você digitar a força do desvio na vertical (cima/baixo)

    Rigidbody2D rb;
    // Rigidbody2D → tipo: peça de física 2D
    // rb → nome da caixinha, ainda vazia
    // RESUMO: reserva a caixinha rb, que vai guardar a peça de física da bola assim que o jogo iniciar

    public AudioSource somDaBola;
    // public → cria um espaço vazio no Inspector da Unity
    // AudioSource → é o "tocador de som" da Unity (a peça que emite o áudio)
    // somDaBola → o nome da caixinha que vai guardar esse tocador
    // RESUMO: cria um espaço no Inspector onde você vai arrastar e conectar o componente de som da sua bolinha, para o código saber quem mandar tocar.


    // =========================================================================
    // PASSO 2: A PARTIDA (EVENTO START)
    // -------------------------------------------------------------------------
    // O que é: O exato instante em que o jogo começa a rodar.
    // 
    // O que ele faz: Primeiro, ele vasculha a bolinha procurando o motor de
    // física (Rigidbody2D) e guarda na gaveta. Depois, ele aperta o botão de 
    // "Lancar" para dar o primeiro empurrão na bola e o jogo começar.
    // =========================================================================

    void Start ()
    // void → só executa ação, não devolve valor
    // Start () → roda uma única vez, sozinho, quando o objeto entra em cena
    {
        rb = GetComponent < Rigidbody2D > ();
        // rb = → guarda o resultado da direita na caixinha rb
        // GetComponent → busca uma peça (componente) anexada ao próprio objeto
        // < Rigidbody2D > → especifica que o tipo de peça procurada é o Rigidbody2D
        // () → executa a busca agora
        // RESUMO: essa linha pega a peça de física grudada na Bolinha_0 e guarda na caixinha rb

        Lancar ();
        // Lancar () → executa o bloco definido em "void Lancar ()" logo abaixo
        // RESUMO: dispara o primeiro lançamento da bola assim que o jogo começa
    }


    // =========================================================================
    // PASSO 3: A AÇÃO DE JOGAR A BOLA (EVENTO PERSONALIZADO)
    // -------------------------------------------------------------------------
    // O que é: Uma ação que você mesmo criou. Só roda se for chamada.
    // 
    // O que ele faz: Sorteia cara ou coroa (esquerda ou direita), sorteia 
    // uma inclinação, e aplica um "chute" (força matemática) na física da 
    // bola para ela sair voando pela tela.
    // =========================================================================

    void Lancar ()
    // void Lancar () → cria o "botão" Lancar, com ações guardadas dentro pra ser chamado quando precisar
    {
        float x = Random.value < 0.5f ? -1 : 1;
        // Random.value → sorteia um número entre 0 e 1
        // < 0.5f → pergunta se esse número é menor que 0.5
        // ? -1 : 1 → se sim, x recebe -1 (esquerda); se não, recebe 1 (direita)
        // RESUMO: decide aleatoriamente se a bola vai sair pra esquerda ou pra direita

        float y = Random.Range (-0.5f , 0.5f);
        // Random.Range (-0.5f, 0.5f) → sorteia um número decimal dentro desse intervalo
        // float y = → guarda esse número na caixinha y
        // RESUMO: decide aleatoriamente o quanto a bola sai inclinada pra cima ou pra baixo

        rb.linearVelocity = new Vector2 (x, y).normalized * velocidade;
        // new Vector2 (x, y) → cria uma seta de direção usando os valores sorteados
        // .normalized → padroniza o tamanho da seta pra 1
        // * velocidade → multiplica pela força guardada em velocidade
        // rb.linearVelocity = → aplica essa força final na peça de física, movendo a bola de verdade
        // RESUMO: calcula a direção sorteada e faz a bola sair andando com a velocidade definida
    }
    
    
    // =========================================================================
    // PASSO 4: O JUIZ DO GOL (EVENTO ONTRIGGERENTER2D)
    // -------------------------------------------------------------------------
    // O que é: O fiscal das áreas invisíveis.
    // 
    // O que ele faz: Toda vez que a bola cruza as áreas "fantasmas" que 
    // você colocou atrás das raquetes, ele grita "Gol!". Ele então pega a bola, 
    // teleporta pro centro, para ela totalmente (zera a força) e joga de novo.
    // =========================================================================

    void OnTriggerEnter2D(Collider2D other)
    // OnTriggerEnter2D → nome reservado que o Unity dispara sozinho ao tocar um Collider marcado "Is Trigger"
    // (Collider2D other) → caixinha preenchida automaticamente pelo Unity, com dados do objeto tocado
    // RESUMO: esse bloco inteiro roda sozinho toda vez que a bola encosta em algo do tipo trigger
    { 
        if (other.gameObject.name == "Gol Jogador 1" || other.gameObject.name == "Gol Jogador 2")
        // other.gameObject → o objeto que a bola tocou
        // .name → o nome desse objeto
        // == "Gol Jogador 1" → compara se é exatamente esse nome
        // || → "ou", testa a segunda comparação se a primeira for falsa
        // == "Gol Jogador 2" → compara se é esse outro nome
        // RESUMO: verifica se o objeto tocado foi um dos dois gols
        {

            transform.position = Vector2.zero;
            // transform.position → localização atual do objeto
            // Vector2.zero → coordenada (0, 0), o centro da tela
            // = → substitui a posição atual pela nova
            // RESUMO: teleporta a bola de volta pro centro exato da tela

            rb.linearVelocity = Vector2.zero;
            // rb.linearVelocity → velocidade atual da peça de física
            // Vector2.zero → aqui representa "nenhuma força"
            // = → zera a velocidade
            // RESUMO: parar a bola completamente antes de relançar

            Lancar ();
            // Lancar () → chama de novo o botão de lançar
            // RESUMO: sorteia uma nova direção e começa a próxima rodada
        }

    }   // <- ESTA É A CHAVE QUE FECHA O ONTRIGGERENTER


    // =========================================================================
    // PASSO 5: O IMPACTO FÍSICO (EVENTO ONCOLLISIONENTER2D)
    // -------------------------------------------------------------------------
    // O que é: A batida real e física.
    // 
    // O que ele faz: A Unity avisa a bola sempre que ela bate em algo sólido 
    // (raquete, teto ou chão). Quando isso acontece, este bloco toca a música 
    // de batida e empurra a bola só um pouquinho torta para ela não bugar 
    // ficando presa num quique infinito em linha reta.
    // =========================================================================
    
    void OnCollisionEnter2D (Collision2D collisionInfo)
    {
        // Comando para tocar o som toda vez que a bola bater em algo sólido
        somDaBola.Play();

        rb.linearVelocity += new Vector2(direcaoAleatoriaX, direcaoAleatoriaY);
        // rb.linearVelocity → acessa a velocidade atual da peça de física da bola
        // += → operador matemático que significa "pegue o que já tem e SOME mais isso"
        // new Vector2( ... ) → cria uma nova força empurrando em duas direções (X e Y) ao mesmo tempo
        // direcaoAleatoriaX, direcaoAleatoriaY → os valores que você digitou lá no Inspector sendo injetados aqui
        // RESUMO: pega a velocidade que a bola já tem no momento do impacto e adiciona um "empurrãozinho" extra usando os valores de X e Y. Isso evita que a bola fique presa rebatendo sempre no mesmo ângulo reto!
        
    }


}   // <- ESTA É A ÚLTIMA CHAVE DO ARQUIVO (FECHA A CLASSE BALL)