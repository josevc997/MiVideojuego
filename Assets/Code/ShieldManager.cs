using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShieldManager : MonoBehaviour
{
	public Text levelCleared;
	
	public GameObject transition;

	public Text escudosTotales;
	
	public Text escudosCogidas;

	private int escudosTotalesEnNivel;

	private void Start() {
		escudosTotalesEnNivel = transform.childCount;
	}

    // Update is called once per frame
    void Update()
    {
		AllFruitsCollected();
		escudosTotales.text = escudosTotalesEnNivel.ToString();
		escudosCogidas.text = (escudosTotalesEnNivel-transform.childCount).ToString();
    }
	
	public void AllFruitsCollected()
	{
		if (transform.childCount == 0){
			
			//Debug.Log("No quedan Escudos, Victoria");
			
			levelCleared.gameObject.SetActive(true);
			
			transition.SetActive(true);
			
			Invoke("ChangeScene", 2);
			
			//transition.SetActive(false);
		}
	}
	
	void ChangeScene(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
	}
}
