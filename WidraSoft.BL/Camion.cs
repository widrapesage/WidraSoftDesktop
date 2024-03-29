﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidraSoft.DA;

namespace WidraSoft.BL
{
    public class Camion
    {
        public DataTable List(string filter)
        {
            try
            {
                CamionDA camion = new CamionDA();
                return camion.List(filter);
            }
            catch
            {
                throw;
            }

        }

        public DataTable FindById(Int32 Id)
        {
            try
            {
                CamionDA camion = new CamionDA();
                return camion.FindById(Id);
            }
            catch
            {
                throw;
            }
        }

        public string GetName(Int32 Id)
        {
            try
            {
                CamionDA camion = new CamionDA();
                return camion.GetName(Id);
            }
            catch
            {
                throw;
            }
        }

        public void Add(String Code, String Plaque, String Badge, Int32 Tare, Int32 Valide,
           Int32 Bloque, String TexteBloque, Int32 Attention, String TexteAttention, String Observations)
        {
            try
            {
                CamionDA camion = new CamionDA();
                camion.Add(Code, Plaque,  Badge,  Tare,  Valide,
                    Bloque,  TexteBloque,  Attention,  TexteAttention,  Observations);
            }
            catch
            {
                throw;
            }
        }

        public void Update(Int32 Id,String Code, String Plaque, String Badge, Int32 Tare, Int32 Valide,
           Int32 Bloque, String TexteBloque, Int32 Attention, String TexteAttention, String Observations)
        {
            try
            {
                CamionDA camion = new CamionDA();
                camion.Update(Id, Code, Plaque, Badge, Tare, Valide,
                    Bloque, TexteBloque, Attention, TexteAttention, Observations);
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
                CamionDA camion = new CamionDA();
                camion.Delete(Id);
            }
            catch
            {
                throw;
            }
        }
    }
}
