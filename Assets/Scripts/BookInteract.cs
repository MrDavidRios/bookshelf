using System;
using UnityEngine;

public class BookInteract : MonoBehaviour
{
    public static event Action OnBookOpen;
    
    private BookReference _bookReference;

    public void InitializeBookInteraction(BookReference bookReference)
    {
        _bookReference = bookReference;
    }

    public void OnBookInteract()
    {
        if (_bookReference == null)
        {
            Debug.LogError("Tried to interact with uninitialized book.");
            return;
        }
        
        SelectedBookState.SetSelectedBook(_bookReference);
        
        OnBookOpen?.Invoke();
    }
}
