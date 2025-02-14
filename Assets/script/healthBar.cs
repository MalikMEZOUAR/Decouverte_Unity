using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{

    public Image fillImage;
    public player_health healthPlayer;
    public Gradient lifeColorGradient;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float lifeRatio = (float)healthPlayer.CurrentLifePoint / (float)healthPlayer.maxLifePoint;
        fillImage.fillAmount = lifeRatio;
        fillImage.color = lifeColorGradient.Evaluate(lifeRatio);
    }
}
