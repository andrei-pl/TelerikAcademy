namespace BullsAndCows.WCF
{
    using BullsAndCows.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUsersService" in both code and config file together.
    [ServiceContract]
    public interface IUsersService
    {
        [OperationContract]
        IEnumerable<User> ReturnFirst10Users();

        [OperationContract]
        IEnumerable<User> ReturnFirst10Users(int page);

        [OperationContract]
        User ReturnUserById(int id);
    }
}
