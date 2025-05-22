using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class BookPlacement : MonoBehaviour
{
    [SerializeField] private GameObject bookPrefab;
    
    public int bookAmount = 5;

    public float horizontalBookOffset = 0.4f;
    
    private List<GameObject> _books = new();

    private int _booksAdded = 0;
    
    // UI
    [SerializeField] private GameObject addBookUI;
    
    private void Start()
    {
        float lastX = 0f;
        
        for (int i = 0; i < bookAmount; i++)
        {  
            Vector3 bookPos = new Vector3(lastX + horizontalBookOffset, transform.position.y, transform.position.z); 
            GameObject book = Instantiate(bookPrefab, bookPos, Quaternion.identity);
            book.SetActive(false);
            _books.Add(book);
        }
    }

    public void AddBook()
    {
        if (_booksAdded >= bookAmount)
        {
            Debug.LogWarning("Unable to add new book: max amount of books (" + bookAmount + ") added.");
            return;
        }
        
        _books[_booksAdded].SetActive(true);
        addBookUI.SetActive(true);
        PlayerState.DisableMovement();

        // TODO: if book addition is canceled, don't add to booksAdded
        // potential solution:
        // - only add 1 to booksAdded when 'add book' button is pressed
        // - hide _books[_booksAdded] when book addition is cancelled
        _booksAdded++;
    }
}
