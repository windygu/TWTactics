#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using TribalWars.Data.Villages;
using TribalWars.Data.Players;
using TribalWars.Data.Events;
using Janus.Windows.GridEX;
#endregion

namespace TribalWars.Controls
{
    /// <summary>
    /// Manages the villages inside the BBCodeArea polygons
    /// </summary>
    public partial class PolygonControl : UserControl
    {
        #region Constructors
        public PolygonControl()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            World.Default.Map.EventPublisher.PolygonActivated += new EventHandler<PolygonEventArgs>(EventPublisher_PolygonActivated);
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// BBCodeArea polygon(s) have been ported to this control
        /// </summary>
        private void EventPublisher_PolygonActivated(object sender, PolygonEventArgs e)
        {
            GridExPolygon.DataSource = e.Villages;
            GridExPolygon.CheckAllRecords();
            GridExPolygon.MoveFirst();
        }

        /// <summary>
        /// The selected villages are exported to the clipboard
        /// </summary>
        private void ButtonGenerate_Click(object sender, EventArgs e)
        {
            if (GridExPolygon.RowCount == 0) return;

            StringBuilder str = new StringBuilder();
            foreach (GridEXRow groupRow in GridExPolygon.GetRows())
            {
                if (groupRow.RowType == RowType.GroupHeader)
                {
                    str.AppendLine();
                    str.AppendLine();
                    str.AppendLine(groupRow.GroupValue.ToString());
                    foreach (GridEXRow row in groupRow.GetChildRecords())
                    {
                        PolygonDataSet.VILLAGERow villageRow = (PolygonDataSet.VILLAGERow)((DataRowView)row.DataRow).Row;
                        if (!villageRow.IsTYPENull() && !string.IsNullOrEmpty(villageRow.TYPE))
                        {
                            str.AppendLine(villageRow.BBCODE + " (" + villageRow.TYPE + ")");
                        }
                        else
                        {
                            str.AppendLine(villageRow.BBCODE);
                        }
                    }
                }
            }

            /*foreach (GridEXRow row in GridExPolygon.GetCheckedRows())
            {
                PolygonDataSet.VILLAGERow villageRow = (PolygonDataSet.VILLAGERow)((DataRowView)row.DataRow).Row;
                if (!villageRow.IsTYPENull() && !string.IsNullOrEmpty(villageRow.TYPE))
                {
                    str.AppendLine(villageRow.BBCODE + " (" + villageRow.TYPE + ")");
                }
                else
                {
                    str.AppendLine(villageRow.BBCODE);
                }
            }*/

            try
            {
                Clipboard.SetText(str.ToString().Trim());
            }
            catch (Exception)
            {
                
            }
        }

        private void GridExPolygon_FormattingRow(object sender, RowLoadEventArgs e)
        {
            if (e.Row.RowType == RowType.GroupHeader)
            {
                e.Row.GroupCaption = string.Format("{0} ({1})", e.Row.GroupValue, e.Row.GetRecordCount());
            }
        }
        #endregion
    }
}
