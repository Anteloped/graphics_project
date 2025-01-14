using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Health : MonoBehaviour
{
    public static Health Instance;

    public int maxHealth = 3;
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public TextMeshProUGUI gameOverText;

    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this);
        }
        else {
            Instance = this;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        gameOverText.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            gameOverText.enabled = true;
            gameOverText.gameObject.SetActive(true);
        }


        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void Reset() {
        health = maxHealth;
        gameOverText.enabled = false;
        gameOverText.gameObject.SetActive(false);
        for (int i = 0; i < hearts.Length; i++) {
            hearts[i].enabled = true;
        }
    }
}
