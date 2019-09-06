using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Cozinheiro : MonoBehaviour{

    public GameObject Espatula, Estrela;
    public GameObject[] Estrelas;
    public int Vida;
    private int VelocidadeDeMovimento = 10;

    private float IntervaloEntreDisparos = 0.2f, ContadorEntreDisparos = 0;
	    
    void Update(){
        Movimentar();
        Atirar();
        ContadorEntreDisparos += Time.deltaTime;
        if(Vida <= 0)
            Debug.Log("Se fodeu!!!");
    }

    public void DecrementaVida(){
        Estrelas[Vida - 1].SetActive(false);
        Vida--;
    }
    private void Movimentar(){
        float EixoX = Input.GetAxis("Horizontal") * VelocidadeDeMovimento * Time.deltaTime;
        transform.Translate(EixoX,0,0);
    }

    private void Atirar(){        
        if(Input.GetButtonDown("Jump") && ContadorEntreDisparos >= IntervaloEntreDisparos){
            Instantiate(Espatula, new Vector3(transform.position.x,transform.position.y+1,transform.position.z), Quaternion.identity);
            ContadorEntreDisparos = 0;
        }
        
    }
}
