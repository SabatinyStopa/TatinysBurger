using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredientes : MonoBehaviour{
    public GameObject[] TodosOsIngredientes, IngredientesParaAcertar;
    public Lanches lanches;
    public Clientes clientes;
    public ControleDoJogo controleDoJogo;
    private float[] PosicoesDeSpawnDosIngredientesEmX = {-5.79f,-1f,4.38f};
    private float PosicaoDeSpawnDosIngredientesEmY = 3.82f;
    public int Contador = 0;    
    public void CriaOsIngredientesParaAcertar(){        
        GameObject[] ingredientes = new GameObject[3];
        VerificaSeIngredientesSaoIguais(ingredientes);
        SetPosicoesDeSpawnDosIngredientesEmX();
        CriaIngredientesNaTela(ingredientes);        
    }        
    public string VerificaQuantosIngredientesCorretosTem(){
        if(controleDoJogo.QuantidadeDeIngredientesCorretos == lanches.TamanhoIngredientesLanche)
            return "Bom";
        else if(controleDoJogo.QuantidadeDeIngredientesCorretos == lanches.TamanhoIngredientesLanche - 1)
            return "Indiferente";
        else
            return "Ruim";                
    }
    public bool VerificaSeSequenciaDeIngredientesAcabou(){
        if(Contador >= lanches.TamanhoIngredientesLanche)           
            return true;        
        else
            return false;     
    }
    public void DestroiIngredientesParaAcertar(){
        foreach (GameObject ingrediente in IngredientesParaAcertar)
            Destroy(ingrediente);
    }
    public GameObject SelecionaIngredienteAleatoriamente(){
        int NumeroAleatorio = Random.Range(5,TodosOsIngredientes.Length);
        return TodosOsIngredientes[NumeroAleatorio];        
    }
    private void VerificaSeIngredientesSaoIguais(GameObject[] ingredientes){
        while(ingredientes[0] == ingredientes[1] || ingredientes[0] == ingredientes[2] || ingredientes[1] == ingredientes[2]){
            for (int i = 1; i <= 2; i++){
                ingredientes[0] = lanches.IngredientesLanche[Contador];
                ingredientes[i] = SelecionaIngredienteAleatoriamente();
            }
        } 
        Contador++;
    }
    private void SetPosicoesDeSpawnDosIngredientesEmX(){
        int NumeroAleatorio = Random.Range(1,4);
        switch(NumeroAleatorio){
            case 1:                
                PosicoesDeSpawnDosIngredientesEmX[0] = -5.79f;
                PosicoesDeSpawnDosIngredientesEmX[1] = -1f;
                PosicoesDeSpawnDosIngredientesEmX[2] = 4.38f;
            break;
            case 2:
                PosicoesDeSpawnDosIngredientesEmX[1] = -5.79f;
                PosicoesDeSpawnDosIngredientesEmX[0] = -1f;
                PosicoesDeSpawnDosIngredientesEmX[2] = 4.38f;
            break;
            case 3:
                PosicoesDeSpawnDosIngredientesEmX[2] = -5.79f;
                PosicoesDeSpawnDosIngredientesEmX[1] = -1f;
                PosicoesDeSpawnDosIngredientesEmX[0] = 4.38f;
            break;
        }
    }
    private void CriaIngredientesNaTela(GameObject[] ingredientes){
        for(int i = 0; i <= 2; i++)
            IngredientesParaAcertar[i] = Instantiate(ingredientes[i],new Vector3(PosicoesDeSpawnDosIngredientesEmX[i],
                                                                        PosicaoDeSpawnDosIngredientesEmY,0),Quaternion.identity);
    }

}
