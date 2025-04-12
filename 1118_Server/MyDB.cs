using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace _1118_Server
{
    internal class MyDB
    {
        private MySqlConnection conn = null;

        private const string servername = "127.0.0.1";// "127.0.0.1";  //localhost
        private const string dbname = "wb40";
        private const string userid = "junwo";
        private const string userpw = "1234";

        #region 데이터베이스 연결 및 종료
        public bool Open()
        {
            try
            {
                string constr = string.Format(@"Data Source={0};Initial Catalog={1};User ID={2};Password={3}", servername, dbname, userid, userpw);
                conn = new MySqlConnection(constr);
                conn.Open();
                return true;
            }
            catch
            {               
                return false;
            }
        }
        public bool Close()
        {
            conn.Close();
            return false;
        }
        #endregion

        #region 회원저장
        public bool MemberInsert(string id, string nickname, string password)
        {
            string query = string.Format($"INSERT INTO wb40.membertbl(MemberId, MemberNickname, MemberPassword) VALUES('{id}', '{nickname}', '{password}');");
            return ExecuteNonQuery(query);
        }

        private bool ExecuteNonQuery(string sql)
        {
            bool b = false;
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {               
                if (cmd.ExecuteNonQuery() >= 1)
                    b = true;
            }
            return b;
        }
        #endregion

        #region 하나의 값을 반환
        public bool IsIdOkay(string memberid)
        {
            string query = string.Format($"select MemberId from membertbl where MemberId = '{memberid}';");
                       
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                string id = (string)cmd.ExecuteScalar();
                if(id == null)
                    return true;
                else
                    return false;
            }           
        }

        public bool IsNameOkay(string membernickname)
        {
            string query = string.Format($"select MemberId from membertbl where MemberNickname = '{membernickname}';");

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                string id = (string)cmd.ExecuteScalar();
                if (id == null)
                    return true;
                else 
                    return false;
            }
        }

        public bool Login(string memberid, string memberpassword)
        {
            string query = string.Format($"select MemberId from membertbl where MemberId = '{memberid}' AND MemberPassword = '{memberpassword}' ;");

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                string id = (string)cmd.ExecuteScalar();
                if (id != null)
                    return true;
                else
                    return false;
            }
        }
        #endregion

        #region 검색기능
        //SELECT userName, userPhone, userDate FROM usertbl WHERE userID = '4';
        public string SelectUserId(string MemberId)
        {
            string query = string.Format($"SELECT MemberNickname, Member1rd, Member2rd, Member3rd FROM membertbl WHERE MemberId = '{MemberId}';");

            string temp = null;
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                //cmd.CommandType = System.Data.CommandType.Text;
                MySqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    string userName = r["MemberNickname"].ToString();
                    string user1rd = r["Member1rd"].ToString();
                    string user2rd = r["Member2rd"].ToString();
                    string user3rd = r["Member3rd"].ToString();

                    temp = userName + "#" + user1rd + "#" + user2rd + "#" + user3rd;
                }
                r.Close();  //***
            }
            return temp;
        }
        #endregion

        #region 결과 변환
        public bool User1rd(string userid)
        {
            string query = string.Format($"UPDATE membertbl SET Member1rd = Member1rd + 1 WHERE MemberId = '{userid}';");
            return ExecuteNonQuery(query);
        }

        public bool User2rd(string userid)
        {
            string query = string.Format($"UPDATE membertbl SET Member2rd = Member2rd + 1 WHERE MemberId = '{userid}';");
            return ExecuteNonQuery(query);
        }

        public bool User3rd(string userid)
        {
            string query = string.Format($"UPDATE membertbl SET Member3rd = Member3rd + 1 WHERE MemberId = '{userid}';");
            return ExecuteNonQuery(query);
        }
        #endregion
    }

}
