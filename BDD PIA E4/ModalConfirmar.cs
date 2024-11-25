using System.Windows.Forms;

namespace Consultas
{
    public partial class ModalConfirmar : Form
    {
        public ModalConfirmar(string Mensaje)
        {
            InitializeComponent();
            this.ActiveControl = this.boton_cancelar;
            this.Mensaje.Text = Mensaje;
            this.boton_aceptar.DialogResult = DialogResult.OK;
            this.boton_cancelar.DialogResult = DialogResult.Cancel;
        }

        private void Mensaje_Click(object sender, System.EventArgs e)
        {

        }
    }
}
