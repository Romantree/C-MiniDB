using Oracle.DataAccess.Client;
using System;
using System.Windows.Forms;

namespace AddrBook
{
    internal class Common_DB
    {
        //DataBase Connection

        public static OracleConnection DBConnection()
        {
            OracleConnection Conn;


            //64비트
            //string ConStr = "Provider=OraOLEDB.Oracle; data source=orcl;User ID=scott;Password=tiger";
            //ODP.NETm 오라클 전용
            string Constr = "data source=orcl;user id=scott; password=tiger";

            Conn = new OracleConnection(Constr);
            return Conn;
        }
        public static OracleDataReader DataSelect(string sql, OracleConnection Conn)
        {
            try
            {
                OracleCommand myCommand = new OracleCommand(sql, Conn);
                return myCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                //Log File에 출력
                MessageBox.Show(sql + "\n" + ex.Message, "DataSelect");
                return null;
            }
            finally
            {

            }


        }
        public static bool DataManupulation(string sql, OracleConnection Conn)
        {
            try
            {
                OracleCommand myCommand = new OracleCommand(sql, Conn);
                myCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                //Log File에 출력
                MessageBox.Show(sql + "\n" + ex.Message, "DataManupulation");
                return false;
            }
            finally
            {

            }
        }
    }
}
