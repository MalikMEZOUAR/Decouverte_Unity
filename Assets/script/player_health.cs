using UnityEngine;
using System.Collections;

public class player_health : MonoBehaviour
{

    public int maxLifePoint = 50;
    public int CurrentLifePoint = 50;
    public bool isInvulnerable = false;
    public float invulnerableTime = 1.5f;
    public float invulnerableFlash = 0.2f;
    public SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentLifePoint = maxLifePoint;
    }

    public void hurt(int damage = 5){
        if(isInvulnerable){
            return;
        }
        CurrentLifePoint = CurrentLifePoint - damage;
        if (CurrentLifePoint <=0){
            Destroy(GameObject.FindWithTag("Player"));
        } else {
            StartCoroutine(Invulnerable());
        }
    }
    IEnumerator Invulnerable(){
        isInvulnerable = true;
        Color startColor = sr.color;

        WaitForSeconds invulnerableFlashWait=
        new WaitForSeconds(invulnerableFlash);
        for(float i = 0; i <= invulnerableTime; i += invulnerableFlash){
            if (sr.color.a == 1 ){
                sr.color = Color.clear;
            }else{
                sr.color = startColor;
            }
            yield return invulnerableFlashWait;
        }
        sr.color=startColor;
        isInvulnerable = false;
        yield return null;
    }
}
