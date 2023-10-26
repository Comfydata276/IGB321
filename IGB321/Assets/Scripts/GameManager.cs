using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //Singleton Setup
    public static GameManager instance = null;

    public bool playerDead = false;

    public bool levelComplete = false;

    string thisLevel;
    public string nextLevel;

    public bool greenDoorsOpen = false;
    public bool blueDoorsOpen = false;

    public GameObject presentLevel;
    public GameObject pastLevel;

    public float timeShiftDuration;
    private float timeShiftTimer;
    public Slider timeBar;

    public GameObject pastPP;
    public GameObject presentPP;

    // Awake Checks - Singleton setup
    void Awake() {

        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
    }

    // Use this for initialization
    void Start () {
        thisLevel = SceneManager.GetActiveScene().name;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeBar.value = timeShiftTimer * 100 / timeShiftDuration;

        if (timeShiftTimer < timeShiftDuration)
        {
            timeShiftTimer += 50 * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (timeShiftTimer > -(timeShiftDuration * 0.15f))
            {
                timeShiftTimer -= 75 * Time.deltaTime;
            }
            
            if (timeShiftTimer > 0)
            {
                pastLevel.SetActive(true);
                presentLevel.SetActive(false);

                pastPP.SetActive(true);
                presentPP.SetActive(false);
            }
            else
            {
                pastLevel.SetActive(false);
                presentLevel.SetActive(true);

                pastPP.SetActive(false);
                presentPP.SetActive(true);
            }
        }
        else 
        {
            pastLevel.SetActive(false);
            presentLevel.SetActive(true);

            pastPP.SetActive(false);
            presentPP.SetActive(true);
        }

        if (playerDead)
        {
            SceneManager.LoadScene(thisLevel);
        }
	}

    public IEnumerator LoadLevel(string level) {

        yield return new WaitForSeconds(5);

        SceneManager.LoadScene(level);
    }


}
