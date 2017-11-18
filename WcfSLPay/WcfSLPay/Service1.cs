using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfSLPay
{

    public class PayTranService : IPayTranService
    {
        /// <summary>
        /// Get a transaction filter by id using Entity framework
        /// </summary>
        /// <param name="id">Id transaction</param>
        /// <returns></returns>
        public Transaction GetTransaction(int id)
        {
            //var transactionentity= new Transaction();
            PaysisEntities contexto = new PaysisEntities();
            var transactEntity = (from t
                                     in contexto.TransactionEntities
                                  where t.ID_TRANSACTION == id
                                  select t).FirstOrDefault();

            if (transactEntity != null)
            {
                return GetDataContractTransactionFromEntity(transactEntity);
            }
            else
            {
                throw new Exception("Invalid transaction ID");
            }
        }


        /// <summary>
        /// Translate class Entity Framework to class Data Contract of Transaction
        /// </summary>
        /// <param name="tranentity">Object of TransactionEntity</param>
        /// <returns></returns>
        private Transaction GetDataContractTransactionFromEntity(TransactionEntity tranentity)
        {
            Transaction objtran = new Transaction();
            objtran.TransactionID = tranentity.ID_TRANSACTION;
            objtran.TransStep = (int)tranentity.STEP_TRANSACTION;
            objtran.TransType = tranentity.TYPE_TRANSACTION;
            objtran.TransAmount = (decimal)tranentity.AMOUNT_TRANSACTION;
            objtran.TransNameOrig = tranentity.NAMEORIG_TRANSACTION;
            objtran.TransOldbalanceOrg = (decimal)tranentity.OLDBALANCEORG_TRANSACTION;
            objtran.TransNewbalanceOrig = (decimal)tranentity.NEWBALANCEORIG_TRANSACTION;
            objtran.TransNameDest = tranentity.NAMEDEST_TRANSACTION;
            objtran.TransOldbalanceDest = (decimal)tranentity.OLDBALANCEDEST_TRANSACTION;
            objtran.TransNewbalanceDest = (decimal)tranentity.NEWBALANCEDEST_TRANSACTION;
            objtran.TransIsFraud = (int)tranentity.ISFRAUD_TRANSACTION;
            objtran.TransIsFlaggedFraud = (int)tranentity.ISFLAGGEDFRAUD_TRANSACTION;

            return objtran;

        }


        public bool UpdateTransaction(Transaction transact)
        {
            bool respuesta = false;

            PaysisEntities contexto = new PaysisEntities();
            var transactEntity = (from t
                                     in contexto.TransactionEntities
                                  where t.ID_TRANSACTION == transact.TransactionID
                                  select t).FirstOrDefault();

            if (transactEntity != null)
            {
                SetEntityTransactionFromDataContract(transactEntity,transact);

                respuesta = Convert.ToBoolean(contexto.SaveChanges());
            }
            else
            {
                respuesta = false;
            }
            return respuesta;
        }

        private void SetEntityTransactionFromDataContract(TransactionEntity tranentity, Transaction dctransaction)
        {
            tranentity.STEP_TRANSACTION = (int)dctransaction.TransStep ;
            tranentity.TYPE_TRANSACTION = dctransaction.TransType;
            tranentity.AMOUNT_TRANSACTION = (decimal)dctransaction.TransAmount;
            tranentity.NAMEORIG_TRANSACTION = dctransaction.TransNameOrig;
            tranentity.OLDBALANCEORG_TRANSACTION = (decimal)dctransaction.TransOldbalanceOrg;
            tranentity.NEWBALANCEORIG_TRANSACTION = (decimal)dctransaction.TransNewbalanceOrig;
            tranentity.NAMEDEST_TRANSACTION = dctransaction.TransNameDest;
            tranentity.OLDBALANCEDEST_TRANSACTION = (decimal)dctransaction.TransOldbalanceDest;
            tranentity.NEWBALANCEDEST_TRANSACTION = (decimal)dctransaction.TransNewbalanceDest;
            tranentity.ISFRAUD_TRANSACTION = (int)dctransaction.TransIsFraud;
            tranentity.ISFLAGGEDFRAUD_TRANSACTION = (int)dctransaction.TransIsFlaggedFraud;
        }

        //public bool UpdateProduct(Product product)
        //{
        //    /*
        //    // TODO: call business logic layer to update product
        //    if (product.UnitPrice <= 0)
        //    return false;
        //    else
        //    return true;
        //    */
        //    ProductEntity productEntity = new ProductEntity();
        //    TranslateProductContractDataToProductEntity(product, productEntity);
        //    return productLogic.UpdateProduct(productEntity);
        //}

        //private void TranslateProductEntityToProductContractData(ProductEntity productEntity,Product product)
        //{
        //    product.ProductID = productEntity.ProductID;
        //    product.ProductName = productEntity.ProductName;
        //    product.QuantityPerUnit = productEntity.QuantityPerUnit;
        //    product.UnitPrice = productEntity.UnitPrice;
        //    product.Discontinued = productEntity.Discontinued;
        //}

        //private void TranslateProductContractDataToProductEntity(Product product,ProductEntity productEntity)
        //{
        //    productEntity.ProductID = product.ProductID;
        //    productEntity.ProductName = product.ProductName;
        //    productEntity.QuantityPerUnit = product.QuantityPerUnit;
        //    productEntity.UnitPrice = product.UnitPrice;
        //    productEntity.Discontinued = product.Discontinued;
        //}
    }


}
