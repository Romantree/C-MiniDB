using Oracle.DataAccess.Client;
using System;

using System.Windows.Forms;

namespace AddrBook
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private OracleConnection LocalConn;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            OracleDataReader myReader; //셀렉트 쿼리를 받을 핸들
            string sql = null;

            try
            {

                LocalConn = Common_DB.DBConnection();
                LocalConn.Open();

                if (txtID.Text == "'" || txtPWD.Text == "'")
                {
                    MessageBox.Show("ID 또는 Password를 입력하세요.");
                    return;
                }

                sql = "select pwd from member2 ";
                sql += "where id = " + "'" + txtID.Text + "'";

                myReader = Common_DB.DataSelect(sql, LocalConn);
                if (myReader.Read())
                {
                    if (txtPWD.Text != myReader["pwd"].ToString())
                    {
                        MessageBox.Show("Password가 맞지 않습니다.");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("등록되지 않은 ID 입니다.");
                    return;
                }
                //정상
                FrmMDIMain m = new FrmMDIMain();
                m.Show();
                this.Hide();
                Log.WriteLine("FrmLogin", "[로그인 : " + txtID.Text + "]");
            }
            catch (Exception e1)

            {
                Log.WriteLine("FrmLogin", e1.ToString());
                Log.WriteLine("FrmLogin", sql);
                MessageBox.Show("FrmLogin", "로그인 오류!" + e1.ToString());

            }

        }
    }
}
