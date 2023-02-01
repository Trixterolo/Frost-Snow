using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class StatusBar : MonoBehaviour
{
    //[SerializeField] WolfMovement wolfMovement;
    //[SerializeField] HareMovement hareMovement;
    public float minimum;

    public float maximum;
    public float current;
    public Image mask;
    public Image fill;
    public Color color;

    public float decreaseHPbyMovement = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }

    public void GetCurrentFill()
    {
        float currentOffset = current - minimum;
        float maximumOffset = maximum - minimum;

        float fillAmount = (currentOffset - (decreaseHPbyMovement * Time.fixedDeltaTime)) / maximumOffset;
        mask.fillAmount = fillAmount ;


        fill.color = color;

    }

    public void DecreaseHp()
    {

    }
}
