using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
/// <summary>
/// Esta classe utiliza uma variação do monoBehaviours para gerenciar as conexões
/// <see cref="NetworkBehaviour"/>
/// </summary>
public class PlayerController : NetworkBehaviour {
    
	void Update () {

        if ( isLocalPlayer )
        {
            if ( Input.GetKeyDown ( KeyCode.M ) )
                CmdSendAction ( " say: Hello" );

        }
    }
    /// <summary>
    /// Determina uma ação para o personagem do cliente.
    /// DEBUG, informa a ação do jogador para o serviço
    /// 1 - Escolhe uma das ações disponiveis para o cliente executar
    /// 2 - O personagem para de obedecere o sistema de movimentação manual.
    /// 3 - O personagem usa o pathfinder para andar até o local da sua ação.
    /// </summary>
    [Command]
    private void CmdSendAction (string _command) {
        //if (isServer)
            Debug.Log ( "Server get from Cliente " + base.netId + " action is: " + _command );
    }

    public override void OnStartLocalPlayer () {
        GetComponent<MeshRenderer> ().material.color = Color.blue;
    }

}
