using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;
using System;
using UnityEngine.UI;

public class NotifManager : MonoBehaviour
{
    private bool isNotifGenerated = false;
    private float deleteTicks = 0.0f;
    [SerializeField] private Text notifDelayText;
    [SerializeField] private Slider notifSlider;
    private float notifDelayTime;

    // Start is called before the first frame update
    void Start()
    {
        AndroidNotificationCenter.CancelAllDisplayedNotifications();

        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Push notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateTestNotification()
    {
        var notification = new AndroidNotification();
        notification.Title = "Alchemical Breakout";
        notification.Text = "Play a level!";
        notification.FireTime = System.DateTime.Now;

        var id = AndroidNotificationCenter.SendNotification(notification, "channel_id");

    }

    public void OnSliderEdit()
    {
        notifDelayTime = notifSlider.value;
        notifDelayText.text = notifDelayTime.ToString();
    }

    public void generateTestNotificationWithDelay()
    {
        var notification = new AndroidNotification();
        notification.Title = "Alchemical Breakout";
        notification.Text = "Play a level!";
        notification.FireTime = System.DateTime.Now.AddMinutes(notifDelayTime);

        var id = AndroidNotificationCenter.SendNotification(notification, "channel_id");

    }
}
