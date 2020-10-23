using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammare : MonoBehaviour
{
    Rigidbody bonk;

    [SerializeField] [Range(1, 100)] float xrange;
    [SerializeField] [Range(1, 100)] float zrange;

    [SerializeField]
    GameObject mouseObject = null;
    public float mouseX;

    void Start()
    {
        bonk = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;

        Vector3 mousePosition = Input.mousePosition; //Gör positionen av muspekaren till en vector3
        mousePosition.z = 10f; 
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); //Konverterar muspekarens position till spel världens
        float px = Mathf.Clamp(mousePosition.x, -xrange, xrange);
        float pz = Mathf.Clamp(mousePosition.z, -zrange, zrange);
        mouseObject.transform.position = new Vector3(px, 2, pz); //Gör så att det valda objektet rör sig med musens input men bara på x och z axlarna
    }

}
