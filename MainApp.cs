using FolderMedia_tools;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoZ
{
    public partial class MainApp : Form
    {
        public static String folderPath;

        Boolean eraseFolders;
        Boolean eraseSmallFiles;
        Boolean eraseCorchetesD;
        Boolean eraseCorchetesF;

        public MainApp()
        {
            InitializeComponent();
        }

        private void MainApp_Shown(Object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
        }

        private void bSetPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog1.SelectedPath;
                tbPath.Text = folderPath;
            }
        }

        private void bEjecutar_Click(object sender, EventArgs e)
        {
            if (folderPath==null)
            {
                MessageBox.Show("Debe seleccionarse una carpeta","Error");
            } else
            {
                eraseFolders = rbDeleteEmptyFolders.Checked;
                eraseSmallFiles = rbDeleteSmallFiles.Checked;
                eraseCorchetesD = rbDeleteCorchetesD.Checked;
                eraseCorchetesF = rbDeleteCorchetesF.Checked;

                if (!eraseFolders && !eraseSmallFiles && !eraseCorchetesD && !eraseCorchetesF)
                {
                    MessageBox.Show("Debe seleccionarse una tarea", "Error");
                } else
                {
                    if (existsDirectory(folderPath))
                    {
                        DirectoryInfo rootDI = new DirectoryInfo(folderPath);
                        if (eraseFolders)
                        {
                            addLog("Comienza el proceso borrarCarpetasVacias para la ruta <<" + folderPath + ">> --- " + DateTime.UtcNow);
                        }
                        else if (eraseSmallFiles)
                        {
                            addLog("Comienza el proceso borrarArchivosPequeños para la ruta <<" + folderPath + ">> --- " + DateTime.UtcNow);
                        } 
                        else if (eraseCorchetesD)
                        {
                            addLog("Comienza el proceso borrarCorchetes (en Directorios) para la ruta <<" + folderPath + ">> --- " + DateTime.UtcNow);
                        }
                        else if (eraseCorchetesF)
                        {
                            addLog("Comienza el proceso borrarCorchetes (en Ficheros) para la ruta <<" + folderPath + ">> --- " + DateTime.UtcNow);
                        }
                        //*************************************************
                        trabajarDirectorio(rootDI); // MAIN BUSSINES *****
                        //************************************************
                        if (eraseFolders)
                        {
                            addLog("Ha finalizado el proceso borrarCarpetasVacias" + " --- " + DateTime.UtcNow);
                        }
                        else if (eraseSmallFiles)
                        {
                            addLog("Ha finalizado el proceso borrarArchivosPequeños" + " --- " + DateTime.UtcNow);
                        }
                        else if (eraseCorchetesD)
                        {
                            addLog("Comienza el proceso borrarCorchetes (en Directorios) para la ruta <<" + folderPath + ">> --- " + DateTime.UtcNow);
                        }
                        else if (eraseCorchetesF)
                        {
                            addLog("Ha finalizado el proceso borrarCorchetes" + " --- " + DateTime.UtcNow);
                        }
                        addLog("");

                    } else MessageBox.Show("No existe el directorio "+ folderPath, "Error");
                }
            }
        }

        private Boolean doJob (DirectoryInfo currentDir)
        {
            if (eraseFolders)
            {
                return borrarCarpetaVacia(currentDir);
            }
            else if (eraseSmallFiles)
            {
                borrarArchivosPequeños(currentDir);
            }
            else if (eraseCorchetesD)
            {
                borrarCorchetesD(currentDir);
            }
            else if (eraseCorchetesF)
            {
                borrarCorchetesF(currentDir);
            }
            return true;
        }

        private void trabajarDirectorio (DirectoryInfo currentDir)
        {
            foreach (var subDir in currentDir.GetDirectories())
            {
                trabajarDirectorio(subDir);
            }
            Boolean done = doJob(currentDir);
        }

        //*********************************
        // SCRIPTS UNITARIOS
        //*********************************
        private void borrarCorchetesD (DirectoryInfo currentFolder)
        {
            addLog("Comprovando si la siguiente carpeta tiene corchetes: " + currentFolder.FullName);
            Boolean tiene = tieneCorchetes(currentFolder);
            if (tiene)
            {
                String parentPath = currentFolder.Parent.FullName;
                String folderName = currentFolder.Name;
                String renamedName = Regex.Replace(folderName, "\\[.*?\\] ?", "").Trim();
                addLog("Se procede a RENOMBRAR de <"+currentFolder.Name+"> a <"+ renamedName+">");
                try {
                    Directory.Move(currentFolder.FullName, parentPath + "\\" + renamedName);
                } catch (Exception e) {
                    addError(currentFolder.FullName);
                    addLog("ERROR renombrando "+currentFolder.FullName+"!! Motivo: "+e); addLog("");
                    addLog("-- Asegúrese de haber avisado al equipo para que no tengan abierta esta carpeta mientras se ejecuta el script y de haber cerrado las ventanas vinculadas e ésta en su explorador o los procesos que la utilicen / tener los permisos de escritura pertinentes, etc --"); addLog("");
                }
            }
        }

        private void borrarCorchetesF (DirectoryInfo currentFolder)
        {
            foreach (var subFile in currentFolder.GetFiles())
            {
                addLog("Comprovando si el siguiente archivo tiene corchetes: " + subFile.FullName);
                Boolean tiene = tieneCorchetes(subFile);
                if (tiene)
                {
                    String parentPath = subFile.Directory.FullName;
                    String fileName = subFile.Name;
                    String renamedName = Regex.Replace(fileName, "\\[.*?\\] ?", "").Trim();
                    addLog("Se procede a RENOMBRAR de <" + fileName + "> a <" + renamedName + ">");
                    try
                    {
                        Directory.Move(subFile.FullName, parentPath + "\\" + renamedName);
                    }
                    catch (Exception e)
                    {
                        addError(subFile.FullName);
                        addLog("ERROR renombrando " + currentFolder.FullName + "!! Motivo: " + e); addLog("");
                        addLog("-- Asegúrese de haber avisado al equipo para que no tengan en uso este fichero mientras se ejecuta el script y de haber cerrado las ventanas vinculadas e éste en su explorador o los procesos que lo utilicen / tener los permisos de escritura pertinentes, etc --"); addLog("");
                    }
                }
            }
        }

        private Boolean borrarCarpetaVacia (DirectoryInfo currentFolder)
        {
            addLog("Comprovando si la siguiente carpeta está vacía: " + currentFolder.FullName);
            Boolean vacia = isDirectoryEmpty(currentFolder);
            addLog("Se ha resuelto que está " + (vacia ? "VACÍA" : "LLENA"));
            if (vacia)
            {
                addLog("Se procede a BORRAR la carpeta <<"+ currentFolder.Name+">>");
                try { 
                    currentFolder.Delete();
                }
                catch (Exception e)
                {
                    addError(currentFolder.FullName);
                    addLog("ERROR borrando " + currentFolder.FullName + "!! Motivo: " + e); addLog("");
                    addLog("-- Asegúrese de haber avisado al equipo para que no tengan abierta esta carpeta mientras se ejecuta el script y de haber cerrado las ventanas vinculadas e ésta en su explorador o los procesos que la utilicen / tener los permisos de escritura pertinentes, etc --"); addLog("");
                }
                return true;
            }
            return false;
        }

        private void borrarArchivosPequeños (DirectoryInfo currentFolder)
        {
            foreach (var subFile in currentFolder.GetFiles())
            {
                addLog("Comprovando si el siguiente fichero tiene tamaño de menos de 1MB: " + subFile.Name);
                int diezMegas = 10000000; // 10MB
                Boolean pequeno = subFile.Length < diezMegas;
                addLog("El tamaño del fichero son "+ subFile.Length + " bytes, por lo tanto es "+(pequeno?"menor":"mayor")+ " que 10 MB");
                if (pequeno)
                {
                    addLog("Se procede a BORRAR el fichero.");
                    try
                    {
                        subFile.Delete();
                    } catch (Exception e) {
                        addError(subFile.FullName);
                        addLog("ERROR borrando " + currentFolder.FullName + "!! Motivo: " + e); addLog("");
                        addLog("-- Asegúrese de haber avisado al equipo para que no tengan en uso este fichero mientras se ejecuta el script y de haber cerrado las ventanas vinculadas e éste en su explorador o los procesos que lo utilicen / tener los permisos de escritura pertinentes, etc --"); addLog("");
                    }
                }
            }
        }


        //*********************************
        //Funcionalidades de comprovacióm
        //*********************************
        private Boolean tieneCorchetes (DirectoryInfo folder)
        {
            String folderName = folder.Name;
            Boolean tiene = folderName.Contains('[') && folderName.Contains(']');
            addLog("Se ha resuelto que la carpeta con el nombre <<"+folderName+">> "+(tiene?"TIENE":"NO tiene")+" corchetes");
            return tiene;
        }

        private Boolean tieneCorchetes(FileInfo file)
        {
            String fileName = file.Name;
            Boolean tiene = fileName.Contains('[') && fileName.Contains(']');
            addLog("Se ha resuelto que el fichero con el nombre <<" + fileName + ">> " + (tiene ? "TIENE" : "no tiene") + " corchetes");
            return tiene;
        }

        private Boolean isDirectoryEmpty (DirectoryInfo folder)
        {
            Boolean isEmpty = false;
            FileInfo[] filesInfo = folder.GetFiles();
            Boolean tieneFiles = filesInfo != null && filesInfo.Length > 0;
            DirectoryInfo[] foldersInfo = folder.GetDirectories();
            Boolean tieneFolders = foldersInfo != null && foldersInfo.Length > 0;
            if (!tieneFiles && !tieneFolders) isEmpty = true;
            return isEmpty;
        }

        private Boolean existsDirectory(string folder)
        {
            bool directoryExists = Directory.Exists(folder);
            if (!directoryExists) MessageBox.Show("El directorio no existe! " + folder, "Error");
            return directoryExists;
        }

        //***********
        // UTILS
        //***********
        private void addLog(string trace)
        {
            logs.AppendText(trace + "\r\n");
        }
        private void addError(string trace)
        {
            errors.AppendText(trace + "\r\n");
        }

        private void clean_Click(object sender, EventArgs e)
        {
            logs.Clear();
        }

        private void cleanErr_Click(object sender, EventArgs e)
        {
            errors.Clear();
        }
    }
}
