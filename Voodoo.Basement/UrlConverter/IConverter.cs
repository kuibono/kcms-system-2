using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Voodoo.Basement.UrlConverter
{
    interface IConverter
    {
        string GetNewsUrl(News news, Class cls);

        string GetImageUrl(ImageAlbum img, Class cls);

        string GetQuestionUrl(Question qs, Class cls);

        string GetBookUrl(Book b, Class cls);

        string GetBookChapterUrl(BookChapter cp, Class cls);

        string GetBookChapterTxtUrl(BookChapter cp, Class cls);

        string GetMovieUrl(MovieInfo b, Class cls);

        string GetMovieDramaUrl(MovieUrlBaidu b, Class cls);

        string GetMovieDramaUrl(MovieUrlKuaib b, Class cls);

        string GetMovieDramaUrl(MovieDrama b, Class cls);

        string GetClassUrl(Class cls);

        string GetClassUrl(Class cls, int page);
    }
}
