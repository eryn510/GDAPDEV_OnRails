using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations.Rigging;

public class shootingMech : MonoBehaviour
{
    public float fireRange;
    public GameObject reticle;

    [Space]

    [Header("Particle")]
    public GameObject fireScatterParticle;
    public GameObject waterScatterParticle;
    public GameObject electroScatterParticle;
    public GameObject groundScatterParticle;
    [Space]

    [Header("Buttons")]
    [SerializeField] private Button fireButton;
    [SerializeField] private Button waterButton;
    [SerializeField] private Button electroButton;
    [SerializeField] private Button groundButton;

    [Space]

    [Header("Ammo Count")]
    public int fireAmmo;
    public int waterAmmo;
    public int electroAmmo;
    public int groundAmmo;

    [Space]

    [Header("Ammo Texts")]
    [SerializeField] Text fireAmmoText;
    [SerializeField] Text waterAmmoText;
    [SerializeField] Text electroAmmoText;
    [SerializeField] Text groundAmmoText;

    [Space]

    [Header("Ammo Spheres")]
    [SerializeField] GameObject fireAmmoSphere;
    [SerializeField] GameObject waterAmmoSphere;
    [SerializeField] GameObject electroAmmoSphere;
    [SerializeField] GameObject groundAmmoSphere;

    [Space]

    [Header("Ammo Damage")]
    public int fireDamage = 2;
    public int waterDamage = 2;
    public int electroDamage = 2;
    public int groundDamage = 2;

    [Space]

    [Header("Ammo Damage")]
    public Rig ArmRig; 

    private int fireDmgLevel, ftempDmg;
    private int waterDmgLevel, wtempDmg;
    private int electroDmgLevel, etempDmg;
    private int groundDmgLevel, gtempDmg;
    private int ammoLevel;

    private void Start()
    {
        fireDmgLevel = CurrencyManager.Instance.fireDmgLevel;
        waterDmgLevel = CurrencyManager.Instance.waterDmgLevel;
        electroDmgLevel = CurrencyManager.Instance.electroDmgLevel;
        groundDmgLevel = CurrencyManager.Instance.groundDmgLevel;
        ammoLevel = CurrencyManager.Instance.ammoSphereLevel;

        switch (fireDmgLevel)
        {
            case 1:
                fireDamage = 3;
                break;
            case 2:
                fireDamage = 4;
                break;
            case 3:
                fireDamage = 5;
                break;
            case 4:
                fireDamage = 6;
                break;
            case 5:
                fireDamage = 7;
                break;
        }

        switch (waterDmgLevel)
        {
            case 1:
                waterDamage = 3;
                break;
            case 2:
                waterDamage = 4;
                break;
            case 3:
                waterDamage = 5;
                break;
            case 4:
                waterDamage = 6;
                break;
            case 5:
                waterDamage = 7;
                break;
        }

        switch (electroDmgLevel)
        {
            case 1:
                electroDamage = 3;
                break;
            case 2:
                electroDamage = 4;
                break;
            case 3:
                electroDamage = 5;
                break;
            case 4:
                electroDamage = 6;
                break;
            case 5:
                electroDamage = 7;
                break;
        }

        switch (groundDmgLevel)
        {
            case 1:
                groundDamage = 3;
                break;
            case 2:
                groundDamage = 4;
                break;
            case 3:
                groundDamage = 5;
                break;
            case 4:
                groundDamage = 6;
                break;
            case 5:
                groundDamage = 7;
                break;
        }

        switch(ammoLevel)
        {
            case 1:
                fireAmmo = 20;
                waterAmmo = 20;
                electroAmmo = 20;
                groundAmmo = 20;
                break;
            case 2:
                fireAmmo = 30;
                waterAmmo = 30;
                electroAmmo = 30;
                groundAmmo = 30;
                break;
            case 3:
                fireAmmo = 40;
                waterAmmo = 40;
                electroAmmo = 40;
                groundAmmo = 40;
                break;
            case 4:
                fireAmmo = 50;
                waterAmmo = 50;
                electroAmmo = 50;
                groundAmmo = 50;
                break;
            case 5:
                fireAmmo = 60;
                waterAmmo = 60;
                electroAmmo = 60;
                groundAmmo = 60;
                break;
        }

        fireAmmoText.text = fireAmmo.ToString();
        waterAmmoText.text = waterAmmo.ToString();
        electroAmmoText.text = electroAmmo.ToString();
        groundAmmoText.text = groundAmmo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        fireAmmoText.text = fireAmmo.ToString();
        waterAmmoText.text = waterAmmo.ToString();
        electroAmmoText.text = electroAmmo.ToString();
        groundAmmoText.text = groundAmmo.ToString();
        ArmRig.weight = 0;
    }
    

