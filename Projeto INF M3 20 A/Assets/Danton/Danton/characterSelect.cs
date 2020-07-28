using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSelect : MonoBehaviour
{
    public GameObject[] characters; //cria o vetor da quantidade de personagens.
    public static int characterIndex = 0; //cria o valor index da quantidade de personagens.
    void Awake()
    {
        Instantiate(characters[characterIndex], transform.position, Quaternion.identity); //instancia o personagem escolhido pelo index pegando seu transform e colocando na posição e rotação desejada.
    }

    void Update()
    {

    }

    public void ChangeCharacter(int index) //Função de seleção do personagem de acordo com o index.
    {

        characterIndex += index; //Index do personagem é maior ou igual ao inteiro index.
        if (characterIndex >= characters.Length)//Inicia a seleção dos personagens com index 0.
        {
            characterIndex = 0;
        }
        else if (characterIndex < 0)//Se index do personagem for menor que 0, diminui o index em -1.
        {
            characterIndex = characters.Length - 1;
        }
        for (int i = 0; i < characters.Length; i++)//Sendo valor de i igual a 0, se o valor de i for maior que o index de personagens, aumenta o index em +1.
        {
            if (i == characterIndex)//Se o valor de i for igual ao de index de personagem, ativa o personagem na cena.
            {
                characters[i].SetActive(true);
            }
            else
            {
                characters[i].SetActive(false);
            }
        }

        //Usado só se o game ter pontuação e vida, para iniciar a cena com a vida e pontuação resetada.

        //Player.health = 10;
        //Score.score = 0;
    }

    public void StartGame()
    {
        Application.LoadLevel("Jogo"); //Carrega o level inicial do jogo. 
    }
}
