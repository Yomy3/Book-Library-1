using System;

namespace Project_Book.Model
{
    public class Book
    {// tipo data fecha de publicación, tipo bool disponible o no,
     // un objeto de tipo autor con nombre del autor y fecha de nacimiento del autor,
     // ademas de los otros objetos de la base de dato ya hecha Title, ISBN, Category, Description, Id

        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int Available { get; set; }
        public DateTime Published { get; set; }
        public Author Author { get; set; }

        public Publisher Publisher { get; set; }

        public override string ToString() 
        {
            return "Title:\t"+Title+"\n ISBN:\t "+ISBN+"\nPublished:\t "+Published+"\nAuthor:\t "+Author+"\nPubisher:\t "+Publisher+"";
        }
       
    }


}
