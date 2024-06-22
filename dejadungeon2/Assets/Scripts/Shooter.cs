using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public bool auto = false; //do projectiles fire automatically?
    bool s_auto;
    public float delay = 0.5f; //time between projectile firings
    float lastFired = 0; //last time projectile was fired
    public float angle = 0f; //angle projectiles are fired
    public float spread = 0f; //random angle deviation
    public int angleChange = 0; //amount of times angle should change
    public float angleChangeAmount = 15f; //amount angle should change by per change
    public bool angleChangeReverseBehavior = false; //should angle change direction reverse when it hits amount of angle changes to make
    int angleChangeCount = 0; //amount of times angle has changed
    float angleChangeOffset = 0f; //current angle change
    int angleChangeDirection = 1; //direction angle change should go, 1 is clockwise, -1 is counter
    public int ammoMax = -1; //Amount of times shooter can fire, -1 is infinite ammo
    int ammo;

    public ObjectPool pool;

    private void Start()
    {
        s_auto = auto;
        ammo = ammoMax;
        EventManager.ResetEvent += ResetObject;
    }

    public void ResetObject()
    {
        lastFired = 0;
        angleChangeCount = 0;
        angleChangeOffset = 0f;
        angleChangeDirection = 1;
        pool.ReturnAll();
        auto = s_auto;
        ammo = ammoMax;
    }

    private void FixedUpdate()
    {
        if (auto && Time.time > lastFired + delay) Fire();
    }

    public void ToggleAuto() { auto = !auto; }

    public void Fire()
    {
        if (ammoMax >= 0)
        {
            if (ammo < 1) return;
            ammo--;
        }
        GameObject obj = pool.GetFromPool();
        Projectile projectile = obj.GetComponent<Projectile>();
        obj.transform.eulerAngles = transform.eulerAngles + new Vector3(0,0, angle + angleChangeOffset + Random.Range(-spread, spread));
        obj.transform.position = transform.position;
        obj.SetActive(true);
        projectile.Fired();
        if (angleChange > 0)
        {
            angleChangeCount += 1 * angleChangeDirection;
            angleChangeOffset = angleChangeCount * angleChangeAmount;
            if (angleChangeCount > angleChange)
            {
                if (angleChangeReverseBehavior)
                {
                    angleChangeCount = angleChange - 1;
                    angleChangeDirection = -1;
                } else
                {
                    angleChangeCount = 0;
                }
            }
            else if (angleChangeCount == -1) //only happens if we were reversing in the first place
            {
                angleChangeCount = 1;
                angleChangeDirection = 1;
            }
        }
        lastFired = Time.time;
    }
}
