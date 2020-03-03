using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ballscript : MonoBehaviour
{
    public GameObject tile;
    public Text txt1;
    public Text txt2;


    // Start is called before the first frame update
    void Start()
    {
        txt1.enabled = false;
        txt2.enabled = false;

        GameObject newtile;
        for (int i = 0 ; i < 20 ; i++)
        {
            newtile = Instantiate(tile, tile.transform.position + new Vector3(0, -0.9f*(i+1), 0), Quaternion.identity);
            newtile.name = "tile" + i;
            newtile.transform.Rotate(new Vector3(0, 5 * i, 0));
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < Camera.main.transform.position.y)
        {
            Vector3 pos = Camera.main.transform.position;
            pos.y = transform.position.y;
            Camera.main.transform.position = pos;
        } 
    }
    int count = 0;
    private void OnCollisionEnter(Collision collision)
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 200, 0));

        Debug.Log(collision.gameObject.transform.eulerAngles.y);

        if ((Input.GetKey("space")))
        {
            if (collision.gameObject.transform.eulerAngles.y * 1f < 200 && collision.gameObject.transform.eulerAngles.y * 1f > 100)
            {
                count++;
                Destroy(collision.gameObject);
            }

            else
            {
                Time.timeScale = 0;
                txt1.enabled = true;
                Debug.Log("Oyun Bitti.");
                if((Input.GetKey("space"))){
                    SceneManager.LoadScene(0);
                }
            }
        } 
        else if(count == 21){
            Debug.Log("Oyun.");
            txt1.enabled = true;

        }
                  
    }

}
