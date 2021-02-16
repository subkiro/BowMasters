using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarUI : MonoBehaviour
{

    public static HealthBarUI instance;
    [Header("Health bar images")]
    [SerializeField] private Image hp_1;
    [SerializeField] private Image hp_2;
    [Header("Player photoes")]
    [SerializeField] private Image pic1;
    [SerializeField] private Image pic2;
    private Player p1;
    private Player p2;

    [SerializeField] private Transform ScoreUIs;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        
    }

    public void InitPlayers(object sender, Player pp1, Player pp2) {

        this.p1 = pp1;
        this.p2 = pp2;

        this.pic1.sprite = p1.profilePic;
        this.pic2.sprite = p2.profilePic;

        UpdateHealth(this);
    }


   

    private void UpdateHealth(object arg1)
    {

        hp_1.fillAmount = p1.GetHealth();
        hp_2.fillAmount = p2.GetHealth();

        if (p1.GetHealth() <= 0) {
            //winner is Player2
            EventHandler.instance.Winner(this,p2);
        }

        if (p2.GetHealth() <= 0) {
            //winner is Player1
            EventHandler.instance.Winner(this, p1);
        }
    }



    public void OnShow() {
        ScoreUIs.gameObject.SetActive(true);

    }


    public void OnHide() {
        ScoreUIs.gameObject.SetActive(false);

    }


    private void OnEnable()
    {
        Debug.Log("HealthBar Enable");
        EventHandler.instance.TakeDamageEvent += UpdateHealth;
        
        EventHandler.instance.StartMatchEvent += InitPlayers;
    }

    private void OnDisable()
    {
        Debug.Log("HealthBar disable");
        EventHandler.instance.TakeDamageEvent -= UpdateHealth;
        EventHandler.instance.StartMatchEvent -= InitPlayers;
    }
}
