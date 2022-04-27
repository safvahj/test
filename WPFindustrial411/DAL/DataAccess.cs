using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

//负责数据访问
namespace WPFindustrial411.DAL
{
    public class DataAccess
    {
        string dbConfig = ConfigurationManager.ConnectionStrings["db_config"].ToString();
        MySqlConnection conn;
        MySqlCommand comm;
        MySqlDataAdapter adapter;
        MySqlTransaction transaction;

        //对象销毁
        private void Dispose()
        {
            if(adapter != null)
            {
                adapter.Dispose();
                adapter = null;
            }
            if(comm != null)
            {
                comm.Dispose();
                comm = null;
            }
            if(transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }
            if(conn != null)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }

        //获取数据
        private DataTable GetDatas(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                conn = new MySqlConnection(dbConfig);
                //如果Open失败会进入异常
                conn.Open();

                adapter = new MySqlDataAdapter(sql, conn);
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Dispose();
            }
            return dt;
        }

        //代替例程里的storage_area表,视频5
        public DataTable GetStorageArea()
        {
            string strSql = "select * from storage_area";
            return this.GetDatas(strSql);
        }

        //代替例程里的devices表
        public DataTable GetDevices()
        {
            string strSql = "select * from devices";
            return this.GetDatas(strSql);
        }

        //代替例程里的Monitor_values
        public DataTable GetMonitorValues()
        {
            string strSql = "select * from monitor_values ORDER BY d_id,value_id";
            return this.GetDatas(strSql);
        }   
    }
}
