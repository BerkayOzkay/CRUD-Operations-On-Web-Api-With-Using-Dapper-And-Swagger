using Dapper;
using DapperWeb.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperWeb.Repo
{
    public class Office : IOffice
    {
        private string _ConnectionString;

        public Office(IConfiguration configuration)
        {
            _ConnectionString = configuration.GetConnectionString("Default");
        }
        public async Task<Staff> Create(Staff staff)
        {
            var sqlQuery = "INSERT INTO OfisAraclari(SiparisKod,Miktar,Ad,Maliyet) VALUES (@SiparisKod,@Miktar,@Ad,@Maliyet)";
            using (var connection=new SqlConnection(_ConnectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new
                { 
                staff.SiparisKod,
                staff.Miktar,
                staff.Ad,
                staff.Maliyet
                });

                return staff;
            }
        }

        public async Task Delete(Guid ID)
        {
            var sqlQuery = "DELETE FROM OfisAraclari WHERE SiparisKod=@SiparisKod";
            using (var connection = new SqlConnection(_ConnectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new
                {
                    SiparisKod = ID
                }) ;
            }
        }

        public async Task<IEnumerable<Staff>> Get()
        {
            var sqlQuery = "select * from OfisAraclari ";

            using (var connection=new SqlConnection(_ConnectionString))
            {
                return await connection.QueryAsync<Staff>(sqlQuery);
            }
        }

        public async Task<Staff> Get(Guid ID)
        {
            var sqlQuerry = "SELECT * FROM OfisAraclari WHERE SiparisKod=@SiparisKod";

            using (var connection = new SqlConnection(_ConnectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Staff>(sqlQuerry, new
                {
                    SiparisKod = ID

                }) ;
            
            }

        }

        public async Task Update(Staff staff)
        {
            var sqlQuerry = "UPDATE OfisAraclari SET Miktar=@Miktar, Ad=@Ad, Maliyet=@Maliyet Where SiparisKod=@SiparisKod";

            using (var connection = new SqlConnection(_ConnectionString))
            {
                await connection.ExecuteAsync(sqlQuerry, new
                {
                    staff.SiparisKod,
                    staff.Miktar,
                    staff.Ad,
                    staff.Maliyet

                });
            }
        }
    }
}
