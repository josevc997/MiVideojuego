using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
	
	public GameObject[] corazones;
	public GameObject[] corazonesVacios;
	private int life;

	private float checkPointPositionX, checkPointPositionY;
	
	public Animator animator;
	
    // Start is called before the first frame update
    void Start()
    {
		life = corazones.Length;
		if (PlayerPrefs.GetFloat("checkPointPositionX") != 0){
			transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY")));
		}
        
    }
	
	public void ReachedCheckPoint(float x, float y){
		PlayerPrefs.SetFloat("checkPointPositionX", x);
		PlayerPrefs.SetFloat("checkPointPositionY", y);
	}

	public void PlayerDamaged(){
		if(life >=0){
			life--;
			CheckLife();
		}
		
	}
	
	public void PlayerHealed(){
		if(life < 3){
			life++;
			CheckLife();
		}
		
	}
	
	void Respawn(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

    // Update is called once per frame
    void CheckLife()
    {
		Debug.Log(life);
        if (life == 0){
			//Destroy(corazones[0].gameObject);
			corazones[0].gameObject.SetActive(false);
			corazones[1].gameObject.SetActive(false);
			corazones[2].gameObject.SetActive(false);
			
			corazonesVacios[0].gameObject.SetActive(true);
			corazonesVacios[1].gameObject.SetActive(true);
			corazonesVacios[2].gameObject.SetActive(true);
			
			animator.Play("Hit");
			Invoke("Respawn", 0.5f);
		}
		else if(life == 1){
			//Destroy(corazones[1].gameObject);
			
			corazones[0].gameObject.SetActive(true);
			corazones[1].gameObject.SetActive(false);
			corazones[2].gameObject.SetActive(false);
			
			corazonesVacios[0].gameObject.SetActive(false);
			corazonesVacios[1].gameObject.SetActive(true);
			corazonesVacios[2].gameObject.SetActive(true);
			
			animator.Play("Hit");
		}
		else if(life == 2){
			corazones[0].gameObject.SetActive(true);
			corazones[1].gameObject.SetActive(true);
			corazones[2].gameObject.SetActive(false);
			
			corazonesVacios[0].gameObject.SetActive(false);
			corazonesVacios[1].gameObject.SetActive(false);
			corazonesVacios[2].gameObject.SetActive(true);
			//Destroy(corazones[2].gameObject);
			animator.Play("Hit");
		}
		else if(life == 3){
			corazones[0].gameObject.SetActive(true);
			corazones[1].gameObject.SetActive(true);
			corazones[2].gameObject.SetActive(true);
			
			corazonesVacios[0].gameObject.SetActive(false);
			corazonesVacios[1].gameObject.SetActive(false);
			corazonesVacios[2].gameObject.SetActive(false);
			//Destroy(corazones[2].gameObject);
			animator.Play("Hit");
		}
    }
}
