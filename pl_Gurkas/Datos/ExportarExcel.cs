using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Office = Microsoft.Office;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.IO;

namespace pl_Gurkas.Datos
{
    class ExportarExcel
    {
        public void ExportarDatos(DataGridView grd)
        {
            try
            {

                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.FileName = "ArchivoExportado";
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libros_trabajo = aplicacion.Workbooks.Add();
                    hoja_trabajo =
                        (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);

                    int IndiceColumna = 0;
                    foreach (DataGridViewColumn columna in grd.Columns) //Aquí empezamos a leer las columnas del listado a exportar
                    {
                        IndiceColumna++;
                        hoja_trabajo.Cells[1, IndiceColumna] = columna.Name;
                    }
                    int IndiceFila = 0;
                    foreach (DataGridViewRow fila in grd.Rows) //Aquí leemos las filas de las columnas leídas
                    {
                        IndiceFila++;
                        IndiceColumna = 0;
                        foreach (DataGridViewColumn columna in grd.Columns)
                        {
                            IndiceColumna++;
                            hoja_trabajo.Cells[IndiceFila + 1, IndiceColumna] = fila.Cells[columna.Name].Value;
                        }
                    }
                    libros_trabajo.SaveAs(fichero.FileName,
                        Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libros_trabajo.Close(true);
                    aplicacion.Quit();
                    MessageBox.Show("Exportacion Exitozamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar la informacion debido a: " + ex.ToString());
            }
        }

        public void ExportarDatosBarra(DataGridView dgView, ProgressBar pBar)
        {
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.FileName = "ArchivoExportado";
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    if (pBar != null)
                    {
                        pBar.Maximum = dgView.RowCount;
                        pBar.Value = 0;
                        if (!pBar.Visible) pBar.Visible = true;
                    }

                    //CREACIÓN DE LOS OBJETOS DE EXCEL
                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libros_trabajo = aplicacion.Workbooks.Add();

                    Excel.Range formatRange;

                    hoja_trabajo =
                        (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);


                    //AGREGAMOS LOS ENCABEZADOS
                    int iFil = 0, iCol = 0;


                    foreach (DataGridViewColumn columna in dgView.Columns) //Aquí empezamos a leer las columnas del listado a exportar
                    {
                        iCol++;
                        hoja_trabajo.Cells[1, iCol] = columna.Name;

                    }

                    foreach (DataGridViewRow fila in dgView.Rows) //Aquí leemos las filas de las columnas leídas
                    {
                        iFil++;
                        iCol = 0;
                        foreach (DataGridViewColumn columna in dgView.Columns)
                        {
                            iCol++;
                            hoja_trabajo.Cells[iFil + 1, iCol] = fila.Cells[columna.Name].Value;
                            formatRange = hoja_trabajo.get_Range("a" + (iFil + 1), "ca" + (iFil + 1));
                            formatRange.NumberFormat = "@";
                        }
                        pBar.Value += 1;
                    }
                    libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libros_trabajo.Close(true);
                    aplicacion.Quit();
                    MessageBox.Show("Exportacion Exitozamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            finally
            {
                if (pBar != null)
                {
                    pBar.Value = 0;
                    pBar.Visible = false;
                }
            }
        }
        public void ExportarDatosBarraPlanillaDescansoMedico(DataGridView dgView, ProgressBar pBar)
        {
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.FileName = "ArchivoExportado";
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    if (pBar != null)
                    {
                        pBar.Maximum = dgView.RowCount;
                        pBar.Value = 0;
                        if (!pBar.Visible) pBar.Visible = true;
                    }

                    //CREACIÓN DE LOS OBJETOS DE EXCEL
                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libros_trabajo = aplicacion.Workbooks.Add();

                    Excel.Range formatRange;

                    hoja_trabajo =
                        (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);


                    //AGREGAMOS LOS ENCABEZADOS
                    int iFil = 0, iCol = 0;


                    foreach (DataGridViewColumn columna in dgView.Columns) //Aquí empezamos a leer las columnas del listado a exportar
                    {
                        iCol++;
                        hoja_trabajo.Cells[1, iCol] = columna.Name;

                    }

                    foreach (DataGridViewRow fila in dgView.Rows) //Aquí leemos las filas de las columnas leídas
                    {
                        iFil++;
                        iCol = 0;
                        foreach (DataGridViewColumn columna in dgView.Columns)
                        {
                            iCol++;
                            hoja_trabajo.Cells[iFil + 1, iCol] = fila.Cells[columna.Name].Value;
                            /*formatRange = hoja_trabajo.get_Range("o" + (iFil + 1), "x" + (iFil + 1));
                            formatRange.NumberFormat = "#,###,###";
                            formatRange = hoja_trabajo.get_Range("z" + (iFil + 1), "aj" + (iFil + 1));
                            formatRange.NumberFormat = "#,###,###";
                            
                             */
                            formatRange = hoja_trabajo.get_Range("ae" + (iFil + 1), "af" + (iFil + 1));
                            formatRange.NumberFormat = "@";


                        }
                        pBar.Value += 1;
                    }
                    libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libros_trabajo.Close(true);
                    aplicacion.Quit();
                    MessageBox.Show("Exportacion Exitozamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            finally
            {
                if (pBar != null)
                {
                    pBar.Value = 0;
                    pBar.Visible = false;
                }
            }
        }
        public void ExportarDatosBarraPlanillaVacaciones(DataGridView dgView, ProgressBar pBar)
        {
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.FileName = "ArchivoExportado";
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    if (pBar != null)
                    {
                        pBar.Maximum = dgView.RowCount;
                        pBar.Value = 0;
                        if (!pBar.Visible) pBar.Visible = true;
                    }

                    //CREACIÓN DE LOS OBJETOS DE EXCEL
                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libros_trabajo = aplicacion.Workbooks.Add();

                    Excel.Range formatRange;

                    hoja_trabajo =
                        (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);


                    //AGREGAMOS LOS ENCABEZADOS
                    int iFil = 0, iCol = 0;


                    foreach (DataGridViewColumn columna in dgView.Columns) //Aquí empezamos a leer las columnas del listado a exportar
                    {
                        iCol++;
                        hoja_trabajo.Cells[1, iCol] = columna.Name;

                    }

                    foreach (DataGridViewRow fila in dgView.Rows) //Aquí leemos las filas de las columnas leídas
                    {
                        iFil++;
                        iCol = 0;
                        foreach (DataGridViewColumn columna in dgView.Columns)
                        {
                            iCol++;
                            hoja_trabajo.Cells[iFil + 1, iCol] = fila.Cells[columna.Name].Value;
                            /*formatRange = hoja_trabajo.get_Range("o" + (iFil + 1), "x" + (iFil + 1));
                            formatRange.NumberFormat = "#,###,###";
                            formatRange = hoja_trabajo.get_Range("z" + (iFil + 1), "aj" + (iFil + 1));
                            formatRange.NumberFormat = "#,###,###";
                            
                             */
                            formatRange = hoja_trabajo.get_Range("w" + (iFil + 1), "x" + (iFil + 1));
                            formatRange.NumberFormat = "@";


                        }
                        pBar.Value += 1;
                    }
                    libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libros_trabajo.Close(true);
                    aplicacion.Quit();
                    MessageBox.Show("Exportacion Exitozamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            finally
            {
                if (pBar != null)
                {
                    pBar.Value = 0;
                    pBar.Visible = false;
                }
            }
        }

        public void ExportarDatosBarraPlanillaOtrasLicencias(DataGridView dgView, ProgressBar pBar)
        {
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.FileName = "ArchivoExportado";
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    if (pBar != null)
                    {
                        pBar.Maximum = dgView.RowCount;
                        pBar.Value = 0;
                        if (!pBar.Visible) pBar.Visible = true;
                    }

                    //CREACIÓN DE LOS OBJETOS DE EXCEL
                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libros_trabajo = aplicacion.Workbooks.Add();

                    Excel.Range formatRange;

                    hoja_trabajo =
                        (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);


                    //AGREGAMOS LOS ENCABEZADOS
                    int iFil = 0, iCol = 0;


                    foreach (DataGridViewColumn columna in dgView.Columns) //Aquí empezamos a leer las columnas del listado a exportar
                    {
                        iCol++;
                        hoja_trabajo.Cells[1, iCol] = columna.Name;

                    }

                    foreach (DataGridViewRow fila in dgView.Rows) //Aquí leemos las filas de las columnas leídas
                    {
                        iFil++;
                        iCol = 0;
                        foreach (DataGridViewColumn columna in dgView.Columns)
                        {
                            iCol++;
                            hoja_trabajo.Cells[iFil + 1, iCol] = fila.Cells[columna.Name].Value;
                            /*formatRange = hoja_trabajo.get_Range("o" + (iFil + 1), "x" + (iFil + 1));
                            formatRange.NumberFormat = "#,###,###";
                            formatRange = hoja_trabajo.get_Range("z" + (iFil + 1), "aj" + (iFil + 1));
                            formatRange.NumberFormat = "#,###,###";
                            
                             */
                            formatRange = hoja_trabajo.get_Range("r" + (iFil + 1), "s" + (iFil + 1));
                            formatRange.NumberFormat = "@";


                        }
                        pBar.Value += 1;
                    }
                    libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libros_trabajo.Close(true);
                    aplicacion.Quit();
                    MessageBox.Show("Exportacion Exitozamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            finally
            {
                if (pBar != null)
                {
                    pBar.Value = 0;
                    pBar.Visible = false;
                }
            }
        }
        public void ExportarDatosBarraPlanilla(DataGridView dgView, ProgressBar pBar)
        {
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.FileName = "ArchivoExportado";
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    if (pBar != null)
                    {
                        pBar.Maximum = dgView.RowCount;
                        pBar.Value = 0;
                        if (!pBar.Visible) pBar.Visible = true;
                    }

                    //CREACIÓN DE LOS OBJETOS DE EXCEL
                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libros_trabajo = aplicacion.Workbooks.Add();

                    Excel.Range formatRange;

                    hoja_trabajo =
                        (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);


                    //AGREGAMOS LOS ENCABEZADOS
                    int iFil = 0, iCol = 0;


                    foreach (DataGridViewColumn columna in dgView.Columns) //Aquí empezamos a leer las columnas del listado a exportar
                    {
                        iCol++;
                        hoja_trabajo.Cells[1, iCol] = columna.Name;

                    }

                    foreach (DataGridViewRow fila in dgView.Rows) //Aquí leemos las filas de las columnas leídas
                    {
                        iFil++;
                        iCol = 0;
                        foreach (DataGridViewColumn columna in dgView.Columns)
                        {
                            iCol++;
                            hoja_trabajo.Cells[iFil + 1, iCol] = fila.Cells[columna.Name].Value;
                            /*formatRange = hoja_trabajo.get_Range("o" + (iFil + 1), "x" + (iFil + 1));
                            formatRange.NumberFormat = "#,###,###";
                            formatRange = hoja_trabajo.get_Range("z" + (iFil + 1), "aj" + (iFil + 1));
                            formatRange.NumberFormat = "#,###,###";
                            
                             */
                            formatRange = hoja_trabajo.get_Range("ba" + (iFil + 1), "bb" + (iFil + 1));
                            formatRange.NumberFormat = "@";


                        }
                        pBar.Value += 1;
                    }
                    libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libros_trabajo.Close(true);
                    aplicacion.Quit();
                    MessageBox.Show("Exportacion Exitozamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            finally
            {
                if (pBar != null)
                {
                    pBar.Value = 0;
                    pBar.Visible = false;
                }
            }
        }
       
        public void ExportarDatosBarraPlanillaBanco(DataGridView dgView, ProgressBar pBar)
        {
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.FileName = "ArchivoExportado";
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    if (pBar != null)
                    {
                        pBar.Maximum = dgView.RowCount;
                        pBar.Value = 0;
                        if (!pBar.Visible) pBar.Visible = true;
                    }

                    //CREACIÓN DE LOS OBJETOS DE EXCEL
                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libros_trabajo = aplicacion.Workbooks.Add();

                    Excel.Range formatRange;

                    hoja_trabajo =
                        (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);


                    //AGREGAMOS LOS ENCABEZADOS
                    int iFil = 0, iCol = 0;


                    foreach (DataGridViewColumn columna in dgView.Columns) //Aquí empezamos a leer las columnas del listado a exportar
                    {
                        iCol++;
                        hoja_trabajo.Cells[1, iCol] = columna.Name;

                    }

                    foreach (DataGridViewRow fila in dgView.Rows) //Aquí leemos las filas de las columnas leídas
                    {
                        iFil++;
                        iCol = 0;
                        foreach (DataGridViewColumn columna in dgView.Columns)
                        {
                            iCol++;
                            hoja_trabajo.Cells[iFil + 1, iCol] = fila.Cells[columna.Name].Value;
                            /*formatRange = hoja_trabajo.get_Range("o" + (iFil + 1), "x" + (iFil + 1));
                            formatRange.NumberFormat = "#,###,###";
                            formatRange = hoja_trabajo.get_Range("z" + (iFil + 1), "aj" + (iFil + 1));
                            formatRange.NumberFormat = "#,###,###";
                            
                             */
                            formatRange = hoja_trabajo.get_Range("a" + (iFil + 1), "am" + (iFil + 1));
                            formatRange.NumberFormat = "@";


                        }
                        pBar.Value += 1;
                    }
                    libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libros_trabajo.Close(true);
                    aplicacion.Quit();
                    MessageBox.Show("Exportacion Exitozamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            finally
            {
                if (pBar != null)
                {
                    pBar.Value = 0;
                    pBar.Visible = false;
                }
            }
        }
    }
}
