using UnityEngine;

namespace UI
{
    public class OpenBookLink : MonoBehaviour
    {
        public void OpenBookInBrowser()
        {
            BookInfo selectedBookInfo = SelectedBookState.GetSelectedBookInfo();
            if (selectedBookInfo == null)
            {
                Debug.LogError("Tried to open book link while there was no book selected.");
                return;
            }
            
            Application.OpenURL(selectedBookInfo.link);
        }
    }
}