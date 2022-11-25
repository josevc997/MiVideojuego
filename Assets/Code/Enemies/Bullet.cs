using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Bullet : MonoBehaviour
{
    public float speed = 2;

    public float lifeTime = 2;

    public bool left;

    public AudioSource clip;

    private void OnCollisionEnter2D(Collision2D collision)
	{
		clip.Play();
        Destroy(gameObject, 0.2f);
		
	}

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    
    private void Update()
    {
        if (left)
        {
            transform.Translate(Vector2.left * speed *  Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}