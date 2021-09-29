using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WidraSoft.DA;

namespace WidraSoft.BL
{
    public class Utilisateur
    {
        public DataTable List()
        {
            try
            {
                UtilisateurDA utilisateur = new UtilisateurDA();
                return utilisateur.List();
            }
            catch
            {
                throw;
            }

        }
        public DataTable GetById(Int16 Id)
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
        public void Add(string Nom, string Prenom, string Login, string Password, Int16 IsAdmin, Int16 PontDefaultId,DateTime DateCreation, DateTime DateInvalide, String Profil, String PeseeManuel)
        {
            try
            {
                UtilisateurDA utilisateur = new UtilisateurDA();
                utilisateur.Add(Nom, Prenom, Login, Password, IsAdmin, PontDefaultId, DateCreation, DateInvalide, Profil, PeseeManuel);
            }
            catch
            {
                throw;
            }

        }
    }
}
