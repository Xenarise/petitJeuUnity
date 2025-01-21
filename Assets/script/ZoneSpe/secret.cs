using UnityEngine;
using UnityEngine.Tilemaps;

public class secret : MonoBehaviour
{
    public Tilemap tilemap;
    private Color originalColor;

    void Start()
    {
        originalColor = tilemap.color; // Sauvegarde de la couleur d'origine
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Changer la couleur de la tilemap avec une opacité de 40%
            tilemap.color = new Color(229f / 255f, 183f / 255f, 27f / 255f, 0.4f); // Couleur "E5B71B" avec 40% d'opacité
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Rétablir la couleur d'origine de la tilemap
            tilemap.color = originalColor;
        }
    }
}
