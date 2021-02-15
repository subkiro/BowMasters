using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHelper : MonoBehaviour
{
    [SerializeField] private TextMesh text;
  



    public void UpdateUIHelper(float power, float angle)
    {
        this.transform.rotation = this.transform.root.rotation;

        int pow = Mathf.FloorToInt( Mathf.Clamp(power, 0, 100));
        float ang = Mathf.Clamp01(angle);

        text.text = pow.ToString() + "%   " + Mathf.FloorToInt(ang*100f).ToString()+ "°";
    }
}
