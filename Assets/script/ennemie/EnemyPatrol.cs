

using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    private Transform target;
    private int destPoint;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        target = waypoints[0]; 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        // Si l'ennemie est quasiment arriver a sa destination

        if (Vector3.Distance(transform.position, target.position)< 0.3f){
            
            destPoint = (destPoint + 1) % waypoints.Length;
            target =waypoints[destPoint];
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

    }
    
}
