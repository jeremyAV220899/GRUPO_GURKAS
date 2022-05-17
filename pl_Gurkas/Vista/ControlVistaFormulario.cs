using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pl_Gurkas.Vista
{
    class ControlVistaFormulario
    {
        public void ControlVista(Form frmPrincipal, Form objFormularioHijo)
        {
            Boolean open = false;
            if (frmPrincipal.MdiChildren.Length > 0)
            {
                foreach (Form frm in frmPrincipal.MdiChildren)
                {
                    if (frm.Text == objFormularioHijo.Text)
                    {
                        open = true;
                        return;
                    }
                }
            }
            if (!open)
            {
                objFormularioHijo.MdiParent = frmPrincipal;
                objFormularioHijo.Show();
            }
        }
    }
}
