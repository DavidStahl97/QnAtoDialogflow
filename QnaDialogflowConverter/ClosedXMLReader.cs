using ClosedXML.Excel;
using LTRSimulation.Core.Files;
using System;
using System.Linq;

namespace LTRSimulation.Common.Services
{
    public class ClosedXmlTable : IExcelReader, IDisposable
    {
        private readonly XLWorkbook _workbook;
        private readonly IXLWorksheet _worksheet;

        private bool _disposed;

        public ClosedXmlTable(string tableName)
        {
            _workbook = new XLWorkbook(tableName);
            _worksheet = _workbook.Worksheet(1);

            RowCount = _worksheet.RowsUsed().Count();
        }

        ~ClosedXmlTable()
        {
            Dispose(false);
        }

        public int RowCount { get; }

        public DateTime GetDateTime(int row, int column)
        {
            var r = _worksheet.Row(row);
            var cell = r.Cell(column);

            var dateTime = cell.GetValue<DateTime>();
            return dateTime;
        }

        public string GetNumber(int row, int column)
        {
            return GetStringOfField(row, column);
        }

        public string GetStringOfField(int row, int column)
        {
            return _worksheet.Row(row).Cell(column).GetValue<string>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _workbook?.Dispose();
            }

            _disposed = true;
        }
    }
}