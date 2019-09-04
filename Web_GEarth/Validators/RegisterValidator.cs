﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_GEarth.Models;
using Web_GEarth.ViewModels;

namespace Web_GEarth.Validators
{
    public interface IRegisterValidator
    {
        ErrorsCollection Validate(RegisterPostModel registerPostModel, RoutesDbContext context);
    }
    public class RegisterValidator : IRegisterValidator
    {
        public ErrorsCollection Validate(RegisterPostModel registerPostModel, RoutesDbContext context)
        {
            ErrorsCollection errorsCollection = new ErrorsCollection { Entity = nameof(RegisterPostModel) };
            User existing = context.Users.FirstOrDefault(u => u.Username == registerPostModel.Username);
            if (existing != null)
            {
                errorsCollection.ErrorMessages.Add($"The username {registerPostModel.Username} is already taken!");
            }
            if (registerPostModel.Password.Length < 6)
            {
                errorsCollection.ErrorMessages.Add("The password cannot be shorter than 6 characters!");
            }
            int numberOfDigits = 0;
            foreach (char c in registerPostModel.Password)
            {
                if (c >= '0' && c <= '9')
                {
                    numberOfDigits++;
                }
            }
            if (numberOfDigits < 2)
            {
                errorsCollection.ErrorMessages.Add("The password must contain at least two digits!");
            }
            if (errorsCollection.ErrorMessages.Count > 0)
            {
                return errorsCollection;
            }
            return null;
        }
    }
}
