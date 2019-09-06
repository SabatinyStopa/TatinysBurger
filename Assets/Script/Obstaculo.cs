using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour{

    public int Velocidade;
    public GameObject obstaculo;
    public Cozinheiro cozinheiro;
    public void EscondeObstaculos(int QuantidadeObstaculos, GameObject[] Obstaculos){
        for(int i = 0; i < QuantidadeObstaculos; i++)
            Obstaculos[i].SetActive(false);
    }
    public void FazAparecerObstaculos(int QuantidadeObstaculos,GameObject[] Obstaculos){
        for(int i = 0; i < QuantidadeObstaculos; i++)
            Obstaculos[i].SetActive(true);
    }    
    private void Update() {
        Movimentacao();
    }
    private void Movimentacao(){
        float x = Velocidade * Time.deltaTime;
        transform.Translate(-x,0,0);
    }
    private void OnCollisionEnter2D(Collision2D Outro){
        if(Outro.gameObject.tag == "Limite")
            ViraPosicao();
        else{
            cozinheiro.DecrementaVida();
        }
    }
    private void ViraPosicao(){
        Velocidade *= -1;
        if(obstaculo.GetComponent<SpriteRenderer>().flipX)
            obstaculo.GetComponent<SpriteRenderer>().flipX = false;
        else        
            obstaculo.GetComponent<SpriteRenderer>().flipX = true;
        
    }
}
