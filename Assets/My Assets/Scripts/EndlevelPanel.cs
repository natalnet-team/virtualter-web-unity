using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Script para coletar todos as informações que o Painel de fim de fase precisa.

public class EndlevelPanel : MonoBehaviour {


    public Image[] sItem = new Image[10];

    public Text time;
    public Text energies;
    public Text score;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.E))//Muda de fase quando uma das teclas for pressionada.
        {
            Scene current = SceneManager.GetActiveScene();
            int index = current.buildIndex + 1;
            SceneManager.LoadScene(index);
        }
	}

    public void SetupPanel ()//Coloca todas as informações no painel.
    {
        time.text = "  Tempo: "+ Timer.time;
        energies.text = "  Energias: " + PlayerScore.Energies + "/20";
        score.text = "  Pontuação: " + PlayerScore.Score;
    }

    public void SetupSpecialEventPanel(int remainingSec)
    {
        int coinsNumber = 0;
        Debug.Log("coinsNumber - Início " + coinsNumber);

        PlayerScore.CalculateScore();
        time.text = "Tempo Restante: " + remainingSec + " Segundos";
        score.text = " Pontuação: " + PlayerScore.Score;
        for (int i = 0; i < 10; i++)
        {
            if (PlayerScore.GetSpecialItems(i))
            {
                coinsNumber++;
                sItem[i].color = Color.yellow;
                Debug.Log("coinsNumber - FOR: " + coinsNumber);
            }
        }

        PlayerScore.lA1 = false;
        PlayerScore.lA2 = false;
        PlayerScore.lA3 = false;
        PlayerScore.lA4 = false;
        PlayerScore.lA5 = false;

        PlayerScore.rA1 = false;
        PlayerScore.rA2 = false;
        PlayerScore.rA3 = false;
        PlayerScore.rA4 = false;
        PlayerScore.rA5 = false;

        //! LEMBRAR DE DESCOMENTAR ESSA PARTE DO CÓDIGO
        // RETORNO PARA O JAVASCRIPT
            // Enviando número da fase
        WebGLPluginJS.SendLevelToPage(SceneManager.GetActiveScene().buildIndex - 1);
            // Enviando tempo utilizado
        WebGLPluginJS.SendTimeToPage(40 - remainingSec);
            // Enviando pontuação
        WebGLPluginJS.SendPointsToPage(PlayerScore.Score);
            // Enviando moedas coletadas
        WebGLPluginJS.SendCoinsNumberToPage(coinsNumber);
    }

}
