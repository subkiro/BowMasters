using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class ToasMessage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Text messateUI;
  
    public void Show(string message = "") {

        messateUI.text = message;
        
        this.transform.GetComponent<RectTransform>().DOAnchorPosX(0, 0.2f).SetEase(Ease.OutSine).From(new Vector2(-2500,0)).OnComplete(Hide).SetDelay(1f);
    }

    public void Hide()
    {


        this.transform.GetComponent<RectTransform>().DOAnchorPosX(2500, 0.2f).SetEase(Ease.OutSine).SetDelay(2f).OnComplete(()=> { Destroy(this.gameObject); });

    }
    void DestroyAfterShow() { 
    
    }

    private void OnEnable()
    {
        Show("test");
    }

}
