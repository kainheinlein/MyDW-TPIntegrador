using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BackupBLL
    {
        public void Restore(string dest)
        {
            MP_Backup dalBackup = new MP_Backup();
            dalBackup.importar(dest);
        }

        public void Backup(string dest)
        {
            MP_Backup dalBackup = new MP_Backup();
            dalBackup.exportar(dest);
        }
    }
}
