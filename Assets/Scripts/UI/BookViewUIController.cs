using TMPro;
using UnityEngine;

namespace UI
{
    public class BookViewUIController : MonoBehaviour
    {
        [SerializeField] private GameObject viewUI;

        [SerializeField] private TMP_Text viewUITitle;

        private void OnEnable()
        {
            BookInteract.OnBookOpen += UpdateUI;
        }
        
        private void OnDisable()
        {
            BookInteract.OnBookOpen -= UpdateUI;
        }

        private void UpdateUI()
        {
            if (SelectedBookState.SelectedBook == null)
            {
                Debug.LogError("Tried to update book view UI while there was no book selected.");
                return;
            }
            
            PlayerState.DisableMovement();
            viewUI.SetActive(true);
        }
    }
}