    public void ShootFire()
    {
        ftempDmg = fireDamage;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(reticle.GetComponent<RectTransform>().position);
        if(Physics.Raycast(ray, out hit, fireRange) && fireAmmo > 0)
        {
            SFXManager.SFXInstance.PlayerplaySFX(SFXManager.SFXInstance.Fire);
            SFXManager.SFXInstance.PlayerAudio.volume = 0.7f;
            StartCoroutine(SmoothRig(0, 1));
            //IF FIRE AMMO SPHERE IS HIT
            if (hit.transform.name == "FireAmmoSphere")
            {
                fireAmmo += 3;
                GameObject particleFire2 = Instantiate(fireScatterParticle, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(particleFire2, 1f);
                Destroy(fireAmmoSphere);
            }
            //IF ENEMY IS HIT
            else
            {
                Debug.Log(hit.transform.name);
                Debug.Log("firebutton");

                if(cheatsManager.Instance.isUnliAmmo == false)
                {
                    fireAmmo -= 1;
                }
                
                GameObject particleFire2 = Instantiate(fireScatterParticle, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(particleFire2, 1f);

                enemyHealth enemyHealth = hit.transform.GetComponent<enemyHealth>();
                if(enemyHealth != null)
                {
                    //FIRE ATTACK TO GRASS
                    if(hit.transform.tag == "GRASS")
                    {
                        ftempDmg *= 2;
                    }
                    //FIRE ATTACK TO ELECTRO
                    if (hit.transform.tag == "ELECTRO")
                    {
                        ftempDmg *= 1;
                    }
                    //FIRE ATTACK TO FIRE
                    if (hit.transform.tag == "FIRE")
                    {
                        ftempDmg /= 2;
                    }
                    enemyHealth.takeDamage(ftempDmg); 
                }
            }
        }
    }

    public void ShootWater()
    {
        wtempDmg = waterDamage;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(reticle.GetComponent<RectTransform>().position);
        if (Physics.Raycast(ray, out hit, fireRange) && waterAmmo > 0)
        {
            SFXManager.SFXInstance.PlayerplaySFX(SFXManager.SFXInstance.Water);
            SFXManager.SFXInstance.PlayerAudio.volume = 0.7f;
            StartCoroutine(SmoothRig(0, 1));
            //IF WATER AMMO SPHERE IS HIT
            if (hit.transform.name == "WaterAmmoSphere")
            {
                waterAmmo += 3;
                GameObject particleWater2 = Instantiate(waterScatterParticle, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(particleWater2, 1f);
                Destroy(waterAmmoSphere);
            }

            Debug.Log(hit.transform.name);
            Debug.Log("waterbutton");
            
            if(cheatsManager.Instance.isUnliAmmo == false)
            {
                waterAmmo -= 1;
            }

            GameObject particleFire1 = Instantiate(waterScatterParticle, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(particleFire1, 1f);

            enemyHealth enemyHealth = hit.transform.GetComponent<enemyHealth>();
            if (enemyHealth != null)
            {
                //WATER ATTACK TO GRASS
                if (hit.transform.tag == "GRASS")
                {
                    wtempDmg /= 2;
                }
                //WATER ATTACK TO ELECTRO
                if (hit.transform.tag == "ELECTRO")
                {
                    wtempDmg /= 2;
                }
                //WATER ATTACK TO FIRE
                if (hit.transform.tag == "FIRE")
                {
                    wtempDmg *= 2;
                }
                enemyHealth.takeDamage(wtempDmg);
            }
        }
    }

    public void ShootElectro()
    {
        etempDmg = electroDamage;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(reticle.GetComponent<RectTransform>().position);
        if (Physics.Raycast(ray, out hit, fireRange) && electroAmmo > 0)
        {
            SFXManager.SFXInstance.PlayerplaySFX(SFXManager.SFXInstance.Electric);
            SFXManager.SFXInstance.PlayerAudio.volume = 0.7f;
            StartCoroutine(SmoothRig(0, 1));
            //IF ELECTRO AMMO SPHERE IS HIT
            if (hit.transform.name == "ElectroAmmoSphere")
            {
                electroAmmo += 3;
                GameObject particleElectro2 = Instantiate(electroScatterParticle, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(particleElectro2, 1f);
                Destroy(electroAmmoSphere);
            }

            Debug.Log(hit.transform.name);

            if (cheatsManager.Instance.isUnliAmmo == false)
                electroAmmo -= 1;

            GameObject particleFire3 = Instantiate(electroScatterParticle, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(particleFire3, 1f);

            enemyHealth enemyHealth = hit.transform.GetComponent<enemyHealth>();
            if (enemyHealth != null)
            {
                //ELECTRO ATTACK TO GRASS
                if (hit.transform.tag == "GRASS")
                {
                    etempDmg *= 1;
                }
                //ELECTRO ATTACK TO ELECTRO
                if (hit.transform.tag == "ELECTRO")
                {
                    etempDmg /= 2;
                }
                //ELECTRO ATTACK TO FIRE
                if (hit.transform.tag == "FIRE")
                {
                    etempDmg *= 1;
                }
                enemyHealth.takeDamage(etempDmg);
            }
        }
    }

    public void ShootGround()
    {
        gtempDmg = groundDamage;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(reticle.GetComponent<RectTransform>().position);
        if (Physics.Raycast(ray, out hit, fireRange) && groundAmmo > 0)
        {
            SFXManager.SFXInstance.PlayerplaySFX(SFXManager.SFXInstance.Ground);
            SFXManager.SFXInstance.PlayerAudio.volume = 0.7f;
            StartCoroutine(SmoothRig(0, 1));
            //IF GROUND AMMO SPHERE IS HIT
            if (hit.transform.name == "GroundAmmoSphere")
            {
                groundAmmo += 3;
                GameObject particleGround2 = Instantiate(groundScatterParticle, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(particleGround2, 1f);
                Destroy(groundAmmoSphere);
            }

            Debug.Log(hit.transform.name);

            if (cheatsManager.Instance.isUnliAmmo == false)
                groundAmmo -= 1;

            GameObject particleFire4 = Instantiate(groundScatterParticle, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(particleFire4, 1f);

            enemyHealth enemyHealth = hit.transform.GetComponent<enemyHealth>();
            if (enemyHealth != null)
            {
                //GROUND ATTACK TO GRASS
                if (hit.transform.tag == "GRASS")
                {
                    gtempDmg /= 2;
                }
                //GROUND ATTACK TO ELECTRO
                if (hit.transform.tag == "ELECTRO")
                {
                    gtempDmg *= 2;
                }
                //GROUND ATTACK TO FIRE
                if (hit.transform.tag == "FIRE")
                {
                    gtempDmg *= 2;
                }
                enemyHealth.takeDamage(gtempDmg);
            }
        }
    }

    IEnumerator SmoothRig(float start, float end)
    {
        float elapsedTime = 0;
        float waitTime = 0.1f;

        while (elapsedTime < waitTime)
        {
            ArmRig.weight = Mathf.Lerp(start, end, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
