public class BookReference
{
    public readonly BookPlacement BookshelfPlacementInfo;
    public readonly int BookIdx;

    public BookReference(BookPlacement bookshelfPlacementInfo, int bookIdx)
    {
        BookshelfPlacementInfo = bookshelfPlacementInfo;
        BookIdx = bookIdx;
    }
}
