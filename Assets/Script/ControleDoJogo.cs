using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleDoJogo : MonoBehaviour{
    public Ingredientes ingredientes;
    public Lanches lanches;
    public Cozinheiro cozinheiro;
    public Clientes clientes;
    public Obstaculo obstaculo;
    public Text LanchesProntosTexto, ContagemParaLancheTexto;

    public GameObject[] AcertosErros, Obstaculos;    

    public GameObject ObjetoAcerto, ObjetoErro;

    public int QuantidadeDeLanchesProntos,ContagemParaLanche,QuantidadeDeIngredientesCorretos, QuantidadeObstaculos;
    public void Start(){
        MontaTelaParaJogo();              
    }
    public void Update(){
        LanchesProntosTexto.text = QuantidadeDeLanchesProntos.ToString();
        ContagemParaLancheTexto.text = ContagemParaLanche.ToString();
        ParaContagemRegressivaSeAcabou();
        ControlaQuantidadeTotalDeIngredientes();                
    }
    public void CriaReacao(){
        clientes.SelecionaReacao(ingredientes.VerificaQuantosIngredientesCorretosTem());  
    }
    public void MontaTelaParaJogo(){
        QuantidadeDeIngredientesCorretos = 0;
        StartCoroutine("IniciaContagemParaLanche");        
        lanches.CriaLanche();
        Invoke("ChamaFuncaoDeAparecerItens",6f);
    }    
    public void DestroiAcertosErrosNaTela(){
        foreach (GameObject acertoOuErro in AcertosErros)
            Destroy(acertoOuErro);
    }    
    public bool VerificaSeObstaculoFoiAtingido(GameObject Objeto){
        if(Objeto.tag == "Obstaculo")
            return true;
        return false;
    }    
    public void IngredienteCorretoAtingido(){        
        QuantidadeDeIngredientesCorretos++;
        CriaAcertoOuErroNaTela(lanches.IngredientesLancheNaTela[ingredientes.Contador - 1].
                                                                    transform.position,"Acerto");
        lanches.ReapareceIngredienteQuandoAcertado(); 
    }
    public void IngredienteErradoAtingido(){
        CriaAcertoOuErroNaTela(lanches.IngredientesLancheNaTela[ingredientes.Contador - 1 ].
                                                                    transform.position,"Erro");
        lanches.ReapareceIngredienteQuandoAcertado();
    }
    public bool VerificaSeIngredienteAtingidoEstaCorreto(GameObject Objeto){
        if(Objeto.tag == lanches.IngredientesLancheNaTela[ingredientes.Contador - 1].tag )
            return true;
        return false;
    }
    public void EsperaTempoDeReacaoNaTela(){
        float TempoDeEspera = 3f;
        Invoke("DestroiAcertosErrosNaTela",TempoDeEspera);
        clientes.Invoke("DestroiReacaoNaTela",TempoDeEspera);         
        lanches.Invoke("DestroiLanche",TempoDeEspera);
        Invoke("MontaTelaParaJogo",TempoDeEspera);       
    }
    public void ControlaQuantidadeTotalDeIngredientes(){
        switch(QuantidadeDeLanchesProntos){
            case 10:
                lanches.TamanhoIngredientesLanche = 6;
            break;
            case 15:
                QuantidadeObstaculos = 2;
            break;
            case 20:
                lanches.TamanhoIngredientesLanche = 7;
            break;
            case 25:
                QuantidadeObstaculos = 3;
            break;
        }
    }
    private void DesapareceComLancheSeContagemParou(){
        if(ContagemParaLanche <= 0)
            lanches.EscondeIngredienteDoLancheNaTela();
    }
    private void ParaContagemRegressivaSeAcabou(){
        if(ContagemParaLanche <= 0){
            ContagemParaLancheTexto.gameObject.SetActive(false);
            StopCoroutine("IniciaContagemParaLanche");
        }
    }   
    IEnumerator IniciaContagemParaLanche(){
        ContagemParaLanche = 5;
        ContagemParaLancheTexto.gameObject.SetActive(true);
        while(true){
            yield return new WaitForSeconds(1);
            ContagemParaLanche--;
            DesapareceComLancheSeContagemParou();
        }
    }      
    private void CriaAcertoOuErroNaTela(Vector3 PosicaoDoIngrediente, string AcertoOuErro){
        AcertosErros[ingredientes.Contador - 1] = Instantiate(TrazAcertoOuErro(AcertoOuErro),
                                                            PosicaoDoIngrediente,Quaternion.identity);
    }
    private GameObject TrazAcertoOuErro(string AcertoOuErro){
        if(AcertoOuErro == "Acerto")
            return ObjetoAcerto;
        else        
            return ObjetoErro;        
    }    
    private void ChamaFuncaoDeAparecerItens(){
        ingredientes.CriaOsIngredientesParaAcertar();
        obstaculo.FazAparecerObstaculos(QuantidadeObstaculos,Obstaculos);
        clientes.DestroiReacaoNaTela();
    }    
   
}
