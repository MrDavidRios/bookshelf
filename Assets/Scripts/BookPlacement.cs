using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Utils;

public class BookPlacement : MonoBehaviour
{
    [SerializeField] private GameObject bookPrefab;
    
    public int bookAmount = 5;

    public float horizontalBookOffset = 0.13f;
    
    [HideInInspector]
    public List<GameObject> books = new();

    private int _booksAdded = 0;

    public Vector3 startPos = new Vector3(0.6f, 4.7f, 1.6f);
    
    // UI
    [SerializeField] private GameObject addBookUI;
    [SerializeField] private TMP_InputField bookLinkInput;
    
    private void Start()
    {
        float lastX = horizontalBookOffset;
        
        for (int i = 0; i < bookAmount; i++)
        {  
            GameObject book = Instantiate(bookPrefab, startPos + new Vector3(lastX + horizontalBookOffset, 0f, 0f), Quaternion.identity);
            book.transform.SetParent(transform, true);

            book.SetActive(false);
            books.Add(book);
            
            lastX = book.transform.position.x;
        }
    }

    public void BeginAddBook()
    {
        if (_booksAdded >= bookAmount)
        {
            Debug.LogWarning("Unable to add new book: max amount of books (" + bookAmount + ") added.");
            return;
        }
        
        books[_booksAdded].SetActive(true);
        addBookUI.SetActive(true);
        PlayerState.DisableMovement();

        // TODO: hide _books[_booksAdded] when book addition is cancelled
    }

    public void FinalizeBookAddition()
    {
        addBookUI.SetActive(false);
        
        GameObject book = books[_booksAdded];
        BookInfo bookInfo = book.AddComponent<BookInfo>();
        bookInfo.link = LinkProcessing.FormatLink(bookLinkInput.text);

        BookReference bookReference = new BookReference(this, _booksAdded);
        book.GetComponent<BookInteract>().InitializeBookInteraction(bookReference);
        
        PlayerState.EnableMovement();
        _booksAdded++;
    }
}
