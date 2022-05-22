using Npgsql;
using Dapper;
using Domain;

namespace Service
{
    public class QuoteService
    {
        private string connectionString = "Server=localhost;Port=5432;Database=Examen;User Id=postgres;Password=MyData;";
        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }
        public List<Quote> GetQuote()
        {
            using (var con = GetConnection())
            {
                var sql = " select Q.Id  as  QuoteId , Q.Author as QuoteAuthor , Q.QuoteText, C.Id as CategoryId, C.Name as CategoryName " +
                          " from Quote as Q " +
                          " join Category as C on C.Id=Q.CategoryId ";
                var list = con.Query<Quote>(sql);
                return list.ToList();
            }
        }
        public List<Quote> GetQuoteByCategoryId(int Id)
        {
            using (var con = GetConnection())
            {
                var sql = $" select Q.Id as  QuoteId ,Q.Author as QuoteAuthor ,Q.QuoteText,C.Id as CategoryId,C.Name as CategoryName " +
                          $" from Quote as Q " +
                          $" join Category as C on C.Id=Q.CategoryId  Where C.Id={Id}";
                var list = con.Query<Quote>(sql);
                return list.ToList();
            }
        }
        public int InsertQuote(Quote quote)
        {
            using (var con=GetConnection())
            {
                var sql = $" Insert into Quote(Author,QuoteText,CategoryId) " +
                          $" values('{quote.Author}','{quote.QuoteText}',{quote.CategoryId}) ";
                var insert = con.Execute(sql);
                return insert;
            }
        }

        public int UpdateQuote(Quote quote,int Id)
        {
            using (var con=GetConnection())
            {
                var sql = $" Update Quote  " +
                          $" Set  " +
                          $" Author='{quote.Author}' ,  " +
                          $" QuoteText='{quote.QuoteText}' , " +
                          $" CategoryId={quote.CategoryId}  " +
                          $" Where Id={Id} ";
                var update = con.Execute(sql);
                return update;
            }
        }

        public int DeleteQuote(int Id)
        {
            using (var con = GetConnection())
            {
                var sql = $" Delete from Quote where Id={Id} ";
                var delete = con.Execute(sql);
                return delete;

            }
        }

    }
}
