﻿using System;
using System.Collections.Generic;
using System.Linq;
using StackOverflowProject.DomainModels;
using StackOverflowProject.ViewModels;
using StackOverflowProject.Repositories;
using AutoMapper;
using AutoMapper.Configuration;

namespace StackOverflowProject.ServiceLayer
{
    public interface IuserService
    {
        int InsertUser(RegisterViewModel uvm);
        void UpdateUserDetails(EditUserDetailsViewModels uvm);
        void UpdateUserPassword(EditUserPasswordViewModel uvm);
        void DeleteUser(int uid);
        List<UserViewModel> GetUsers();
        UserViewModel GetUsersByEmailAndPassword(string Email, string Password);
        UserViewModel GetUsersByEmail(string Email);

        UserViewModel GetUsersByUserID(int UserID);
    }
    public class UserService:IuserService
    {
        IUsersRepository ur;

        public UserService()
        {
            ur = new UsersRepository();
        }

        public int InsertUser(RegisterViewModel uvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<RegisterViewModel, User>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            User u = Mapper.Map<RegisterViewModel, User>(uvm);
            u.PasswordHash = SHA256HashGenerator.GenerateHash(uvm.Password);
            ur.InsertUser(u);
            int uid = ur.GetLatestUserID();
            return uid;
        }

        public void UpdateUserDetails(EditUserDetailsViewModels uvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditUserDetailsViewModels, User>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            User u = Mapper.Map<EditUserDetailsViewModels, User>(uvm);
            ur.UpdateUserDetails(u);
        }

        public void UpdateUserPassword(EditUserPasswordViewModel uvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditUserPasswordViewModel, User>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            User u = Mapper.Map<EditUserPasswordViewModel, User>(uvm);
            u.PasswordHash = SHA256HashGenerator.GenerateHash(uvm.Password);
            ur.UpdateUserPassword(u);
        }

        public void DeleteUser(int uid)
        {
            ur.DeleteUser(uid);
        }

        public List<UserViewModel> GetUsers()
        {
            List<User> u= ur.GetUsers();
            var confg = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = confg.CreateMapper();
            List<UserViewModel> uvm = mapper.Map<List<User>, List<UserViewModel>>(u);
            return uvm;
        }

        public UserViewModel GetUsersByEmailAndPassword(string Email, string Password)
        {
            User u = ur.GetUsersByEmailAndPassword(Email,SHA256HashGenerator.GenerateHash(Password)).FirstOrDefault();
            UserViewModel uvm = null;
            if (u != null)
            {
                var confg = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = confg.CreateMapper();
                uvm = mapper.Map<User, UserViewModel>(u);
            }
            return uvm;
        }

        public UserViewModel GetUsersByEmail(string Email)
        {
            User u = ur.GetUsersByEmail(Email).FirstOrDefault();
            UserViewModel uvm = null;
            if (u != null)
            {
                var confg = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = confg.CreateMapper();
                uvm = mapper.Map<User, UserViewModel>(u);
            }
            return uvm;
        }

        public UserViewModel GetUsersByUserID(int UserID)
        {
            User u = ur.GetUsersByUserID(UserID).FirstOrDefault();
            UserViewModel uvm = null;
            if (u != null)
            {
                var confg = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = confg.CreateMapper();
                uvm = mapper.Map<User, UserViewModel>(u);
            }
            return uvm;
        }
    }
}
