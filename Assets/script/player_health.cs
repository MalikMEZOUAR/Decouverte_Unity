using UnityEngine;
using System.Collections;

public class player_health : MonoBehaviour
{

    public PlayerData dataPlayer;
    public bool isInvulnerable = false;
    public float invulnerableTime = 1.5f;
    public float invulnerableFlash = 0.2f;
    public SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dataPlayer.CurrentLifePoint = dataPlayer.maxLifePoint;
    }

    public void hurt(int damage = 1){
        if(isInvulnerable){
            return;
        }
        dataPlayer.CurrentLifePoint = dataPlayer.CurrentLifePoint - damage;
        if (dataPlayer.CurrentLifePoint <=0){
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
