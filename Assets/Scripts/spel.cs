﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spel : MonoBehaviour
{
    [SerializeField]
    private HealthBar healthBar;

    public GameObject[] mulls;
    public Transform[] spawns;
    public bool[] full;
    public float timer;
    public GameObject nymull;
    public GameObject helst;
    public float range;
    public Camera camera;
    public int score;

    public float x;
    public GameObject loseScreen;
    public float poängtime = 5;
    public bool gepoäng;
    public Sprite[] numbers;
    public Text skortext;
    public AudioSource musik;
    public AudioSource ljud;

    public int damage = 1; // Sätter hur mycket skada man tar för varje gång.

    // Start is called before the first frame update
    void Start()
    {
        ljud = GetComponent<AudioSource>();
        helst = new GameObject();
        loseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        helst.transform.position += new Vector3(1,1,0) * Time.deltaTime;
        x += Time.deltaTime;
        skortext.text = (string)score.ToString();
        timer += Time.deltaTime;
        if (timer > Random.Range(1, 8)) 
        {
            print("skapa mullvad");
            timer = 0;
            int nummer = Random.Range(0, spawns.Length);;
            nymull = Instantiate(mulls[Random.Range(0, mulls.Length)], spawns[nummer].position, Quaternion.identity);
            nymull.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            full[nummer] = true;
            gepoäng = true;
        }

        if (x > 10)
        {
            x = x % 10;
            print("det funkar");
        }
        if (helst.transform.position.y > 10)
        {
            helst.transform.position = new Vector3(transform.position.x, 0, 0);
        }

        if (healthBar.currentHealth <= 0) // Sätter igång dödsfunktionen om hälsan går till 0.
        {
            Die();
        }

        if (Input.GetMouseButtonDown(0)) //Du klickar en knapp
        {
            var v3 = Input.mousePosition;
            v3.z = 10.0f;
            v3 = Camera.main.ScreenToWorldPoint(v3);

            for (int i = 0; i < 1; i++)
            {
 
                if (Vector3.Distance(nymull.transform.position, v3) < range)
                {
                    ljud.PlayOneShot(ljud.clip);
                    Destroy(nymull);
                    full[i] = false;
                    print("test");
                    if (gepoäng == true)
                    {
                        if (poängtime > 3)
                        {
                            score += 5;
                            gepoäng = false;
                            poängtime = 5;
                        }
                        if (poängtime > 1)
                        {
                            score += 3;
                            gepoäng = false;
                            poängtime = 5;
                        } else
                        {
                            score += 1;
                            gepoäng = false;
                            poängtime = 5;
                        }
                    }
                }
                else
                {
                    healthBar.TakeDamage(1); // Tar damage.
                    print("miss");
                }
            }
        }

        if (gepoäng)
        {
            poängtime -= Time.deltaTime;
        }
    }

    private void Die()
    {
        musik.Stop();
        ljud.PlayOneShot(ljud.clip);
        Time.timeScale = 0;
        print("haha du förlorade!!!!?!");
        loseScreen.SetActive(true);
    }
}
