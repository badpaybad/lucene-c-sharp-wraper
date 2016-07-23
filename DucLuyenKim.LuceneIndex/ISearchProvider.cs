using System.Collections.Generic;

namespace DucLuyenKim.LuceneIndex
{
    public interface ISearchProvider
    {
        IList<T> SearchByKeywords<T>(string keywords);

    }

   

}

/*
 * http://lucene.apache.org/core/2_9_4/queryparsersyntax.html#Wildcard%20Searches
 * Escaping Special Characters

Lucene supports escaping special characters that are part of the query syntax. The current list special characters are

+ - && || ! ( ) { } [ ] ^ " ~ * ? : \

To escape these character use the \ before the character. For example to search for (1+1):2 use the query:

\(1\+1\)\:2


*/