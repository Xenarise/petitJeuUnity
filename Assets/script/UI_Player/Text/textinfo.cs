using UnityEngine;
using UnityEngine.UI;

public class textinfo : MonoBehaviour
{   
    public Text text;

    void Start(){
        
        if (text == null) {
            text = GetComponent<Text>();

        }

        // Désactiver le texte au démarrage
        text.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("ladder")){
            text.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("ladder")){
            text.enabled = false;
        }
    }
}
