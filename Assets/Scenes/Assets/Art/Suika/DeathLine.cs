using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathLine : MonoBehaviour
{
    public string sceneToReload;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.GetComponent<Fruit>().onGround)
        {
            Scene current = SceneManager.GetActiveScene();
            SceneManager.LoadScene(current.buildIndex);
        }
        
    }
}
