using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //tämä pitää olla että saa UI tekstit näkyviin
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed;
    float movementX;
    float movementZ;

    int score;

    public GameObject rajahdys; //kun pelaaja osuu objektiin missä triggeri niin räjähtää

    public Text tulostaulu;
    public Text voittoteksti;

    Vector3 movement;


    Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb= GetComponent<Rigidbody>();
        voittoteksti.gameObject.SetActive(false);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) { //R näppäimellä saa realoadattua pelin
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
    
        
    
    // Update is called once per frame
    void FixedUpdate () {
        movementX = Input.GetAxisRaw("Horizontal");
        movementZ = Input.GetAxisRaw("Vertical");

        movement = new Vector3(movementX, 0, movementZ);

        rb.AddForce(movement * speed);
	}
    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Kollektiipeli")){ //lisää objekteille tagi Unityssä
            score = score + 1; //lisää jokaisen kerätyn objektin jälkeen pisteen tulostauluun voi olla myös kirjoitettu ++
            PaivitaTulostaulu();
            Instantiate(rajahdys, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }

    void PaivitaTulostaulu(){
        tulostaulu.text = score.ToString();

        if(score >= 6) { //kun pelaaja on kerännyt kaikki 6 (tai kuinka monta kerättävää objektia onkaan kentällä) niin silloin tulee teksti "voitit pelin"
            voittoteksti.gameObject.SetActive(true);
        }
    }
}
