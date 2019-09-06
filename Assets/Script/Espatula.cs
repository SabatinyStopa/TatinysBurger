using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espatula : MonoBehaviour{

    public Ingredientes ingredientes;
    public ControleDoJogo controleDoJogo;
    private int VelocidadeDeMovimento = 9;
    private void Awake(){
        ingredientes = Object.FindObjectOfType<Ingredientes>();
        controleDoJogo = Object.FindObjectOfType<ControleDoJogo>();
    }
    void Update(){
        Movimenta();
    }
    private void Movimenta(){
        float EixoY = VelocidadeDeMovimento * Time.deltaTime;
        transform.Translate(0,EixoY,0);
    }
    private void OnCollisionEnter2D(Collision2D Objeto){
        if(!controleDoJogo.VerificaSeObstaculoFoiAtingido(Objeto.gameObject)){
            ingredientes.DestroiIngredientesParaAcertar();
            if(controleDoJogo.VerificaSeIngredienteAtingidoEstaCorreto(Objeto.gameObject))
                controleDoJogo.IngredienteCorretoAtingido();                   
            else
                controleDoJogo.IngredienteErradoAtingido();                  

            if(ingredientes.VerificaSeSequenciaDeIngredientesAcabou()){
                ingredientes.Contador = 0;            
                ChamaFuncaoQueMontaTela();
            }
            else
                ingredientes.CriaOsIngredientesParaAcertar();
        }
        Destroy(gameObject);
    }
    private void ChamaFuncaoQueMontaTela(){
        if(controleDoJogo.QuantidadeDeIngredientesCorretos == controleDoJogo.lanches.TamanhoIngredientesLanche)
            controleDoJogo.QuantidadeDeLanchesProntos++;
        controleDoJogo.CriaReacao();
        controleDoJogo.EsperaTempoDeReacaoNaTela();
        controleDoJogo.obstaculo.EscondeObstaculos(controleDoJogo.QuantidadeObstaculos,controleDoJogo.Obstaculos);
    }        
    private void OnBecameInvisible(){
        Destroy(gameObject);
    }
    
}
