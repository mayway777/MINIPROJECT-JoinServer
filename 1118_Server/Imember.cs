using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace _1118_Server
{
    [ServiceContract]
    internal interface Imember
    {
        [OperationContract]
        bool InsertMember(string id, string name, string password);

        [OperationContract]
        bool Login(string userid, string password);

        [OperationContract]
        bool IsIdOkay(string id);

        [OperationContract]
        bool IsNameOkay(string name);

        [OperationContract]
        string GetUserInformation(string userid);

        [OperationContract]
        bool User1rd(string userid);

        [OperationContract]
        bool User2rd(string userid);

        [OperationContract]
        bool User3rd(string userid);
    }
}
