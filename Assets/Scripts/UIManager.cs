using UnityEngine;
using UnityEngine.UI;


// This script checks if the user clicked on a planet then display a panel that has the name of clicked planet
public class UIManager : MonoBehaviour
{
    public static UIManager sharedInstance = null;
    [SerializeField] GameObject panelPrefab;
    [SerializeField] GameObject parentCanvas;
    private Text text;
    private GameObject panel;
    private bool created = false;

    private void Awake()
    {
        if(sharedInstance != null && sharedInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            sharedInstance = this;
        }
    }

    //create a panel. If already created just change the name of planet
    public void InstantiatePanel(string planetName)
    {
        if(created == false) 
        { 
        panel = Instantiate(panelPrefab);
        panel.transform.SetParent(parentCanvas.transform, false);
        text = panel.transform.GetChild(0).GetComponent<Text>();
        text.text = planetName;
        created = true;
        }

        else
        {
            text.text = planetName;
        }
    }

    //Destroy the panel when user has pressed exit button
    public void DestroyUI()
    {
        Destroy(panel);
        created = false;
    }
    
}
