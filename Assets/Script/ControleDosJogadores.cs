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


public class PlayersControler : MonoBehaviour
// public → qualquer script do projeto pode enxergar essa classe
// class PlayersControler → cria o molde chamado PlayersControler
// : MonoBehaviour → herda os poderes de virar componente do Unity
// RESUMO: cria o molde PlayersControler, pronto pra ser anexado em qualquer raquete da cena
{
    // =========================================================================
    // PASSO 1: O PAINEL DE CONTROLE (VARIÁVEIS)
    // -------------------------------------------------------------------------
    // O que é: Funciona como o painel do seu carro.
    // 
    // O que ele faz: Cria opções que aparecem lá na tela da Unity para você 
    // configurar o jogo facilmente (ex: ajustar a velocidade da raquete ou 
    // escolher de quem é essa raquete) sem precisar abrir o código de novo.
    // =========================================================================
    
    public float velocidade = 5f;
    // public → editável no Inspector
    // float → número com casas decimais
    // velocidade → nome da caixinha
    // = 5f → valor inicial, 5
    // RESUMO: cria a caixinha velocidade, que controla o quão rápido a raquete se move

    public bool jogador1 = true;
    // public → editável no Inspector
    // bool → tipo que só aceita true ou false
    // jogador1 → nome da caixinha
    // = true → valor inicial: começa marcado como "sim, é o jogador 1"
    // RESUMO: cria um interruptor que decide se essa instância controla o jogador 1 (WASD) ou o jogador 2 (setas)

    
    public float margemX = 1f;
    // Cria uma variável para ajustar a distância da borda. Como é 'public', você pode mudar o valor lá na Unity.



    // =========================================================================
    // PASSO 2: A PARTIDA (EVENTO START)
    // -------------------------------------------------------------------------
    // O que é: É o momento de "girar a chave" do carro.
    // 
    // O que ele faz: Roda uma única vez no momento exato em que o jogo começa.
    // Aqui ele está vazio porque nossas raquetes não precisam fazer nada 
    // especial na hora que o jogo liga, elas só precisam esperar o jogador.
    // =========================================================================
    
    void Start()
    // void → só executa ação, não devolve valor
    // Start() → roda uma única vez, quando o objeto entra em cena
    // RESUMO: vazio aqui — nenhuma ação programada pro início
    {
        // 1. Screen.width pega o tamanho máximo da tela do monitor em pixels (ex: 1920).
        // 2. Camera.main.ScreenToWorldPoint pega esse número e converte para as coordenadas do mapa do jogo.
        // 3. O resultado é salvo na variável 'bordaDireita'.
        Vector3 bordaDireita = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, 0, 0));

        // O script verifica de quem é este objeto (se é o Jogador 1 / Gol 1). 
        // ATENÇÃO: Substitua 'jogador1' pelo nome exato da variável que você usou no seu código!
        if (jogador1 == true)
        {
            // Se for o lado esquerdo:
            // Pega a coordenada da borda, coloca o sinal de menos (-) para espelhar para o lado esquerdo da tela.
            // Soma a '+ margemX' para empurrar o objeto um pouquinho para dentro do campo.
            // Mantém a altura atual usando o 'transform.position.y'.
            transform.position = new Vector2 (-bordaDireita.x + margemX, transform.position.y);
            
        }
        else
        {
            transform.position = new Vector2 (bordaDireita.x - margemX, transform.position.y);
        }

        
    }


    // ========================================================================
    // PASSO 3: O MOTOR LIGADO (EVENTO UPDATE)
    // -------------------------------------------------------------------------
    // O que é: É o motor girando sem parar. Roda várias vezes por segundo.
    // 
    // O que ele faz: Fica vigiando o jogo o tempo todo para fazer duas coisas:
    // 1º - Travar a raquete para ela não fugir pelos limites da tela.
    // 2º - Ver de quem é a raquete (Jog 1 ou 2) e chamar o controle certo abaixo.
    // =========================================================================
    
    void Update()
    // void → só executa ação
    // Update() → roda sozinho, repetidamente, a cada frame do jogo
    // RESUMO: esse bloco roda várias vezes por segundo, o tempo todo, enquanto o jogo está rodando
    {   
        Vector2 posicaoAtual = transform.position;
        // Vector2 → tipo de dado que guarda duas coordenadas ao mesmo tempo (X e Y)
        // posicaoAtual → o nome da caixinha temporária que você criou para guardar essas coordenadas
        // = transform.position → copia a localização exata de onde o jogador está na tela neste momento
        // RESUMO: tira uma "foto" da posição atual do jogador (X e Y) e guarda na caixinha para podermos fazer os cálculos com segurança.

        posicaoAtual.y = Mathf.Clamp (posicaoAtual.y, -3.9f, 3.9f);
        // posicaoAtual.y → acessa especificamente a coordenada vertical (cima/baixo) dentro da nossa caixinha
        // = → avisa que esse valor de Y será alterado
        // Mathf.Clamp( ... ) → ferramenta matemática da Unity que "grampeia" (trava) um número dentro de um limite
        // (posicaoAtual.y, -3.9f, 3.9f) → a regra da trava: pega a posição Y atual, e não deixa ela ser menor que o chão (-3.9) nem maior que o teto (3.9)
        // RESUMO: analisa se o jogador passou do limite. Se ele tentou ir para a posição 5, essa linha força o número de volta para 3.9.

        transform.position = posicaoAtual;
        // transform.position → acessa a posição real do objeto (jogador) na tela da Unity
        // = posicaoAtual → substitui a posição real dele pela posição da nossa caixinha (que acabou de ser corrigida na linha de cima)
        // RESUMO: devolve os valores pro jogador. Se ele tentou sair da tela, essa linha teleporta ele quase instantaneamente de volta pro limite permitido.

        if (jogador1 == true)
        // if → testa uma condição
        // jogador1 == true → pergunta se a caixinha jogador1 está marcada como verdadeira
        // RESUMO: verifica se essa instância é a do jogador 1
        {
            MoverJogador1();
            // MoverJogador1() → executa o bloco definido mais abaixo
            // RESUMO: se for o jogador 1, chama a função que lê W e S
        }
        else
        // else → executa isso se a condição do if for falsa
        {
            MoverJogador2();
            // MoverJogador2() → executa o bloco definido mais abaixo
            // RESUMO: se não for o jogador 1, chama a função que lê as setas
        }
    }


    // =========================================================================
    // PASSO 4: OS PEDAIS E O VOLANTE (EVENTOS PERSONALIZADOS)
    // -------------------------------------------------------------------------
    // O que é: São os comandos de direção que você mesmo inventou. A Unity 
    // não liga para eles sozinhos, só funcionam porque o Update manda ligar.
    // 
    // O que ele faz: Fica lendo o seu teclado. Se você apertar a tecla certa 
    // (W/S ou Setas), ele faz a matemática de empurrar a raquete para cima ou 
    // para baixo na tela.
    // =========================================================================
    
    private void MoverJogador1()
    // private → só pode ser chamado de dentro deste mesmo script
    // void MoverJogador1() → cria o botão MoverJogador1
    // RESUMO: define a função que move a raquete do jogador 1 pelo teclado
    {
        if (Keyboard.current.wKey.isPressed)
        // Keyboard.current → pega o teclado ativo agora
        // .wKey → acessa a tecla W
        // .isPressed → pergunta se está pressionada agora
        // RESUMO: verifica se o jogador está segurando W
        {
            
            // transform.Translate(...) → move o objeto na direção/distância informada
            // Vector2.up → atalho pra "pra cima" (0, 1)
            // * velocidade → multiplica pela força guardada em velocidade
            // * Time.deltaTime → multiplica pelo tempo desde o último frame, garantindo velocidade igual em qualquer PC
            // RESUMO: move a raquete pra cima, numa velocidade constante, enquanto W estiver pressionada
        }
        if (Keyboard.current.sKey.isPressed)
        // mesma lógica de cima, verificando a tecla S
        // RESUMO: verifica se o jogador está segurando S
        {
            transform.Translate(Vector2.down * velocidade * Time.deltaTime);
            // Vector2.down → atalho pra "pra baixo" (0, -1)
            // RESUMO: move a raquete pra baixo, mesma lógica de cima
        }
    }

    private void MoverJogador2()
    // private void MoverJogador2() → cria o botão MoverJogador2, exclusivo deste script
    // RESUMO: define a função que move a raquete do jogador 2 pelas setas
    {
        if (Keyboard.current.upArrowKey.isPressed)
        // verifica se a seta pra cima está pressionada agora
        // RESUMO: checa se o jogador está segurando a seta pra cima
        {
            transform.Translate(Vector2.up * velocidade * Time.deltaTime);
            // RESUMO: move a raquete pra cima, mesma lógica do jogador 1
        }
         if (Keyboard.current.downArrowKey.isPressed)
        // verifica se a seta pra baixo está pressionada agora
        // RESUMO: checa se o jogador está segurando a seta pra baixo
        {
            transform.Translate(Vector2.down * velocidade * Time.deltaTime);
            // RESUMO: move a raquete pra baixo, mesma lógica do jogador 1
        }
    }
}