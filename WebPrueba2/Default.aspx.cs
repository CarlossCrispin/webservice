using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPrueba2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            wsPrueba ws = new wsPrueba();
           // GridUsuarios.DataSource = ws.Consulta();
            GridUsuarios.DataBind();
        }

      
    }
}