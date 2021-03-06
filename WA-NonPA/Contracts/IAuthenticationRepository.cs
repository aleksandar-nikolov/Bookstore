﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WA_NonPA.Models;

namespace WA_NonPA.Contracts
{
    public interface IAuthenticationRepository
    {
        public Task<bool> Register(RegistrationModel user);

        public Task<bool> Login(LoginModel user);

        public Task Logout();
    }
}
