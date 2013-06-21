using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using Thinktecture.IdentityServer;

namespace Sagrada.IdentityServer.Module.Repositories
{
    public class SagradaIdentityService : ISagradaIdentityService
    {
        private const string SQL_GET_PROFILE = "SELECT " +
                                                "	PR.Id, " +
                                                "	PR.PartyRoleProfileName" +
                                                "  FROM PartyRoleProfiles PR  INNER JOIN" +
                                                "		SagradaUsers SU ON PR.id_SagradaUser = SU.ID " +
                                                "WHERE SU.Username = @P1 AND SU.IsEnabled = 1";

        private const string SQL_GET_ROLES = "SELECT " +
                                             "   P.ProfileName " +
                                             "FROM PartyRoleProfiles PR  INNER JOIN " +
                                             "     SagradaUsers SU ON PR.id_SagradaUser = SU.ID INNER JOIN " +
                                             "     Profiles P ON PR.id_Profile = P.Id " +
                                             "WHERE SU.Username = @P1";

        private const string SQL_GET_COMPANIES = "SELECT CompanyCode, GenericName FROM Companies ORDER BY GenericName";


        private string CONN_STR = String.Empty;

        public SagradaIdentityService()
        {
            CONN_STR = ConfigurationManager.ConnectionStrings["SqlServerRecupera"].ConnectionString;
        }

        public IEnumerable<Tuple<Guid, string>> GetProfiles(string userName)
        {
            List<Tuple<Guid, string>> pReturn = new List<Tuple<Guid, string>>();
            try
            {
                using (SqlConnection con = new SqlConnection(CONN_STR))
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(SQL_GET_PROFILE, con);
                        command.CommandType = System.Data.CommandType.Text;
                        command.Parameters.Add(new SqlParameter("@P1", userName));
                        con.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                pReturn.Add(Tuple.Create<Guid, string>(
                                                                       reader.GetGuid(0),
                                                                       reader.GetString(1)
                                                                       ));
                            }
                        }
                    }
                    finally
                    {

                        if (con.State != System.Data.ConnectionState.Closed)
                            con.Close();
                    }
                }

                return pReturn;
            }
            catch (Exception ex)
            {
                //swallow exception return empty list
                Tracing.Error(ex.Message);
            }

            return new List<Tuple<Guid, string>>();
        }

        public IEnumerable<Tuple<byte, string>> GetCompanies()
        {
            try
            {

                List<Tuple<byte, string>> pReturn = new List<Tuple<byte, string>>();

                using (SqlConnection con = new SqlConnection(CONN_STR))
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(SQL_GET_COMPANIES, con);
                        command.CommandType = System.Data.CommandType.Text;
                        con.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                pReturn.Add(Tuple.Create<byte, string>(
                                                                       reader.GetByte(0),
                                                                       reader.GetString(1)
                                                                       ));
                            }
                        }
                    }
                    finally
                    {

                        if (con.State != System.Data.ConnectionState.Closed)
                            con.Close();
                    }
                }

                return pReturn;
            }
            catch (Exception ex)
            {
                //swallow exception return empty list
                Tracing.Error(ex.Message);
            }
            return new List<Tuple<byte, string>>();
        }

        public IEnumerable<System.Globalization.CultureInfo> GetLanguages()
        {
            try
            {
                return new CultureInfo[] { new CultureInfo("IT-it") };//è brutto dovrebbe esser preso dal profilo !!!
            }
            catch (Exception ex)
            {
                //swallow exception return empty list
                Tracing.Error(ex.Message);
            }
            return new CultureInfo[0];

        }


        public string[] GetRoles(string userName)
        {
            try
            {
                List<string> pReturn = new List<string>();

                using (SqlConnection con = new SqlConnection(CONN_STR))
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(SQL_GET_ROLES, con);
                        command.CommandType = System.Data.CommandType.Text;
                        command.Parameters.Add(new SqlParameter("@P1", userName));
                        con.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                                pReturn.Add(reader.GetString(0));

                        }
                    }
                    finally
                    {

                        if (con.State != System.Data.ConnectionState.Closed)
                            con.Close();
                    }
                }

                return pReturn.ToArray();
            }
            catch (Exception ex)
            {
                //swallow exception return empty list
                Tracing.Error(ex.Message);
            }
            return new string[0];
        }
    }
}
