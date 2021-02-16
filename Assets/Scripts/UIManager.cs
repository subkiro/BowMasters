using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject Healthbar;
    [SerializeField] private GameObject Winner;
    [SerializeField] private Canvas canvasFront;
    [SerializeField] private GameObject ToastMessagePrefab;
    private void Awake()
    {
        instance = this;
        
    }


    


    private void MainMenu_Hide(object sender) => MainMenu.SetActive(false);
    private void MainMenu_Show(object sender) => MainMenu.SetActive(true);
    public void MainMenu_Show() => MainMenu.SetActive(true);


    private void HealthBar_Show(object sender) => Healthbar.SetActive(true);
    private void HealthBar_Hide(object sender) => Healthbar.SetActive(false);


    private void Winner_Show(object sender,Player p1) {
        GameObject winnerObj = Instantiate(Winner, this.canvasFront.transform);
        winnerObj.GetComponent<WinnerUI>().SetButtonListener(p1,MainMenu_Show);
    }

    public void ToastMessage(string message) {
        GameObject obj = Instantiate(ToastMessagePrefab, canvasFront.transform);
        obj.GetComponent<ToasMessage>().Show(message);
        
    }

    private void OnEnable()
    {
        EventHandler.instance.MatchStartAction += MainMenu_Hide;
        EventHandler.instance.MatchStartAction += HealthBar_Show;
        EventHandler.instance.WinnerEndMatchEvent += Winner_Show;

        EventHandler.instance.ExitMatchAction += MainMenu_Show;
        EventHandler.instance.ExitMatchAction += HealthBar_Hide;


    }
    private void OnDisable()
    {
        EventHandler.instance.MatchStartAction -= MainMenu_Hide;
        EventHandler.instance.ExitMatchAction -= MainMenu_Show;
        EventHandler.instance.WinnerEndMatchEvent -= Winner_Show;

        EventHandler.instance.ExitMatchAction -= HealthBar_Hide;
        EventHandler.instance.MatchStartAction -= HealthBar_Show;


    }

}
