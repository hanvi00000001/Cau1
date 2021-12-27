﻿using Cau1.DAL;
using Cau1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.BAL
{
    public class QLBHBAL
    {
        QlbhDAL dal = new QlbhDAL();
        public List<QlbhBEL> ReadCustomer()
        {
            List<QlbhBEL> lstCus = dal.ReadCustomer();
            return lstCus;
        }
        public void NewCustomer(QlbhBEL cus)
        {
            dal.NewCustomer(cus);
        }
        public void DeleteCustomer(QlbhBEL cus)
        {
            dal.DeleteCustomer(cus);
        }
        public void EditCustomer(QlbhBEL cus)
        {
            dal.EditCustomer(cus);
        }
    }
}
