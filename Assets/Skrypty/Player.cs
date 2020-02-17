using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] float rocketSpeed = 2f;
    [SerializeField] float starBoost = 10f;
    [SerializeField] float extraFuelBoost = 15f;

    [SerializeField] InputProvider inputProvider;
    
    Rigidbody2D rocket;
    bool initialBoost;
    int boostCount;
    bool lose;
    GameObject fire;
    ScoreManager scoreManager;

    void Awake() {
        rocket = GetComponent<Rigidbody2D>();
        fire = gameObject.transform.GetChild(0).gameObject;
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void FixedUpdate() {
        Flight();
    }

    void Flight() {
        if (lose)
            return;

        var horizontalInput = inputProvider.GetHorizontalInput();
        
        if (horizontalInput == InputProvider.Direction.Rigth)
            rocket.velocity = new Vector2(rocketSpeed, rocket.velocity.y);
        if (horizontalInput == InputProvider.Direction.Left)
            rocket.velocity = new Vector2(-rocketSpeed, rocket.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (lose)
            return;
        if (target.tag == "ExtraFuelBoost") {
            if (!initialBoost) //jeśli nie ma boosta na start !
            {
                initialBoost = true;
                rocket.velocity = new Vector2(rocket.velocity.x, 18f);
                target.gameObject.SetActive(false);
                soundManager.instance.boostSoundEfects();

                //wyjście z triggera ze wzgledu na boost startowy

                return;
            } // start
        }

        if (target.tag == "StarBoost") {
            rocket.velocity = new Vector2(rocket.velocity.x, starBoost);
            target.gameObject.SetActive(false);
            boostCount++;
        }

        if (target.tag == "ExtraFuelBoost") {
            rocket.velocity = new Vector2(rocket.velocity.x, extraFuelBoost);
            target.gameObject.SetActive(false);
            boostCount++;
            soundManager.instance.boostSoundEfects();
        }

        if (boostCount == 2) {
            boostCount = 0;
            spawnerAttacherow.instance.spawner();
        }

        if (target.tag == "Upadek" || target.tag == "Meteor") {
            lose = true;
            GameManager.instance.Restart();
            soundManager.instance.gameOverSoundEfects();
            fire.SetActive(false);
            scoreManager.scoreIncreasing = false;
        }
    } // odpala się na trigger
}