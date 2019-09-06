
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clientes : MonoBehaviour{
    public GameObject[] TodosAsReacoesBoas,TodosAsReacoesIndiferentes,TodosAsReacoesRuins;
    public GameObject ReacaoNaTela;
    public Vector3 PosicaoReacao;
    public void DestroiReacaoNaTela(){
        Destroy(ReacaoNaTela);
    }
    public void SelecionaReacao(string Satisfacao){
        if(Satisfacao == "Bom")
            SelecionaReacaoAleatoria(TodosAsReacoesBoas);
        else if(Satisfacao == "Indiferente")
            SelecionaReacaoAleatoria(TodosAsReacoesIndiferentes);
        else
            SelecionaReacaoAleatoria(TodosAsReacoesRuins);
    }
    private void SelecionaReacaoAleatoria(GameObject[] Reacao){
        int NumeroAleatorio = Random.Range(0,Reacao.Length);
        ReacaoNaTela = Instantiate(Reacao[NumeroAleatorio],PosicaoReacao,Quaternion.identity);
    }    
}
