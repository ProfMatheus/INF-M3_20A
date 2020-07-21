using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkHud : MonoBehaviour
{
    // O IP que ao qual se tentarar conectar.
    // 127.0.0.1 - ou "localhost" representa o próprio computador.
    public string EnderecoDeRede;
    // Direciona a porta lógica pela qual sera recebido as informações do serviço.
    public string PorteDoServico;

    // Depreciado (faz o posicionamento da interface em um elemento)
    public float GuiOffset;
    
    // Informa que o serviço foi iniciado
    private bool _iniciado;
    // marca se o construtor do serviço é um servidor (HOST) ou cliente
    private bool isClient;

    public void Start () {
        // Ao iniciar o projeto, deve-se manter desconectado, afinal quando o jogo inicia não temos uma conexão ao servidor estabelecida.
        _iniciado = false;
    }
    public void OnGUI () {
        GUILayout.Space ( GuiOffset );
        // Se o serviço não foi solicitado.
        if ( !_iniciado)
        {


            GUILayout.Space ( 25 );
            // coleta o endereço da rede. Pega da interface e adiciona a variavel.
            EnderecoDeRede = GUILayout.TextField (EnderecoDeRede, GUILayout.Width ( 100 ) );
            // coleta a porta do serviço. Pega da interface e adiciona a varíável.
            PorteDoServico = GUILayout.TextField (PorteDoServico, 5 );
            // ----------------------------------------------------------------------
            // HOST
            // ----------------------------------------------------------------------
            // Cria um botão de acesso para hospedar o serviço 
            if ( GUILayout.Button ( "Host" ) )
            {
                _iniciado = true;
                // indica que não´é um cliente
                isClient = false;
                // Acessa a classe de gerenciamento do serviço, via ele podemos iniciar a escuta da porta selecionada.
                // Define a porta responsavel pelo serviço.
                NetworkManager.singleton.networkPort = int.Parse (PorteDoServico);
                // Inicia a operação na interface de rede.
                NetworkManager.singleton.StartHost ();
            }
            // ----------------------------------------------------------------------

            // ----------------------------------------------------------------------
            // CLIENTE
            // ----------------------------------------------------------------------
            // Da o comando de inicio da ligação com o servidor
            if ( GUILayout.Button ( "Connect" ) )
            {
                _iniciado = true;
                // Indica que é um cliente.
                isClient = false;
                // Acessa a classe de gerenciamento do serviço, via ele podemos iniciar a escuta da porta selecionada.
                // Define o ip do servidor
                NetworkManager.singleton.networkAddress = EnderecoDeRede;
                // Define a porta responsavel pelo serviço.
                NetworkManager.singleton.networkPort = int.Parse (PorteDoServico);
                // Inicia a operação no cliente para trocar informações com  o servidor.
                NetworkManager.singleton.StartClient ();
            }
            // ----------------------------------------------------------------------
        }
        else
        {
            if ( GUILayout.Button ( "Disconnect" ) )
            {
                // define para o script que ele não esta mais conectado
                _iniciado = false;
                // para o serviço de escuta antes de parar a comunicação.
                if (isClient)
                    NetworkManager.singleton.StopClient();
                // desativa o serviço virtual na placa de rede
                NetworkManager.singleton.StopHost();

            }
        }
    }
}
