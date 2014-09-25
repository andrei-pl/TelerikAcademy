namespace WCF.ServiceLibrary
{
    using System;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using WCF.ServiceLibrary.Models;

    [ServiceContract]
    //[ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall)]
    public interface IStringOperations
    {
        [OperationContract]
        //[WebGet(UriTemplate = "", ResponseFormat=WebMessageFormat.Json)] //for working with REST
        //[WebInvoke(Method="POST", ResponseFormat = "Json")]
        int CountWordOccuresInText(TextCounter text, string searchedWord);
    }
}
