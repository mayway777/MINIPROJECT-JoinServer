using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace _1118_Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    internal class MemberService : Imember
    {
        private static MyDB mydb = new MyDB();
        private static List<string> players = new List<string>();
        #region 접속처리
        public bool DBopen()
        {
            return mydb.Open();
        }

        public bool DBclose()
        {
            return mydb.Close();
        }
        #endregion

        #region 회원가입
        public bool InsertMember(string id, string name, string password)
        {
           return mydb.MemberInsert(id, name, password);
        }

        public bool IsIdOkay(string id)
        {
           return mydb.IsIdOkay(id);
        }

        public bool IsNameOkay(string name)
        {
            return mydb.IsNameOkay(name);
        }
        #endregion

        #region 로그인
        public bool Login(string userid, string password)
        {
            //foreach (string id in players)
            //{
            //    if (id == userid)
            //        return false;
            //}
            //players.Add(userid);
            return mydb.Login(userid, password);
        }
        #endregion

        #region 유저정보 가져오기
        public string GetUserInformation(string userid)
        {
            return mydb.SelectUserId(userid);
        }
        #endregion

        #region 결과 반환
        public bool User1rd(string userid)
        {
            return mydb.User1rd(userid);
        }

        public bool User2rd(string userid)
        {
            return mydb.User2rd(userid);
        }

        public bool User3rd(string userid)
        {
            return mydb.User3rd(userid);
        }
        #endregion
    }
}






















































//이스터애그