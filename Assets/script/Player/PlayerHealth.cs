
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 100;
    public int curentHealth;
    public HealthBar healthBar;
    public bool die = false;

     public void Start(){
        curentHealth =MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
     }
     void Update(){
      if(Input.GetKeyDown(KeyCode.H)){
         TakeDamage(20);
      }
      TpMort();
     }
   public void TakeDamage(int damage){
      curentHealth -= damage;
      healthBar.SetHealth(curentHealth);
   }
   public void TpMort(){
      
      if(die == false && curentHealth <= 0){
         die = true;
         transform.position = new Vector2(-12.34f, 1.47f);
         healthBar.SetHealth(MaxHealth);
      }
   }
      

}
