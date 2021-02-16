using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
public class WinnerUI : MonoBehaviour
{
    [SerializeField] private Image winnerPic;
    [SerializeField] private CanvasGroup group;
    [SerializeField] public Button button;
    [SerializeField] private TMP_Text wintext;
    private Action<object> action;
    private Player winner;
    private void Awake()
    {
        group.alpha = 0;
     
        winner = GamePlay.instance.winner;
        winnerPic.sprite = winner.profilePic;

    }
    private void Start()
    {
        
        Invoke("Show", 1f);

    }

    public void Show() {
        SoundManager.instance.PlayVFX("popUp");
        this.transform.DOScale(1, 0.2f).From(10).SetEase(Ease.Flash);
        group.DOFade(1, 0.2f).From(0.5f);
       

    }

    public void Hide()
    {
        SoundManager.instance.PlayVFX("return");
        this.transform.DOScale(5, 0.3f).From(1).SetEase(Ease.Flash);
        group.DOFade(0, 0.2f).From(0.5f).OnComplete(OnMyDestroy);


    }

 
    public void OnMyDestroy() {
        if (action != null) {
           EventHandler.instance.ExitMatch(this);
           action?.Invoke(this);
            
            Destroy(this.gameObject);    
        }
    }

    public void SetButtonListener(Player p,Action<object> callback) {
        string winnerName = p.transform.tag;

        if (winnerName == "Player1")
        {
            wintext.text = " - YOU WON - ";
           
        }
        else {
            wintext.text = " - YOU LOST - ";
            SoundManager.instance.PlayVFX("Pvp");
        }
            

        action = callback;
        button.onClick.AddListener(OnMyDestroy);
    
    }
}
