using UnityEngine;

public class ennemy : MonoBehaviour
{
    public ContactPoint2D[] listeContacts = new ContactPoint2D[1];
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            other.GetContacts(listeContacts);

            if (listeContacts[0].normal.y < -0.5f){
                Destroy(gameObject);
            }else {
                player_health player_health = other.gameObject.GetComponent<player_health>();
                player_health.hurt();
            }
        }
    }
}
