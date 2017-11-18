using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfSLPay
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IPayTranService
    {
        [OperationContract]
        Transaction GetTransaction(int ID);

        [OperationContract]
        bool UpdateTransaction(Transaction transact);

        // TODO: agregue aquí sus operaciones de servicio
    }

    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    // Puede agregar archivos XSD al proyecto. Después de compilar el proyecto, puede usar directamente los tipos de datos definidos aquí, con el espacio de nombres "WcfSLPay.ContractType".
    [DataContract]
    public class Transaction
    {

        [DataMember]
        public int TransactionID
        {
            get;
            set;
        }


        [DataMember]
        public int TransStep
        {
            get;
            set;
        }

        [DataMember]
        public string TransType
        {
            get;
            set;
        }

        [DataMember]
        public decimal TransAmount
        {
            get;
            set;
        }

        [DataMember]
        public string TransNameOrig
        {
            get;
            set;
        }

        [DataMember]
        public decimal TransOldbalanceOrg
        {
            get;
            set;
        }

        [DataMember]
        public decimal TransNewbalanceOrig
        {
            get;
            set;
        }

        [DataMember]
        public string TransNameDest
        {
            get;
            set;
        }

        [DataMember]
        public decimal TransOldbalanceDest
        {
            get;
            set;
        }

        [DataMember]
        public decimal TransNewbalanceDest
        {
            get;
            set;
        }

        [DataMember]
        public int TransIsFraud
        {
            get;
            set;
        }

        [DataMember]
        public int TransIsFlaggedFraud
        {
            get;
            set;
        }
    }
}
