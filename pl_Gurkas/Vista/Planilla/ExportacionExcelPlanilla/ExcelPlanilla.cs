using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace pl_Gurkas.Vista.Planilla.ExportacionExcelPlanilla
{
    class ExcelPlanilla
    {
        public void ReporteAsistenciaPlanillaExcel(DataGridView dgView, ProgressBar pBar,string nombre,string fechai,string fechaf)
        {
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.FileName = "Asistencia de Personal del "+fechai+" al "+ fechaf  + " Unidad " + nombre;
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
        public void ExportarDatosPlanillaExcel(DataGridView dgView, ProgressBar pBar, string fechai, string fechaf)
        {
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.FileName = "Planilla del "+ fechai + " al " + fechaf;
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
                            formatRange = hoja_trabajo.get_Range("az" + (iFil + 1), "ba" + (iFil + 1));
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

        public void ExportarDatosBarraVacaciones(DataGridView dgView, ProgressBar pBar)
        {
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.FileName = "Planilla de Vacaciones";
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
                            formatRange = hoja_trabajo.get_Range("z" + (iFil + 1), "ab" + (iFil + 1));
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

        public void ExportarDatosBarraOtrasLicencias(DataGridView dgView, ProgressBar pBar)
        {
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.FileName = "Planilla de Otras Licencias ";
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
                            formatRange = hoja_trabajo.get_Range("u" + (iFil + 1), "v" + (iFil + 1));
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
        public void ExportarDatosBarraDescansoMedico(DataGridView dgView, ProgressBar pBar)
        {
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.FileName = "Planilla de Descanso Medico";
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
                            formatRange = hoja_trabajo.get_Range("ah" + (iFil + 1), "ai" + (iFil + 1));
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
        public void ExportarDatosCTSExcel(DataGridView dgView, ProgressBar pBar)
        {
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.FileName = "Planilla de CTS ";
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
                            formatRange = hoja_trabajo.get_Range("f" + (iFil + 1), "f" + (iFil + 1));
                            formatRange.NumberFormat = "@";
                            formatRange = hoja_trabajo.get_Range("i" + (iFil + 1), "i" + (iFil + 1));
                            formatRange.NumberFormat = "@";
                            formatRange = hoja_trabajo.get_Range("y" + (iFil + 1), "y" + (iFil + 1));
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
        public void ExportarDatosGRATIFICACIONExcel(DataGridView dgView, ProgressBar pBar)
        {
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.FileName = "Planilla de GRATIFICACION ";
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
                            formatRange = hoja_trabajo.get_Range("e" + (iFil + 1), "e" + (iFil + 1));
                            formatRange.NumberFormat = "@";
                            formatRange = hoja_trabajo.get_Range("aa" + (iFil + 1), "aa" + (iFil + 1));
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

        public void ExportarDatosBarraPlanillaContabilidad(DataGridView dgView, ProgressBar pBar)
        {
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.FileName = "Archivo Exportado";
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
                            formatRange = hoja_trabajo.get_Range("A" + (iFil + 1), "W" + (iFil + 1));
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
