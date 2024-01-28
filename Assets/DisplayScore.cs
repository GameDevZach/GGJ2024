using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        textMesh.text = "Final Score: " + PlayerPrefs.GetInt("Points").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
