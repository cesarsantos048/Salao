using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;



namespace App.Extensions
{
    public class Paginacao
    {
        public static string QueryStringToParams(int pagina, HttpRequest request)
        {
            string query = request.Path.ToString();
            Regex regex = new Regex("page.*?&");
            query = regex.Replace(query, "");

            regex = new Regex("ALL_HTTP.*");
            query = regex.Replace(query, "");

            return query + "?page=" + pagina + "&";


        }
    }
}
