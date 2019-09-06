using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanches : MonoBehaviour{

    public Ingredientes ingredientes;
    public GameObject[] IngredientesLanche,IngredientesLancheNaTela;
    public int TamanhoIngredientesLanche = 5;
    private float PosicaoIngredientesEmX = 8.61f;

    private float PosicaoIngredientesEmY = 4.4f;  
    
    public void CriaLanche(){
        SelecionaIngredientesDoLanche();
        for(int i = 0; i < TamanhoIngredientesLanche;i++)
            IngredientesLancheNaTela[i] = Instantiate(IngredientesLanche[i],new Vector3(PosicaoIngredientesEmX,
                                                                                        PosicaoIngredientesEmY - i + 0.1f,0),
                                                                                        Quaternion.identity);
    }
    public void ReapareceIngredienteQuandoAcertado(){
        IngredientesLancheNaTela[ingredientes.Contador - 1].SetActive(true);
    }
    public void EscondeIngredienteDoLancheNaTela(){
        foreach (GameObject ingrediente in IngredientesLancheNaTela)
            ingrediente.SetActive(false);                       
    }
    public void DestroiLanche(){
        foreach(GameObject ingrediente in IngredientesLancheNaTela)
            Destroy(ingrediente);
    }    
    private void SelecionaIngredientesDoLanche(){
        SelecionaPaoAleatoriamente();
        for(int i = 1; i < TamanhoIngredientesLanche - 1; i++)
            IngredientesLanche[i] = ingredientes.SelecionaIngredienteAleatoriamente();        
    }
    private void SelecionaPaoAleatoriamente(){
        int NumeroAleatorio = Random.Range(0,3);        
        IngredientesLanche[0] = ingredientes.TodosOsIngredientes[NumeroAleatorio];
        if(NumeroAleatorio == 0)
            IngredientesLanche[TamanhoIngredientesLanche - 1] = ingredientes.TodosOsIngredientes[3];
        else if(NumeroAleatorio == 1)
            IngredientesLanche[TamanhoIngredientesLanche - 1] = ingredientes.TodosOsIngredientes[4];
        else
            IngredientesLanche[TamanhoIngredientesLanche - 1] = ingredientes.TodosOsIngredientes[2];

    }

    
}
