using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;
/// <summary>
/// Summary description for HR_DbGeneral
/// </summary>
namespace OCM
{
    public class OCM_DbGeneral
    {
        private SqlTransaction trans;
        private SqlCommand tranCommand = new SqlCommand();
        private SqlDataAdapter da = null;
        private SqlCommand cmd = null;
        protected SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["INVCon"].ConnectionString);
        public OCM_DbGeneral()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataTable SelectRecords(string query)
        {
            SqlDataAdapter da = new SqlDataAdapter(query, con);            
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void ExecuteQuery(string query)
        {
            SqlCommand com = new SqlCommand(query, con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public void ExecuteQuery(StringBuilder query)
        {
            SqlCommand com = new SqlCommand(query.ToString(), con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public int SelectMaxID(string tblName, string colName)
        {
            int maxID = 0;
            SqlCommand cmd = new SqlCommand("select isnull(max(" + colName + "),0)+1 from " + tblName, con);
            con.Open();
            maxID = (int)cmd.ExecuteScalar();
            con.Close();
            return maxID;
        }
        public SqlConnection Connection
        {
            get
            {
                return con;
            }
        }
        public void Reseed(string tablename, string colname)
        {
            string query = @"declare @ID int set @ID=(select isnull(max(" + colname + "),0) from " + tablename + ")" + " DBCC CHECKIDENT (" + tablename + ", reseed, @ID)";
            SqlCommand com = new SqlCommand(query, con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public void openConnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        //Transaction
        public void BeginTransaction()
        {
            openConnection();
            tranCommand = new SqlCommand();
            tranCommand.Connection = con;
            trans = con.BeginTransaction();
            tranCommand.Transaction = trans;
        }
        public void EndTransaction()
        {
            trans.Commit();
            con.Close();
        }
        public void RollBackTransaction()
        {
            trans.Rollback();
        }

        public void ExecuteTransCommand(string query)
        {
            tranCommand.CommandText = query;
            tranCommand.ExecuteNonQuery();
        }
        public void tranReseed(string tablename, string colname)
        {
            tranCommand.CommandText = @"declare @ID int set @ID=(select isnull(max(" + colname + "),0) from " + tablename + ")" + " DBCC CHECKIDENT (" + tablename + ", reseed, @ID)";
            tranCommand.ExecuteNonQuery();
        }
        public DataTable ExecuteSelectTransCommand(string query)
        {
            DataTable dt = new DataTable();
            tranCommand.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(tranCommand);
            da.Fill(dt);
            return dt;
        }
        public string tranMaxID(string TableName, string ColumnName)
        {
            tranCommand.CommandText = "select isnull(Max(" + ColumnName + "),0)+1 from " + TableName;
            if (con.State == ConnectionState.Closed)
                openConnection();
            return tranCommand.ExecuteScalar().ToString();
        }
        public string ExecuteTranScaller(string query)
        {
            tranCommand.CommandText = query;
            openConnection();
            try
            {
                return tranCommand.ExecuteScalar().ToString();
            }
            catch (NullReferenceException exc)
            {
                return "0";
            }
        }
        public DataTable ExecuteSelectStoreProcedure(string procedureName, SqlParameter[] commandParameter, bool parm)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            openConnection();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedureName;
            if (parm == true)
            {
                foreach (SqlParameter param in commandParameter)
                { cmd.Parameters.Add(param); }
            }
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;

        }
        public void ExecuteTransStoreProcedure(string procedureName, SqlParameter[] commandParameter, bool parm)
        {
            tranCommand.CommandType = CommandType.StoredProcedure;
            tranCommand.CommandText = procedureName;

            tranCommand.Parameters.Clear();
            if (parm == true)
            {
                foreach (SqlParameter param in commandParameter)
                { tranCommand.Parameters.Add(param); }
            }
            tranCommand.ExecuteNonQuery();
        }
        public string ExecuteTransStoreProcedureReturn(string procedureName, SqlParameter[] commandParameter, bool parm, string ouputParm)
        {
            tranCommand.CommandType = CommandType.StoredProcedure;
            tranCommand.CommandText = procedureName;
            tranCommand.Parameters.Clear();
            if (parm == true)
            {
                foreach (SqlParameter param in commandParameter)
                { tranCommand.Parameters.Add(param); }
            }
            tranCommand.ExecuteNonQuery();
            return tranCommand.Parameters[ouputParm].Value.ToString();
        }
        public string[] ExecuteTransStoreProcedureReturnArray(string procedureName, SqlParameter[] commandParameter, bool parm, string[] ouputParm)
        {
            tranCommand.CommandType = CommandType.StoredProcedure;
            tranCommand.CommandText = procedureName;
            tranCommand.Parameters.Clear();
            if (parm == true)
            {
                foreach (SqlParameter param in commandParameter)
                { tranCommand.Parameters.Add(param); }
            }
            tranCommand.ExecuteNonQuery();
            string[] arr = new string[ouputParm.Length];
            int cnt=0;
            foreach (string s in ouputParm) {
                arr[cnt] = tranCommand.Parameters[s].Value.ToString();
                cnt++;
            }
            return arr;
        }
        public DataTable ExecuteTransStoreProcedureReturnTable(string procedureName, SqlParameter[] commandParameter, bool parm)
        {
                tranCommand.CommandType = CommandType.StoredProcedure;
                tranCommand.CommandText = procedureName;
                tranCommand.Parameters.Clear();
                if (parm == true)
                {
                    foreach (SqlParameter param in commandParameter)
                    { tranCommand.Parameters.Add(param); }
                }

                DataTable dt = new DataTable();                
                SqlDataAdapter da = new SqlDataAdapter(tranCommand);
                da.Fill(dt);
                return dt;
           
        }

        public string ExecuteScaller(string query)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            openConnection();
            try
            {
                return cmd.ExecuteScalar().ToString();
            }
            catch (NullReferenceException exc)
            {
                return "0";
            }
        }
        public void FillListBox(System.Web.UI.WebControls.ListBox lstbox, string sQuery, string VMember, string DMember)
        {
            da = new SqlDataAdapter(sQuery, con);
            DataTable dt2 = new DataTable();
            da.Fill(dt2);
            lstbox.DataSource = dt2;
            lstbox.DataTextField = DMember;
            lstbox.DataValueField = VMember;
            lstbox.DataBind();
        }
    }
}