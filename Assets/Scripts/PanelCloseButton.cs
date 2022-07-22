using UnityEngine;


public class PanelCloseButton : MonoBehaviour
{
    // Close the panel
    public void OnClick()
    {
        UIManager.sharedInstance.DestroyUI();
    }
}
