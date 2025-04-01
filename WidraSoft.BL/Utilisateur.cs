using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WidraSoft.DA;

namespace WidraSoft.BL
{
    public class Utilisateur
    {
        public DataTable List(string filter)
        {
            try
            {
                UtilisateurDA utilisateur = new UtilisateurDA();
                return utilisateur.List(filter);
            }
            catch
            {
                throw;
            }

        }
        public DataTable GetById(Int32 Id)
        {
            try
            {
                UtilisateurDA utilisateur = new UtilisateurDA();
                return utilisateur.FindById(Id);
            }
            catch
            {
                throw;
            }
        }

        public Boolean CanConnect(string Login, string Password)
        {
            try
            {
                UtilisateurDA utilisateur = new UtilisateurDA();
                return utilisateur.CanConnect(Login, Password);
            }
            catch
            {
                throw;
            }
        }

        public Int32 GetUserIdByLoginAndPassword(string Login, string Password)
        {
            try
            {
                UtilisateurDA utilisateur = new UtilisateurDA();
                Int32 Id = utilisateur.GetUserIdByLoginAndPassword(Login, Password);
                return Id;
            }
            catch
            {
                throw;
            }
        }

        public string GetFullUsername(Int32 Id)
        {
            try
            {
                UtilisateurDA utilisateur = new UtilisateurDA();
                string username = utilisateur.GetFullUsername(Id);
                return username;
            }
            catch
            {
                throw;
            }
        }
        public void Add(string Nom, string Prenom, string Login, string Password, Int32 GroupeId)
        {
            try
            {   
                UtilisateurDA utilisateur = new UtilisateurDA();
                utilisateur.Add(Nom, Prenom, Login, Password, GroupeId);
            }
            catch
            {
                throw;
            }

        }
        public void Update(Int32 Id,string Nom, string Prenom, string Login, string Password, Int32 GroupeId)
        {
            try
            {
                UtilisateurDA utilisateur = new UtilisateurDA();
                utilisateur.Update(Id, Nom, Prenom, Login, Password, GroupeId);
            }
            catch
            {
                throw;
            }
            
        }

        public void Delete(Int32 Id)
        {
            try
            {
                UtilisateurDA utilisateur = new UtilisateurDA();
                utilisateur.Delete(Id);
            }
            catch
            {
                throw;
            } 
            

        }
    }
}
