using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{
    Animator switchAnimator;

    public enum ResetType { Never, OnUse, Timed, Immediately } //never reset, default, reset time, instant.
    public ResetType resetType = ResetType.OnUse; //default state/behaviour.

    [SerializeField] private GameObject switchTarget;
    [SerializeField] private bool switchOn;//For switch knappen

    [SerializeField] private string onMessage;
    [SerializeField] private string offMessage;

    [SerializeField] private float resetTime;

    // Start is called before the first frame update
    void Start()
    {
        switchAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchOn()
    {
        if (!switchOn)
        {
            SetState(true);
        }
    }

    public void SwitchOff()
    {
        if (switchOn && resetType != ResetType.Never && resetType != ResetType.Timed) //if resettype is never or timed, you CANNOT switch it off.
        {
            SetState(false);
        }
    }

    public void ToggleSwitch()
    {
        if (switchOn)
        {
            SwitchOff();
            Debug.Log("Switch Off");
        }
        else
        {
            SwitchOn();
            Debug.Log("Switch On");
        }
    }

    private void TimedReset()
    {
        SetState(false);
        Debug.Log("Switch reset!");
    }

    private void SetState(bool on)
    {
        switchOn = on; //Så vi starter med at switch er Off. Dermed er SetState = true.

        switchAnimator.SetBool("On", on);

        if (on)
        {
            if (switchTarget != null && !string.IsNullOrEmpty(onMessage))
            {
                switchTarget.SendMessage(onMessage);
            }

            if (resetType == ResetType.Immediately)
            {
                SwitchOff();
            }
            else if (resetType == ResetType.Timed)
            {
                Invoke("TimedReset", resetTime);

            }


        }
        else
        {
            if (switchTarget != null && !string.IsNullOrEmpty(offMessage))
            {
                switchTarget.SendMessage(offMessage);
            }
        }
    }

}
