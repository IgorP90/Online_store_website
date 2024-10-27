﻿using backend.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace backend.CRUD
{
    public class Delete
    {
        private readonly Context context;

        public Delete(Context context) => this.context = context;

        public void DeleteRow<T>(int id) where T : class, IId
        {
            context.RemoveRange(context.Set<T>().Where(i => i.Id == id));
            context.SaveChanges();
   
        }
    }
}
