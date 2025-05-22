using UnityEngine;

public class SelectedBookState : MonoBehaviour
{
    public static BookReference SelectedBook;

    public static void SetSelectedBook(BookReference bookReference)
    {
        SelectedBook = bookReference;
    }
    
    public static void ClearSelectedBook()
    {
        SelectedBook = null;   
    }

    public static BookInfo GetSelectedBookInfo()
    {
        Debug.Assert(SelectedBook != null);
        Debug.Assert(SelectedBook.BookshelfPlacementInfo != null);
        Debug.Assert(SelectedBook.BookIdx >= 0);
        Debug.Assert(SelectedBook.BookshelfPlacementInfo.books[SelectedBook.BookIdx] != null);
        Debug.Assert(SelectedBook.BookshelfPlacementInfo.books[SelectedBook.BookIdx].GetComponent<BookInfo>() != null);

        return SelectedBook.BookshelfPlacementInfo.books[SelectedBook.BookIdx]?.GetComponent<BookInfo>();
    }
}
