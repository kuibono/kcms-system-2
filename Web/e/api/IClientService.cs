using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Voodoo.Basement;

namespace Web.e.api
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IClientService”。
    [ServiceContract]
    public interface IClientService
    {
        [OperationContract]
        List<Book> BookSearch(string str_sql);

        [OperationContract]
        bool BookExist(string str_sql);

        [OperationContract]
        Book BookFind(string str_sql);

        [OperationContract]
        Book GetBookByID(int id);

        [OperationContract]
        Book BookInsert(Book book);

        [OperationContract]
        void BookUpdate(Book book);

        [OperationContract]
        void BookDelete(string str_sql);

        [OperationContract]
        List<Class> ClassSearch(string str_sql);

        [OperationContract]
        Class ClassFind(string str_sql);

        [OperationContract]
        Class GetClassByID(int id);

        [OperationContract]
        Class ClassInsert(Class cls);

        [OperationContract]
        void ClassUpdate(Class cls);

        [OperationContract]
        void ClassDelete(string str_sql);


        [OperationContract]
        List<BookChapter> ChapterSearch(string str_sql);

        [OperationContract]
        bool ChapterExist(string str_sql);

        [OperationContract]
        BookChapter ChapterFind(string str_sql);

        [OperationContract]
        BookChapter GetChapterByID(long id);

        [OperationContract]
        void ChapterInsert(BookChapter chapter, string Content);

        [OperationContract]
        void ChapterUpdate(BookChapter chapter, string Content);

        [OperationContract]
        void ChapterDelete(string str_sql);

        [OperationContract]
        string GetChapterText(BookChapter chapter);

        [OperationContract]
        void CreateIndex();

        [OperationContract]
        void CreateClassPage();

        [OperationContract]
        void CreateBookPage(Book book);


    }
}
