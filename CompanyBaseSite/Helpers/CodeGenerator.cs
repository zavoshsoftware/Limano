﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace Helpers
{
    public static class CodeGenerator
    {
        private static DatabaseContext db = new DatabaseContext();


        public static int ReturnProductCode()
        {
            Product product = db.Products.Where(c => c.IsDeleted == false).OrderByDescending(current => current.Code).FirstOrDefault();

            if (product != null)
            {
                return Convert.ToInt32(product.Code) + 1;
            }
            return 100;
        }
         

    }
}