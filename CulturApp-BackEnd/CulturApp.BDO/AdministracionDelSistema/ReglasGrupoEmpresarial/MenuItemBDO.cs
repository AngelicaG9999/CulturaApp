
using System;
using System.Collections.ObjectModel;

namespace CulturApp.BDO.AdministracionDelSistema.ReglasGrupoEmpresarial
{
    public class MenuItemBDO
    {
        public MenuItemBDO()
        {
            this.SubItems = new ObservableCollection<MenuItemBDO>();
        }

        public long PadreID { get; set; }

        public string MenuID { get; set; }

        public string Value { get; set; }

        public string Text { get; set; }

        public string Clave { get; set; }

        public string ObjetoUrl { get; set; }

        public Uri IconUrl { get; set; }

        public ObservableCollection<MenuItemBDO> SubItems { get; set; }
    }
}
