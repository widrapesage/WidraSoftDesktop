using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidraSoft.UI
{
    public class Common_functions
    {
        public static Int32 CbSelectedValue_Convert_Int(ComboBox o)
        {
            if (o.SelectedValue == null)
            {
                return 0;
            }
            else
            {
                if (o.Text == "" || o.Text == "System.Data.DataRowView") 
                    return 0;
                else
                    return (Int32)o.SelectedValue;
            }
        }

        //Pour WEIGHING_SETTINGS prendre la valeur SelectedValue meme si Text = "System.Data.DataRowView"
        public static Int32 CbSelectedValue_Convert_Int_2(ComboBox o)
        {
            if (o.SelectedValue == null)
            {
                return 0;
            }
            else
            {
                if (o.Text == "")
                    return 0;
                else
                    return (Int32)o.SelectedValue;
            }
        }

        public static Int32 GetDatagridViewSelectedId(DataGridView d)
        {
            try
            {
                return  (Int32)d[0, d.CurrentCell.RowIndex].Value;
                
            }
            catch
            {
                throw;
            }
        }

        public static Int32[] GetDatagridViewSelectedRowsId(DataGridView d)
        {
            try
            {
                Int32 SelectedRowsCount = d.Rows.GetRowCount(DataGridViewElementStates.Selected);
                Int32[] Selected = new Int32[SelectedRowsCount];
                if (SelectedRowsCount > 0)
                {

                    for (int i = 0; i < SelectedRowsCount; i++)
                    {
                        Selected[i] = Int32.Parse(d.SelectedRows[i].Cells[0].Value.ToString());
                    }

                }
                return Selected;
            }
            catch
            {
                throw;
            }
        }
    }
}
